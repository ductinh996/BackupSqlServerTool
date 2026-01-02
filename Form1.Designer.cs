namespace BackupSqlServerTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbl = new TableLayoutPanel();
            rtbLog = new RichTextBox();
            tblFolder = new TextBox();
            Folder = new Label();
            btnSelectFolder = new Button();
            label4 = new Label();
            btnUpdate = new Button();
            rtdFail = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            btnDeleteFolder = new Button();
            btnOpenLog = new Button();
            grpDbConfig = new GroupBox();
            dbTable = new TableLayoutPanel();
            lblDbServer = new Label();
            txtDbServer = new TextBox();
            lblDbUser = new Label();
            txtDbUser = new TextBox();
            lblDbPassword = new Label();
            txtDbPassword = new TextBox();
            btnSaveDbConfig = new Button();
            grpGoogleDrive = new GroupBox();
            driveTable = new TableLayoutPanel();
            lblFolderId = new Label();
            txtDriveFolderName = new TextBox();
            btnLoginDrive = new Button();
            lblDriveStatus = new Label();
            lblDbList = new Label();
            txtDbList = new TextBox();
            grpLocalBackup = new GroupBox();
            localBackupTable = new TableLayoutPanel();
            lblLocalFolder = new Label();
            txtLocalFolder = new TextBox();
            btnSelectLocalFolder = new Button();
            btnLocalBackup = new Button();
            label1 = new Label();
            label5 = new Label();
            tbl.SuspendLayout();
            grpDbConfig.SuspendLayout();
            dbTable.SuspendLayout();
            grpGoogleDrive.SuspendLayout();
            driveTable.SuspendLayout();
            grpLocalBackup.SuspendLayout();
            localBackupTable.SuspendLayout();
            SuspendLayout();
            // 
            // tbl
            // 
            tbl.BackColor = SystemColors.ControlLight;
            tbl.ColumnCount = 3;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl.Controls.Add(rtbLog, 1, 2);
            tbl.Controls.Add(tblFolder, 1, 3);
            tbl.Controls.Add(Folder, 0, 3);
            tbl.Controls.Add(btnSelectFolder, 2, 3);
            tbl.Controls.Add(label4, 0, 2);
            tbl.Controls.Add(btnUpdate, 1, 7);
            tbl.Controls.Add(rtdFail, 2, 2);
            tbl.Controls.Add(label2, 1, 1);
            tbl.Controls.Add(label3, 2, 1);
            tbl.Controls.Add(btnDeleteFolder, 2, 7);
            tbl.Controls.Add(btnOpenLog, 0, 7);
            tbl.Controls.Add(grpDbConfig, 1, 4);
            tbl.Controls.Add(grpGoogleDrive, 1, 5);
            tbl.Controls.Add(grpLocalBackup, 1, 6);
            tbl.Controls.Add(label1, 0, 0);
            tbl.Controls.Add(label5, 2, 0);
            tbl.Dock = DockStyle.Fill;
            tbl.Location = new Point(0, 0);
            tbl.Margin = new Padding(3, 4, 3, 4);
            tbl.Name = "tbl";
            tbl.RowCount = 8;
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 187F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 107F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tbl.Size = new Size(1190, 933);
            tbl.TabIndex = 6;
            // 
            // rtbLog
            // 
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rtbLog.Location = new Point(203, 108);
            rtbLog.Margin = new Padding(3, 4, 3, 4);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(489, 261);
            rtbLog.TabIndex = 8;
            rtbLog.Text = "";
            // 
            // tblFolder
            // 
            tblFolder.Dock = DockStyle.Fill;
            tblFolder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            tblFolder.Location = new Point(203, 377);
            tblFolder.Margin = new Padding(3, 4, 3, 4);
            tblFolder.Name = "tblFolder";
            tblFolder.Size = new Size(489, 39);
            tblFolder.TabIndex = 9;
            tblFolder.Text = "C:\\BackupSQL";
            // 
            // Folder
            // 
            Folder.AutoSize = true;
            Folder.Dock = DockStyle.Fill;
            Folder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            Folder.Location = new Point(3, 373);
            Folder.Name = "Folder";
            Folder.Size = new Size(194, 83);
            Folder.TabIndex = 10;
            Folder.Text = "Save Folder";
            Folder.TextAlign = ContentAlignment.TopRight;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.BackColor = Color.FromArgb(255, 128, 0);
            btnSelectFolder.FlatStyle = FlatStyle.Flat;
            btnSelectFolder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnSelectFolder.ForeColor = Color.White;
            btnSelectFolder.Location = new Point(698, 377);
            btnSelectFolder.Margin = new Padding(3, 4, 3, 4);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(40, 45);
            btnSelectFolder.TabIndex = 11;
            btnSelectFolder.UseVisualStyleBackColor = false;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            label4.Location = new Point(3, 104);
            label4.Name = "label4";
            label4.Size = new Size(194, 269);
            label4.TabIndex = 12;
            label4.Text = "Clear folder Obj if build fail";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.MenuHighlight;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(203, 857);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(185, 64);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Backup Now";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // rtdFail
            // 
            rtdFail.Dock = DockStyle.Fill;
            rtdFail.Location = new Point(698, 107);
            rtdFail.Name = "rtdFail";
            rtdFail.Size = new Size(489, 263);
            rtdFail.TabIndex = 14;
            rtdFail.Text = "";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(203, 53);
            label2.Name = "label2";
            label2.Size = new Size(489, 51);
            label2.TabIndex = 15;
            label2.Text = "SUCESS";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(698, 53);
            label3.Name = "label3";
            label3.Size = new Size(489, 51);
            label3.TabIndex = 16;
            label3.Text = "ERROR";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDeleteFolder
            // 
            btnDeleteFolder.BackColor = Color.Red;
            btnDeleteFolder.FlatStyle = FlatStyle.Flat;
            btnDeleteFolder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnDeleteFolder.ForeColor = Color.White;
            btnDeleteFolder.Location = new Point(698, 857);
            btnDeleteFolder.Margin = new Padding(3, 4, 3, 4);
            btnDeleteFolder.Name = "btnDeleteFolder";
            btnDeleteFolder.Size = new Size(185, 64);
            btnDeleteFolder.TabIndex = 13;
            btnDeleteFolder.Text = "Del Folder";
            btnDeleteFolder.UseVisualStyleBackColor = false;
            btnDeleteFolder.Click += btnDeleteFolder_Click;
            // 
            // btnOpenLog
            // 
            btnOpenLog.BackColor = Color.Silver;
            btnOpenLog.FlatStyle = FlatStyle.Flat;
            btnOpenLog.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnOpenLog.ForeColor = Color.White;
            btnOpenLog.Location = new Point(3, 857);
            btnOpenLog.Margin = new Padding(3, 4, 3, 4);
            btnOpenLog.Name = "btnOpenLog";
            btnOpenLog.Size = new Size(185, 64);
            btnOpenLog.TabIndex = 17;
            btnOpenLog.Text = "Open Log";
            btnOpenLog.UseVisualStyleBackColor = false;
            btnOpenLog.Click += btnOpenLogFile_Click;
            // 
            // grpDbConfig
            // 
            tbl.SetColumnSpan(grpDbConfig, 2);
            grpDbConfig.Controls.Add(dbTable);
            grpDbConfig.Dock = DockStyle.Fill;
            grpDbConfig.Location = new Point(203, 460);
            grpDbConfig.Margin = new Padding(3, 4, 3, 4);
            grpDbConfig.Name = "grpDbConfig";
            grpDbConfig.Padding = new Padding(3, 4, 3, 4);
            grpDbConfig.Size = new Size(984, 95);
            grpDbConfig.TabIndex = 18;
            grpDbConfig.TabStop = false;
            grpDbConfig.Text = "SQL Server Configuration";
            // 
            // dbTable
            // 
            dbTable.ColumnCount = 7;
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 69F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 57F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            dbTable.Controls.Add(lblDbServer, 0, 0);
            dbTable.Controls.Add(txtDbServer, 1, 0);
            dbTable.Controls.Add(lblDbUser, 2, 0);
            dbTable.Controls.Add(txtDbUser, 3, 0);
            dbTable.Controls.Add(lblDbPassword, 4, 0);
            dbTable.Controls.Add(txtDbPassword, 5, 0);
            dbTable.Controls.Add(btnSaveDbConfig, 6, 0);
            dbTable.Dock = DockStyle.Fill;
            dbTable.Location = new Point(3, 24);
            dbTable.Margin = new Padding(3, 4, 3, 4);
            dbTable.Name = "dbTable";
            dbTable.RowCount = 1;
            dbTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            dbTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            dbTable.Size = new Size(978, 67);
            dbTable.TabIndex = 0;
            dbTable.Paint += dbTable_Paint_1;
            // 
            // lblDbServer
            // 
            lblDbServer.AutoSize = true;
            lblDbServer.Dock = DockStyle.Fill;
            lblDbServer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDbServer.Location = new Point(3, 0);
            lblDbServer.Name = "lblDbServer";
            lblDbServer.Size = new Size(63, 67);
            lblDbServer.TabIndex = 0;
            lblDbServer.Text = "Server";
            lblDbServer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDbServer
            // 
            txtDbServer.Dock = DockStyle.Fill;
            txtDbServer.Font = new Font("Segoe UI", 10F);
            txtDbServer.Location = new Point(72, 13);
            txtDbServer.Margin = new Padding(3, 13, 3, 4);
            txtDbServer.Name = "txtDbServer";
            txtDbServer.Size = new Size(184, 30);
            txtDbServer.TabIndex = 1;
            // 
            // lblDbUser
            // 
            lblDbUser.AutoSize = true;
            lblDbUser.Dock = DockStyle.Fill;
            lblDbUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDbUser.Location = new Point(262, 0);
            lblDbUser.Name = "lblDbUser";
            lblDbUser.Size = new Size(51, 67);
            lblDbUser.TabIndex = 2;
            lblDbUser.Text = "User";
            lblDbUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDbUser
            // 
            txtDbUser.Dock = DockStyle.Fill;
            txtDbUser.Font = new Font("Segoe UI", 10F);
            txtDbUser.Location = new Point(319, 13);
            txtDbUser.Margin = new Padding(3, 13, 3, 4);
            txtDbUser.Name = "txtDbUser";
            txtDbUser.Size = new Size(184, 30);
            txtDbUser.TabIndex = 3;
            // 
            // lblDbPassword
            // 
            lblDbPassword.Dock = DockStyle.Fill;
            lblDbPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDbPassword.Location = new Point(509, 0);
            lblDbPassword.Name = "lblDbPassword";
            lblDbPassword.Size = new Size(85, 67);
            lblDbPassword.TabIndex = 4;
            lblDbPassword.Text = "Pass";
            lblDbPassword.TextAlign = ContentAlignment.MiddleCenter;
            lblDbPassword.Click += lblDbPassword_Click;
            // 
            // txtDbPassword
            // 
            txtDbPassword.Dock = DockStyle.Fill;
            txtDbPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDbPassword.Location = new Point(600, 13);
            txtDbPassword.Margin = new Padding(3, 13, 3, 4);
            txtDbPassword.Name = "txtDbPassword";
            txtDbPassword.Size = new Size(222, 29);
            txtDbPassword.TabIndex = 5;
            // 
            // btnSaveDbConfig
            // 
            btnSaveDbConfig.BackColor = Color.SteelBlue;
            btnSaveDbConfig.Dock = DockStyle.Fill;
            btnSaveDbConfig.FlatStyle = FlatStyle.Flat;
            btnSaveDbConfig.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveDbConfig.ForeColor = Color.White;
            btnSaveDbConfig.Location = new Point(828, 4);
            btnSaveDbConfig.Margin = new Padding(3, 4, 3, 4);
            btnSaveDbConfig.Name = "btnSaveDbConfig";
            btnSaveDbConfig.Size = new Size(147, 59);
            btnSaveDbConfig.TabIndex = 7;
            btnSaveDbConfig.Text = "Kết nối && Lưu";
            btnSaveDbConfig.UseVisualStyleBackColor = false;
            btnSaveDbConfig.Click += BtnSaveDbConfig_Click;
            // 
            // grpGoogleDrive
            // 
            tbl.SetColumnSpan(grpGoogleDrive, 2);
            grpGoogleDrive.Controls.Add(driveTable);
            grpGoogleDrive.Dock = DockStyle.Fill;
            grpGoogleDrive.Location = new Point(203, 563);
            grpGoogleDrive.Margin = new Padding(3, 4, 3, 4);
            grpGoogleDrive.Name = "grpGoogleDrive";
            grpGoogleDrive.Padding = new Padding(3, 4, 3, 4);
            grpGoogleDrive.Size = new Size(984, 179);
            grpGoogleDrive.TabIndex = 19;
            grpGoogleDrive.TabStop = false;
            grpGoogleDrive.Text = "Google Drive Configuration";
            // 
            // driveTable
            // 
            driveTable.ColumnCount = 3;
            driveTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            driveTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            driveTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 171F));
            driveTable.Controls.Add(lblFolderId, 0, 0);
            driveTable.Controls.Add(txtDriveFolderName, 1, 0);
            driveTable.Controls.Add(btnLoginDrive, 2, 0);
            driveTable.Controls.Add(lblDriveStatus, 0, 1);
            driveTable.Controls.Add(lblDbList, 0, 2);
            driveTable.Controls.Add(txtDbList, 1, 2);
            driveTable.Dock = DockStyle.Fill;
            driveTable.Location = new Point(3, 24);
            driveTable.Margin = new Padding(3, 4, 3, 4);
            driveTable.Name = "driveTable";
            driveTable.RowCount = 3;
            driveTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            driveTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            driveTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            driveTable.Size = new Size(978, 151);
            driveTable.TabIndex = 0;
            // 
            // lblFolderId
            // 
            lblFolderId.AutoSize = true;
            lblFolderId.Dock = DockStyle.Fill;
            lblFolderId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFolderId.Location = new Point(3, 0);
            lblFolderId.Name = "lblFolderId";
            lblFolderId.Size = new Size(108, 53);
            lblFolderId.TabIndex = 0;
            lblFolderId.Text = "Tên Thư Mục";
            lblFolderId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDriveFolderName
            // 
            txtDriveFolderName.Dock = DockStyle.Fill;
            txtDriveFolderName.Font = new Font("Segoe UI", 10F);
            txtDriveFolderName.Location = new Point(117, 11);
            txtDriveFolderName.Margin = new Padding(3, 11, 3, 4);
            txtDriveFolderName.Name = "txtDriveFolderName";
            txtDriveFolderName.Size = new Size(687, 30);
            txtDriveFolderName.TabIndex = 1;
            txtDriveFolderName.TextChanged += TxtDriveFolderName_TextChanged;
            // 
            // btnLoginDrive
            // 
            btnLoginDrive.BackColor = Color.ForestGreen;
            btnLoginDrive.Dock = DockStyle.Fill;
            btnLoginDrive.FlatStyle = FlatStyle.Flat;
            btnLoginDrive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLoginDrive.ForeColor = Color.White;
            btnLoginDrive.Location = new Point(810, 4);
            btnLoginDrive.Margin = new Padding(3, 4, 3, 4);
            btnLoginDrive.Name = "btnLoginDrive";
            btnLoginDrive.Size = new Size(165, 45);
            btnLoginDrive.TabIndex = 2;
            btnLoginDrive.Text = "Kết nối Drive";
            btnLoginDrive.UseVisualStyleBackColor = false;
            btnLoginDrive.Click += BtnLoginDrive_Click;
            // 
            // lblDriveStatus
            // 
            lblDriveStatus.AutoSize = true;
            driveTable.SetColumnSpan(lblDriveStatus, 3);
            lblDriveStatus.Dock = DockStyle.Fill;
            lblDriveStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblDriveStatus.ForeColor = Color.Gray;
            lblDriveStatus.Location = new Point(3, 53);
            lblDriveStatus.Name = "lblDriveStatus";
            lblDriveStatus.Size = new Size(972, 40);
            lblDriveStatus.TabIndex = 3;
            lblDriveStatus.Text = "Trạng thái: Chưa kết nối";
            lblDriveStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDbList
            // 
            lblDbList.AutoSize = true;
            lblDbList.Dock = DockStyle.Fill;
            lblDbList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDbList.Location = new Point(3, 93);
            lblDbList.Name = "lblDbList";
            lblDbList.Size = new Size(108, 58);
            lblDbList.TabIndex = 4;
            lblDbList.Text = "DB Chỉ định";
            lblDbList.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDbList
            // 
            driveTable.SetColumnSpan(txtDbList, 2);
            txtDbList.Dock = DockStyle.Fill;
            txtDbList.Font = new Font("Segoe UI", 10F);
            txtDbList.Location = new Point(117, 104);
            txtDbList.Margin = new Padding(3, 11, 3, 4);
            txtDbList.Name = "txtDbList";
            txtDbList.Size = new Size(858, 30);
            txtDbList.TabIndex = 5;
            txtDbList.TextChanged += TxtDbList_TextChanged;
            // 
            // grpLocalBackup
            // 
            tbl.SetColumnSpan(grpLocalBackup, 2);
            grpLocalBackup.Controls.Add(localBackupTable);
            grpLocalBackup.Dock = DockStyle.Fill;
            grpLocalBackup.Location = new Point(203, 750);
            grpLocalBackup.Margin = new Padding(3, 4, 3, 4);
            grpLocalBackup.Name = "grpLocalBackup";
            grpLocalBackup.Padding = new Padding(3, 4, 3, 4);
            grpLocalBackup.Size = new Size(984, 99);
            grpLocalBackup.TabIndex = 20;
            grpLocalBackup.TabStop = false;
            grpLocalBackup.Text = "Backup Thư Mục (Ảnh/File Lớn)";
            // 
            // localBackupTable
            // 
            localBackupTable.ColumnCount = 4;
            localBackupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            localBackupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            localBackupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            localBackupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 171F));
            localBackupTable.Controls.Add(lblLocalFolder, 0, 0);
            localBackupTable.Controls.Add(txtLocalFolder, 1, 0);
            localBackupTable.Controls.Add(btnSelectLocalFolder, 2, 0);
            localBackupTable.Controls.Add(btnLocalBackup, 3, 0);
            localBackupTable.Dock = DockStyle.Fill;
            localBackupTable.Location = new Point(3, 24);
            localBackupTable.Margin = new Padding(3, 4, 3, 4);
            localBackupTable.Name = "localBackupTable";
            localBackupTable.RowCount = 1;
            localBackupTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            localBackupTable.Size = new Size(978, 71);
            localBackupTable.TabIndex = 0;
            // 
            // lblLocalFolder
            // 
            lblLocalFolder.AutoSize = true;
            lblLocalFolder.Dock = DockStyle.Fill;
            lblLocalFolder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLocalFolder.Location = new Point(3, 0);
            lblLocalFolder.Name = "lblLocalFolder";
            lblLocalFolder.Size = new Size(108, 71);
            lblLocalFolder.TabIndex = 0;
            lblLocalFolder.Text = "Thư Mục";
            lblLocalFolder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLocalFolder
            // 
            txtLocalFolder.Dock = DockStyle.Fill;
            txtLocalFolder.Font = new Font("Segoe UI", 10F);
            txtLocalFolder.Location = new Point(117, 16);
            txtLocalFolder.Margin = new Padding(3, 16, 3, 4);
            txtLocalFolder.Name = "txtLocalFolder";
            txtLocalFolder.Size = new Size(641, 30);
            txtLocalFolder.TabIndex = 1;
            // 
            // btnSelectLocalFolder
            // 
            btnSelectLocalFolder.BackColor = Color.Orange;
            btnSelectLocalFolder.Dock = DockStyle.Fill;
            btnSelectLocalFolder.FlatStyle = FlatStyle.Flat;
            btnSelectLocalFolder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSelectLocalFolder.ForeColor = Color.White;
            btnSelectLocalFolder.Location = new Point(764, 4);
            btnSelectLocalFolder.Margin = new Padding(3, 4, 3, 4);
            btnSelectLocalFolder.Name = "btnSelectLocalFolder";
            btnSelectLocalFolder.Size = new Size(40, 63);
            btnSelectLocalFolder.TabIndex = 2;
            btnSelectLocalFolder.Text = "...";
            btnSelectLocalFolder.UseVisualStyleBackColor = false;
            btnSelectLocalFolder.Click += BtnSelectLocalFolder_Click;
            // 
            // btnLocalBackup
            // 
            btnLocalBackup.BackColor = Color.Purple;
            btnLocalBackup.Dock = DockStyle.Fill;
            btnLocalBackup.FlatStyle = FlatStyle.Flat;
            btnLocalBackup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLocalBackup.ForeColor = Color.White;
            btnLocalBackup.Location = new Point(810, 4);
            btnLocalBackup.Margin = new Padding(3, 4, 3, 4);
            btnLocalBackup.Name = "btnLocalBackup";
            btnLocalBackup.Size = new Size(165, 63);
            btnLocalBackup.TabIndex = 3;
            btnLocalBackup.Text = "Backup Ngay";
            btnLocalBackup.UseVisualStyleBackColor = false;
            btnLocalBackup.Click += BtnLocalBackup_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(194, 53);
            label1.TabIndex = 7;
            label1.Text = "KIRA_BAUP";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DodgerBlue;
            label5.Location = new Point(698, 0);
            label5.Name = "label5";
            label5.Size = new Size(489, 53);
            label5.TabIndex = 21;
            label5.Text = "Ductinh996@gmail.com";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 933);
            Controls.Add(tbl);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Backup SQL Server";
            tbl.ResumeLayout(false);
            tbl.PerformLayout();
            grpDbConfig.ResumeLayout(false);
            dbTable.ResumeLayout(false);
            dbTable.PerformLayout();
            grpGoogleDrive.ResumeLayout(false);
            driveTable.ResumeLayout(false);
            driveTable.PerformLayout();
            grpLocalBackup.ResumeLayout(false);
            localBackupTable.ResumeLayout(false);
            localBackupTable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbl;
        private Label label1;
        private RichTextBox rtbLog;
        private Button btnUpdate;
        private TextBox tblFolder;
        private Label Folder;
        private Button btnSelectFolder;
        private Label label4;
        private Button btnDeleteFolder;
        private RichTextBox rtdFail;
        private Label label2;
        private Label label3;
        private Button btnOpenLog;
        private GroupBox grpDbConfig;
        private TableLayoutPanel dbTable;
        private Label lblDbServer;
        private TextBox txtDbServer;
        private Label lblDbUser;
        private TextBox txtDbUser;
        private Label lblDbPassword;
        private TextBox txtDbPassword;
        private Button btnSaveDbConfig;
        private GroupBox grpGoogleDrive;
        private TableLayoutPanel driveTable;
        private Label lblFolderId;
        private TextBox txtDriveFolderName;
        private Button btnLoginDrive;
        private Label lblDriveStatus;
        private Label lblDbList;
        private TextBox txtDbList;
        private GroupBox grpLocalBackup;
        private TableLayoutPanel localBackupTable;
        private Label lblLocalFolder;
        private TextBox txtLocalFolder;
        private Button btnSelectLocalFolder;
        private Button btnLocalBackup;
        private Label label5;
    }
}
