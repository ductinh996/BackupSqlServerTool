using System.Data.SqlClient;
using System.IO.Compression;
using System.Timers;
using System.Xml;

namespace BackupSqlServerTool
{
    public partial class MainForm : Form
    {
        private System.Timers.Timer backupTimer;

        public MainForm()
        {
            InitializeComponent();
            backupTimer = new System.Timers.Timer();
            backupTimer.Elapsed += OnTimedEvent;
            backupTimer.AutoReset = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DateTime scheduledTime = DateTime.Today.AddHours(23); // 23h hàng ngày
            if (DateTime.Now > scheduledTime)
            {
                scheduledTime = scheduledTime.AddDays(1);
            }
            double interval = (scheduledTime - DateTime.Now).TotalMilliseconds;
            backupTimer.Interval = interval;
            backupTimer.Start();
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

                // Xoá các tệp chi tiết đã được nén
                Directory.Delete(backupFolder, true);

            }
            catch (Exception e)
            {

            }

        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {

            Backup();

            // Cập nhật thời gian tiếp theo
            backupTimer.Interval = TimeSpan.FromDays(1).TotalMilliseconds;
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
                        }
                        catch (Exception)
                        {

                        }

                    }
                }

            }
            catch (Exception e)
            {

            }

        }

        private void CompressBackupFiles(string sourceFolder, string endFolder)
        {
            string[] backupFiles = Directory.GetFiles(sourceFolder, "*.bak");

            foreach (string backupFile in backupFiles)
            {
                string zipFileName = Path.GetFileNameWithoutExtension(backupFile) + "_" + DateTime.Now.ToString("hhMMss") + ".zip";
                string zipFilePath = Path.Combine(endFolder, zipFileName);

                using (FileStream zipFile = new FileStream(zipFilePath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
                    {
                        rtbLog.Text = rtbLog.Text.Insert(0, $"Backup db {zipFileName} \n");

                        archive.CreateEntryFromFile(backupFile, Path.GetFileName(backupFile));
                    }
                }

                // Xoá tệp backup đã được nén
                File.Delete(backupFile);
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
                    rtbLog.Text = rtbLog.Text.Insert(0, $"Select folder {selectedFolder} \n");
                }
            }
        }
    }
}
