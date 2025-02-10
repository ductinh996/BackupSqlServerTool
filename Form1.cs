using log4net;
using log4net.Config;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO.Compression;
using System.Timers;
using System.Xml;

namespace BackupSqlServerTool
{
    public partial class MainForm : Form
    {
        private System.Timers.Timer backupTimer;
        private System.Timers.Timer cleanupTimer;
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

        public MainForm()
        {
            InitializeComponent();
            XmlConfigurator.Configure(new FileInfo("App.config")); // Hoặc sử dụng một file cấu hình riêng
            this.Load += MainForm_Load;
            backupTimer = new System.Timers.Timer();
            backupTimer.Elapsed += OnBackupEvent;
            backupTimer.AutoReset = true;

            cleanupTimer = new System.Timers.Timer();
            cleanupTimer.Elapsed += OnCleanupEvent;
            cleanupTimer.AutoReset = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
        }

        private void Backup()
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
                BackupAllDatabases(connectionString, backupFolder, dateString);

                string zipFolder = Path.Combine(tblFolder.Text, "BackupSQL", dateString);
                if (!Directory.Exists(zipFolder))
                {
                    Directory.CreateDirectory(zipFolder);
                }

                CompressBackupFiles(backupFolder, zipFolder);

                // Xóa các tệp chi tiết đã được nén
                Directory.Delete(backupFolder, true);
                LogInfo($"Backup and compression completed successfully for {dateString}");
            }
            catch (Exception ex)
            {
                LogError($"Error backing up database: {ex.Message}");
            }
        }

        private void OnBackupEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                Backup();
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
                            // Kiểm tra và xóa thuộc tính chỉ đọc nếu có
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
                    reader.Close(); // Đảm bảo rằng SqlDataReader được đóng trước khi thực hiện lệnh SQL khác

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

        private void CompressBackupFiles(string sourceFolder, string endFolder)
        {
            string[] backupFiles = Directory.GetFiles(sourceFolder, "*.bak");

            foreach (string backupFile in backupFiles)
            {
                string zipFileName = Path.GetFileNameWithoutExtension(backupFile) + "_" + DateTime.Now.ToString("HHmmss") + ".zip";
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
            }
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
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "logs"); // Đặt đường dẫn tới file log của bạn
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Backup();
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

    }
}
