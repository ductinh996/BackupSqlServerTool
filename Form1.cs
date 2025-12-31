using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO.Compression;
using System.Timers;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace BackupSqlServerTool
{
    public partial class MainForm : Form
    {
        private System.Timers.Timer backupTimer;
        private System.Timers.Timer cleanupTimer;
        private System.Timers.Timer fileBackupTimer;
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

        private GoogleDriveHelper driveHelper;
        private string? currentDbPassword;

        public MainForm()
        {
            InitializeComponent();
            XmlConfigurator.Configure(new FileInfo("App.config"));
            this.Load += MainForm_Load;

            backupTimer = new System.Timers.Timer();
            backupTimer.Elapsed += OnBackupEvent;
            backupTimer.AutoReset = true;

            cleanupTimer = new System.Timers.Timer();
            cleanupTimer.Elapsed += OnCleanupEvent;
            cleanupTimer.AutoReset = true;

            driveHelper = new GoogleDriveHelper();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load Config
            txtDriveFolderName.Text = GetConfigValue("DriveFolderName");
            txtDbList.Text = GetConfigValue("BackupDatabases");
            txtLocalFolder.Text = GetConfigValue("LocalBackupFolder");
            LoadDbConfigToFields();

            DateTime backupScheduledTime = DateTime.Today.AddHours(0); // 0h hàng ngày
            if (DateTime.Now > backupScheduledTime)
            {
                backupScheduledTime = backupScheduledTime.AddDays(1);
            }
            double backupInterval = (backupScheduledTime - DateTime.Now).TotalMilliseconds;
            backupTimer.Interval = backupInterval;
            backupTimer.Start();

            DateTime cleanupScheduledTime = DateTime.Today.AddHours(1); // 1h sáng hàng ngày
            if (DateTime.Now > cleanupScheduledTime)
            {
                cleanupScheduledTime = cleanupScheduledTime.AddDays(1);
            }
            double cleanupInterval = (cleanupScheduledTime - DateTime.Now).TotalMilliseconds;
            cleanupTimer.Interval = cleanupInterval;
            cleanupTimer.Start();

            SetupFileBackupTimer();
        }

 

        private async void BtnLoginDrive_Click(object sender, EventArgs e)
        {
            try
            {
                await driveHelper.Authenticate();
                string email = await driveHelper.GetUserEmail();
                lblDriveStatus.Text = $"Trạng thái: Đã kết nối ({email})";
                lblDriveStatus.ForeColor = Color.Green;

                MessageBox.Show($"Đăng nhập Google Drive thành công!\nTài khoản: {email}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogInfo($"Logged in to Google Drive successfully as {email}.");
            }
            catch (Exception ex)
            {
                lblDriveStatus.Text = "Trạng thái: Lỗi kết nối";
                lblDriveStatus.ForeColor = Color.Red;
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"Google Drive login error: {ex.Message}");
            }
        }

        private void TxtDriveFolderName_TextChanged(object sender, EventArgs e)
        {
            SaveConfigValue("DriveFolderName", txtDriveFolderName.Text);
        }

        private void TxtDbList_TextChanged(object sender, EventArgs e)
        {
            SaveConfigValue("BackupDatabases", txtDbList.Text);
        }

        private void BtnSaveDbConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string server = txtDbServer.Text?.Trim() ?? "";
                string user = txtDbUser.Text?.Trim() ?? "";
                string passwordInput = txtDbPassword.Text ?? "";
                string password = string.IsNullOrEmpty(passwordInput) ? (currentDbPassword ?? "") : passwordInput;
                string conn = $"Server={server};User Id={user};Password={password};Encrypt=false;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                }
                SaveConnectionString("DefaultConnection", conn);
                currentDbPassword = password;
                txtDbPassword.Text = "";
                LogInfo("Kết nối DB thành công và đã lưu cấu hình.");
                MessageBox.Show("Kết nối DB thành công và đã lưu cấu hình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError($"Lỗi kết nối DB: {ex.Message}");
                MessageBox.Show($"Lỗi kết nối DB: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Backup()
        {
            try
            {
                string dateString = DateTime.Now.ToString("yyyyMMdd");
                string backupFolder = Path.Combine(tblFolder.Text, "BackupSQL", "Details", dateString);
                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder);
                }

                string connectionString = GetConnectionString("DefaultConnection");
                var dbListConfig = GetConfigValue("BackupDatabases");
                if (!string.IsNullOrWhiteSpace(dbListConfig))
                {
                    var targetDbs = new List<string>();
                    foreach (var part in dbListConfig.Split(','))
                    {
                        var name = part.Trim();
                        if (!string.IsNullOrEmpty(name))
                        {
                            targetDbs.Add(name);
                        }
                    }
                    if (targetDbs.Count > 0)
                    {
                        BackupSelectedDatabases(connectionString, backupFolder, dateString, targetDbs);
                    }
                    else
                    {
                        BackupAllDatabases(connectionString, backupFolder, dateString);
                    }
                }
                else
                {
                    BackupAllDatabases(connectionString, backupFolder, dateString);
                }

                string zipFolder = Path.Combine(tblFolder.Text, "BackupSQL", dateString);
                if (!Directory.Exists(zipFolder))
                {
                    Directory.CreateDirectory(zipFolder);
                }

                // Nén file và lấy danh sách file zip đã tạo
                List<string> zipFiles = CompressBackupFiles(backupFolder, zipFolder);

                // Xóa các tệp chi tiết đã được nén
                Directory.Delete(backupFolder, true);
                LogInfo($"Backup and compression completed successfully for {dateString}");

                // Upload lên Google Drive
                if (!string.IsNullOrEmpty(txtDriveFolderName.Text))
                {
                    LogInfo("Starting upload to Google Drive...");
                    try
                    {
                        string folderId = await driveHelper.GetOrCreateFolder(txtDriveFolderName.Text);
                        LogInfo($"Target Drive Folder: '{txtDriveFolderName.Text}' (ID: {folderId})");

                        foreach (var zipFilePath in zipFiles)
                        {
                            try
                            {
                                string fileName = Path.GetFileName(zipFilePath);
                                await driveHelper.UploadOrUpdateFile(zipFilePath, fileName, folderId);
                                LogInfo($"Uploaded/Updated file to Drive: {fileName}");
                            }
                            catch (Exception ex)
                            {
                                LogError($"Error uploading file {zipFilePath}: {ex.Message}");
                            }
                        }
                        LogInfo("Google Drive upload process finished.");
                    }
                    catch (Exception ex)
                    {
                        LogError($"Error preparing Drive folder: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error backing up database: {ex.Message}");
            }
        }

        private async void OnBackupEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                await Backup();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }

            // Cập nhật thời gian tiếp theo
            backupTimer.Interval = TimeSpan.FromHours(12).TotalMilliseconds;
        }

        private void OnCleanupEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                DeleteOldBackupFolders(Path.Combine(tblFolder.Text, "BackupSQL"), 7);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }

            // Cập nhật thời gian tiếp theo
            cleanupTimer.Interval = TimeSpan.FromHours(24).TotalMilliseconds;
        }

        private void DeleteOldBackupFolders(string rootFolder, int days)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(rootFolder);
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    try
                    {
                        if (DateTime.Now - directory.CreationTime > TimeSpan.FromDays(days) && directory.Name != "Details")
                        {
                            if ((directory.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                            {
                                directory.Attributes = FileAttributes.Normal;
                            }

                            directory.Delete(true);
                            LogInfo($"Deleted old backup folder: {directory.FullName}");
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        LogError($"Access denied to the path '{directory.FullName}': {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        LogError($"Error deleting folder '{directory.FullName}': {ex.Message}");
                    }
                }
                LogInfo("Old backup folders cleanup completed.");
            }
            catch (Exception ex)
            {
                LogError($"Error deleting old backup folders: {ex.Message}");
            }
        }

        private string GetConnectionString(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("AppConfig.xml");
            XmlNode node = xmlDoc.SelectSingleNode($"/configuration/connectionStrings/add[@name='{name}']");
            if (node != null)
            {
                return node.Attributes["connectionString"].Value;
            }
            throw new Exception($"Connection string '{name}' not found.");
        }

        private void SaveConnectionString(string name, string connectionString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("AppConfig.xml");
            XmlNode node = xmlDoc.SelectSingleNode($"/configuration/connectionStrings/add[@name='{name}']");
            if (node == null)
            {
                XmlNode connStringsNode = xmlDoc.SelectSingleNode("/configuration/connectionStrings");
                if (connStringsNode == null)
                {
                    connStringsNode = xmlDoc.CreateElement("connectionStrings");
                    xmlDoc.DocumentElement.AppendChild(connStringsNode);
                }
                XmlElement elem = xmlDoc.CreateElement("add");
                elem.SetAttribute("name", name);
                elem.SetAttribute("connectionString", connectionString);
                connStringsNode.AppendChild(elem);
            }
            else
            {
                node.Attributes["connectionString"].Value = connectionString;
            }
            xmlDoc.Save("AppConfig.xml");
        }

        private string GetConfigValue(string key)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("AppConfig.xml");
                XmlNode node = xmlDoc.SelectSingleNode($"/configuration/appSettings/add[@key='{key}']");
                return node?.Attributes["value"]?.Value ?? "";
            }
            catch
            {
                return "";
            }
        }

        private void LoadDbConfigToFields()
        {
            try
            {
                var conn = GetConnectionString("DefaultConnection");
                var dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (var part in conn.Split(';'))
                {
                    if (string.IsNullOrWhiteSpace(part)) continue;
                    var kv = part.Split('=', 2);
                    if (kv.Length == 2)
                    {
                        var key = kv[0].Trim();
                        var val = kv[1].Trim();
                        dict[key] = val;
                    }
                }
                string server = dict.ContainsKey("Server") ? dict["Server"] : (dict.ContainsKey("Data Source") ? dict["Data Source"] : "");
                string user = dict.ContainsKey("User Id") ? dict["User Id"] : (dict.ContainsKey("Uid") ? dict["Uid"] : "");
                string password = dict.ContainsKey("Password") ? dict["Password"] : (dict.ContainsKey("Pwd") ? dict["Pwd"] : "");
                txtDbServer.Text = server;
                txtDbUser.Text = user;
                txtDbPassword.Text = password;
                currentDbPassword = password;
            }
            catch
            {
            }
        }
        private void SaveConfigValue(string key, string value)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("AppConfig.xml");
                XmlNode node = xmlDoc.SelectSingleNode($"/configuration/appSettings/add[@key='{key}']");
                if (node == null)
                {
                    // Nếu chưa có thì tạo mới (dù đã add tay vào file xml rồi nhưng cứ phòng hờ)
                    XmlNode appSettingsNode = xmlDoc.SelectSingleNode("/configuration/appSettings");
                    if (appSettingsNode == null)
                    {
                        appSettingsNode = xmlDoc.CreateElement("appSettings");
                        xmlDoc.DocumentElement.AppendChild(appSettingsNode);
                    }
                    XmlElement elem = xmlDoc.CreateElement("add");
                    elem.SetAttribute("key", key);
                    elem.SetAttribute("value", value);
                    appSettingsNode.AppendChild(elem);
                }
                else
                {
                    node.Attributes["value"].Value = value;
                }
                xmlDoc.Save("AppConfig.xml");
            }
            catch (Exception ex)
            {
                LogError($"Error saving config: {ex.Message}");
            }
        }

        private void BackupAllDatabases(string connectionString, string backupRootFolder, string dateString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb')", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    var databaseNames = new List<string>();
                    while (reader.Read())
                    {
                        databaseNames.Add(reader["name"].ToString());
                    }
                    reader.Close();

                    foreach (var databaseName in databaseNames)
                    {
                        try
                        {
                            string backupFileName = Path.Combine(backupRootFolder, $"{databaseName}_{dateString}.bak");
                            string backupQuery = $"BACKUP DATABASE [{databaseName}] TO DISK='{backupFileName}'";

                            using (SqlCommand backupCommand = new SqlCommand(backupQuery, connection))
                            {
                                backupCommand.ExecuteNonQuery();
                            }
                            LogInfo($"Database {databaseName} backed up successfully.");
                        }
                        catch (Exception ex)
                        {
                            LogError($"Error backing up database {databaseName}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error during backup process: {ex.Message}");
            }
        }

        private void BackupSelectedDatabases(string connectionString, string backupRootFolder, string dateString, List<string> databaseNames)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (var databaseName in databaseNames)
                    {
                        try
                        {
                            using (SqlCommand existsCmd = new SqlCommand("SELECT COUNT(1) FROM sys.databases WHERE name = @name", connection))
                            {
                                existsCmd.Parameters.AddWithValue("@name", databaseName);
                                var exists = (int)existsCmd.ExecuteScalar() > 0;
                                if (!exists)
                                {
                                    LogError($"Database '{databaseName}' không tồn tại.");
                                    continue;
                                }
                            }

                            string backupFileName = Path.Combine(backupRootFolder, $"{databaseName}_{dateString}.bak");
                            string backupQuery = $"BACKUP DATABASE [{databaseName}] TO DISK='{backupFileName}'";

                            using (SqlCommand backupCommand = new SqlCommand(backupQuery, connection))
                            {
                                backupCommand.ExecuteNonQuery();
                            }
                            LogInfo($"Database {databaseName} backed up successfully.");
                        }
                        catch (Exception ex)
                        {
                            LogError($"Error backing up database {databaseName}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error during backup process: {ex.Message}");
            }
        }

        private List<string> CompressBackupFiles(string sourceFolder, string endFolder)
        {
            string[] backupFiles = Directory.GetFiles(sourceFolder, "*.bak");
            var compressedFiles = new List<string>();

            foreach (string backupFile in backupFiles)
            {
                // Thay đổi tên file theo Thứ trong tuần: DBName_Monday.zip
                string dbName = Path.GetFileNameWithoutExtension(backupFile).Split('_')[0]; // Giả định format tên là DBName_Date.bak
                                                                                            // Nếu tên db có chứa dấu _ thì có thể sai, nên lấy substring đến trước _ cuối cùng thì an toàn hơn, 
                                                                                            // nhưng ở BackupAllDatabases đang lưu là $"{databaseName}_{dateString}.bak".
                                                                                            // dateString là yyyyMMdd (8 ký tự).

                string originalFileName = Path.GetFileNameWithoutExtension(backupFile);
                string realDbName = originalFileName.Substring(0, originalFileName.Length - 9); // Bỏ _yyyyMMdd

                string dayOfWeek = DateTime.Now.DayOfWeek.ToString();
                string zipFileName = $"{realDbName}_{dayOfWeek}.zip";

                string zipFilePath = Path.Combine(endFolder, zipFileName);

                using (FileStream zipFile = new FileStream(zipFilePath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(backupFile, Path.GetFileName(backupFile));
                    }
                }

                // Xóa tệp backup đã được nén
                File.Delete(backupFile);
                LogInfo($"File {backupFile} compressed to {zipFileName}");

                compressedFiles.Add(zipFilePath);
            }
            return compressedFiles;
        }

        private void LogInfo(string message)
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action<string>(LogInfo), message);
            }
            else
            {
                rtbLog.AppendText($"{DateTime.Now} [INFO]: {message}\n");
                log.Info(message);
            }
        }

        private void LogError(string message)
        {
            if (rtdFail.InvokeRequired)
            {
                rtdFail.Invoke(new Action<string>(LogError), message);
            }
            else
            {
                rtdFail.AppendText($"{DateTime.Now} [ERROR]: {message}\n");
                log.Error(message);
            }
        }

        private void OpenLogFile()
        {
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = logFilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                LogError($"Error opening log file: {ex.Message}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await Backup();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    tblFolder.Text = selectedFolder;
                    rtbLog.AppendText($"{DateTime.Now} [INFO]: Select folder {selectedFolder}\n");
                    log.Info($"Selected folder: {selectedFolder}");
                }
            }
        }

        private void btnDeleteFolder_Click(object sender, EventArgs e)
        {
            DeleteOldBackupFolders(Path.Combine(tblFolder.Text, "BackupSQL"), 7);
        }

        private void btnOpenLogFile_Click(object sender, EventArgs e)
        {
            OpenLogFile();
        }

        private void dbTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDbPassword_Click(object sender, EventArgs e)
        {

        }

        private void dbTable_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void SetupFileBackupTimer()
        {
            try 
            {
                DateTime now = DateTime.Now;
                // Find next Wednesday
                int daysUntilWed = ((int)DayOfWeek.Wednesday - (int)now.DayOfWeek + 7) % 7;
                DateTime nextWed = now.Date.AddDays(daysUntilWed).AddHours(4); // 4:00 AM

                if (nextWed <= now)
                {
                    nextWed = nextWed.AddDays(7);
                }

                double interval = (nextWed - now).TotalMilliseconds;
                
                if (fileBackupTimer == null)
                {
                    fileBackupTimer = new System.Timers.Timer();
                    fileBackupTimer.Elapsed += async (s, e) => await PerformFileBackup(true);
                    fileBackupTimer.AutoReset = false; 
                }
                
                fileBackupTimer.Interval = interval;
                fileBackupTimer.Start();
                LogInfo($"Lên lịch backup file folder (thứ 4 - 4h sáng) vào: {nextWed.ToString("dd/MM/yyyy HH:mm:ss")}");
            }
            catch (Exception ex)
            {
                LogError($"Lỗi SetupFileBackupTimer: {ex.Message}");
            }
        }

        private async Task PerformFileBackup(bool isAuto)
        {
            string localFolder = txtLocalFolder.Text.Trim();
            if (string.IsNullOrEmpty(localFolder) || !Directory.Exists(localFolder))
            {
                string msg = "Thư mục backup file không hợp lệ hoặc chưa được chọn.";
                if (!isAuto) MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogError(msg);
                if (isAuto) RescheduleFileBackup();
                return;
            }

            string driveFolderName = txtDriveFolderName.Text.Trim();
            if (string.IsNullOrEmpty(driveFolderName))
            {
                string msg = "Chưa cấu hình tên thư mục trên Google Drive.";
                if (!isAuto) MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LogError(msg);
                if (isAuto) RescheduleFileBackup();
                return;
            }

            try
            {
                if (!isAuto) this.Invoke((MethodInvoker)delegate { btnLocalBackup.Enabled = false; });
                LogInfo($"Bắt đầu backup thư mục: {localFolder}");

                if (!driveHelper.IsConnected)
                {
                    await driveHelper.Authenticate();
                }

                string rootId = await driveHelper.GetOrCreateFolder(driveFolderName);

                var files = Directory.GetFiles(localFolder, "*", SearchOption.AllDirectories);
                int count = 0;
                int total = files.Length;

                foreach (var file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string relPath = Path.GetRelativePath(localFolder, file);
                    string relDir = Path.GetDirectoryName(relPath) ?? "";
                    LogInfo($"Đang xử lý file ({++count}/{total}): {relPath} ...");
                    
                    var fi = new FileInfo(file);
                    string contentType = "application/octet-stream";
                    
                    string ext = fi.Extension.ToLower();
                    if (ext == ".jpg" || ext == ".jpeg") contentType = "image/jpeg";
                    else if (ext == ".png") contentType = "image/png";
                    else if (ext == ".zip") contentType = "application/zip";
                    else if (ext == ".pdf") contentType = "application/pdf";
                    else if (ext == ".mp4") contentType = "video/mp4";

                    string parentId = rootId;
                    if (!string.IsNullOrWhiteSpace(relDir))
                    {
                        var segments = relDir.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var segment in segments)
                        {
                            parentId = await driveHelper.GetOrCreateFolder(segment, parentId);
                        }
                    }

                    var existingFile = await driveHelper.GetFileByName(fileName, parentId);
                    if (existingFile != null && existingFile.Size.HasValue && existingFile.Size.Value == fi.Length)
                    {
                        LogInfo($"Bỏ qua vì trùng kích thước: {relPath}");
                        continue;
                    }

                    await driveHelper.UploadOrUpdateFile(file, fileName, parentId, contentType);
                    LogInfo($"Upload thành công: {relPath}");
                }

                LogInfo("Backup thư mục hoàn tất!");
                if (!isAuto) MessageBox.Show("Backup thư mục hoàn tất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError($"Lỗi backup thư mục: {ex.Message}");
                if (!isAuto) MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!isAuto) this.Invoke((MethodInvoker)delegate { btnLocalBackup.Enabled = true; });
                if (isAuto) RescheduleFileBackup();
            }
        }

        private void RescheduleFileBackup()
        {
            // Reset timer for next week
            fileBackupTimer.Interval = TimeSpan.FromDays(7).TotalMilliseconds;
            fileBackupTimer.Start();
            LogInfo($"Đã lên lịch backup file tiếp theo sau 7 ngày.");
        }

        private void BtnSelectLocalFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtLocalFolder.Text = fbd.SelectedPath;
                    SaveConfigValue("LocalBackupFolder", fbd.SelectedPath);
                }
            }
        }

        private async void BtnLocalBackup_Click(object sender, EventArgs e)
        {
            await PerformFileBackup(false);
        }
    }
}
