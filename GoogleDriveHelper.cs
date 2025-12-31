using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackupSqlServerTool
{
    public class GoogleDriveHelper
    {
        private static string[] Scopes = { DriveService.Scope.DriveFile };
        private static string ApplicationName = "BackupSqlServerTool";
        private DriveService service;

        public bool IsConnected => service != null;

        public async Task<bool> Authenticate()
        {
            try
            {
                UserCredential credential;
                string credFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BackupSqlServerTool", "GoogleDriveToken");
                Directory.CreateDirectory(credFolder);
                
                // Kiểm tra xem file credentials.json có tồn tại không
                if (!File.Exists("credentials.json"))
                {
                    throw new FileNotFoundException("Không tìm thấy file 'credentials.json'. Vui lòng tải từ Google Cloud Console và đặt vào thư mục ứng dụng.");
                }

                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credFolder, true));
                }

                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message ?? "";
                if (msg.Contains("access_denied", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Truy cập bị từ chối (access_denied). Hãy thêm tài khoản vào 'OAuth consent screen' mục Test users và đặt trạng thái Publishing = Testing, sau đó xóa token và đăng nhập lại.");
                }
                throw new Exception($"Lỗi xác thực Google Drive: {msg}");
            }
        }

        public async Task<string> GetUserEmail()
        {
            if (service == null) return null;
            try
            {
                var aboutRequest = service.About.Get();
                aboutRequest.Fields = "user(emailAddress)";
                var about = await aboutRequest.ExecuteAsync();
                return about.User.EmailAddress;
            }
            catch
            {
                return "Unknown";
            }
        }

        public async Task<string> GetOrCreateFolder(string folderName, string parentId = null)
        {
            if (service == null) await Authenticate();

            // Tìm folder xem có tồn tại không
            var request = service.Files.List();
            string query = $"mimeType = 'application/vnd.google-apps.folder' and name = '{folderName}' and trashed = false";
            
            if (!string.IsNullOrEmpty(parentId))
            {
                query += $" and '{parentId}' in parents";
            }

            request.Q = query;
            request.Fields = "files(id, name)";
            
            var result = await request.ExecuteAsync();
            var folder = result.Files.FirstOrDefault();

            if (folder != null)
            {
                return folder.Id;
            }

            // Nếu không tìm thấy, tạo mới
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };

            if (!string.IsNullOrEmpty(parentId))
            {
                fileMetadata.Parents = new List<string> { parentId };
            }

            var createRequest = service.Files.Create(fileMetadata);
            createRequest.Fields = "id";
            var file = await createRequest.ExecuteAsync();
            
            return file.Id;
        }

        public async Task UploadOrUpdateFile(string filePath, string fileName, string folderId, string contentType = "application/zip")
        {
            if (service == null)
            {
                await Authenticate();
            }

            // 1. Tìm file đã tồn tại trong folder chưa
            var existingFile = await GetFileByName(fileName, folderId);
            string fileId = existingFile?.Id;

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = fileName
            };

            // Nếu folderId được cung cấp, set parent
            if (!string.IsNullOrEmpty(folderId) && string.IsNullOrEmpty(fileId))
            {
                fileMetadata.Parents = new List<string> { folderId };
            }

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Google.Apis.Upload.IUploadProgress progress;
                // Set ChunkSize to 10MB for better performance with large files (supports resumable upload)
                const int UploadChunkSize = 10 * 1024 * 1024;

                if (string.IsNullOrEmpty(fileId))
                {
                    // Tạo mới
                    var request = service.Files.Create(fileMetadata, stream, contentType);
                    request.ChunkSize = UploadChunkSize;
                    request.Fields = "id";
                    progress = await request.UploadAsync();
                }
                else
                {
                    // Update (ghi đè)
                    var request = service.Files.Update(fileMetadata, fileId, stream, contentType);
                    request.ChunkSize = UploadChunkSize;
                    request.Fields = "id";
                    progress = await request.UploadAsync();
                }

                if (progress.Status == Google.Apis.Upload.UploadStatus.Failed)
                {
                    throw new Exception($"Upload failed: {progress.Exception?.Message}", progress.Exception);
                }
            }
        }

        public async Task<Google.Apis.Drive.v3.Data.File> GetFileByName(string fileName, string folderId)
        {
            if (service == null) await Authenticate();

            var request = service.Files.List();
            string query = $"name = '{fileName}' and trashed = false";
            
            if (!string.IsNullOrEmpty(folderId))
            {
                query += $" and '{folderId}' in parents";
            }

            request.Q = query;
            request.Fields = "files(id, name, size, md5Checksum, modifiedTime)";

            var result = await request.ExecuteAsync();
            return result.Files.FirstOrDefault();
        }

        private async Task<string> FindFileIdByName(string fileName, string folderId)
        {
            var file = await GetFileByName(fileName, folderId);
            return file?.Id;
        }
    }
}
