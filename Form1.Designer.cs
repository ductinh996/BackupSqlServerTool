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
            label1 = new Label();
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
            tbl.SuspendLayout();
            grpDbConfig.SuspendLayout();
            dbTable.SuspendLayout();
            grpGoogleDrive.SuspendLayout();
            driveTable.SuspendLayout();
            SuspendLayout();
            // 
            // tbl
            // 
            tbl.BackColor = SystemColors.ControlLight;
            tbl.ColumnCount = 3;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl.Controls.Add(label1, 1, 0);
            tbl.Controls.Add(rtbLog, 1, 2);
            tbl.Controls.Add(tblFolder, 1, 3);
            tbl.Controls.Add(Folder, 0, 3);
            tbl.Controls.Add(btnSelectFolder, 2, 3);
            tbl.Controls.Add(label4, 0, 2);
            tbl.Controls.Add(btnUpdate, 1, 6);
            tbl.Controls.Add(rtdFail, 2, 2);
            tbl.Controls.Add(label2, 1, 1);
            tbl.Controls.Add(label3, 2, 1);
            tbl.Controls.Add(btnDeleteFolder, 2, 6);
            tbl.Controls.Add(btnOpenLog, 0, 6);
            tbl.Controls.Add(grpDbConfig, 1, 4);
            tbl.Controls.Add(grpGoogleDrive, 1, 5);
            tbl.Dock = DockStyle.Fill;
            tbl.Location = new Point(0, 0);
            tbl.Name = "tbl";
            tbl.RowCount = 7;
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tbl.Size = new Size(1041, 700);
            tbl.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(178, 0);
            label1.Name = "label1";
            label1.Size = new Size(236, 32);
            label1.TabIndex = 7;
            label1.Text = "BACKUP DATABASE";
            label1.Click += label1_Click;
            // 
            // rtbLog
            // 
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rtbLog.Location = new Point(178, 81);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(427, 296);
            rtbLog.TabIndex = 8;
            rtbLog.Text = "";
            // 
            // tblFolder
            // 
            tblFolder.Dock = DockStyle.Fill;
            tblFolder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            tblFolder.Location = new Point(178, 383);
            tblFolder.Name = "tblFolder";
            tblFolder.Size = new Size(427, 33);
            tblFolder.TabIndex = 9;
            tblFolder.Text = "C:\\BackupSQL";
            // 
            // Folder
            // 
            Folder.AutoSize = true;
            Folder.Dock = DockStyle.Fill;
            Folder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            Folder.Location = new Point(3, 380);
            Folder.Name = "Folder";
            Folder.Size = new Size(169, 40);
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
            btnSelectFolder.Location = new Point(611, 383);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(35, 34);
            btnSelectFolder.TabIndex = 11;
            btnSelectFolder.UseVisualStyleBackColor = false;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            label4.Location = new Point(3, 78);
            label4.Name = "label4";
            label4.Size = new Size(169, 302);
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
            btnUpdate.Location = new Point(178, 643);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(162, 48);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Backup Now";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // rtdFail
            // 
            rtdFail.Dock = DockStyle.Fill;
            rtdFail.Location = new Point(611, 80);
            rtdFail.Margin = new Padding(3, 2, 3, 2);
            rtdFail.Name = "rtdFail";
            rtdFail.Size = new Size(427, 298);
            rtdFail.TabIndex = 14;
            rtdFail.Text = "";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(178, 40);
            label2.Name = "label2";
            label2.Size = new Size(427, 38);
            label2.TabIndex = 15;
            label2.Text = "INFO";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(611, 40);
            label3.Name = "label3";
            label3.Size = new Size(427, 38);
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
            btnDeleteFolder.Location = new Point(611, 643);
            btnDeleteFolder.Name = "btnDeleteFolder";
            btnDeleteFolder.Size = new Size(162, 48);
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
            btnOpenLog.Location = new Point(3, 643);
            btnOpenLog.Name = "btnOpenLog";
            btnOpenLog.Size = new Size(162, 48);
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
            grpDbConfig.Location = new Point(178, 423);
            grpDbConfig.Name = "grpDbConfig";
            grpDbConfig.Size = new Size(860, 74);
            grpDbConfig.TabIndex = 18;
            grpDbConfig.TabStop = false;
            grpDbConfig.Text = "SQL Server Configuration";
            // 
            // dbTable
            // 
            dbTable.ColumnCount = 7;
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            dbTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
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
            dbTable.Location = new Point(3, 19);
            dbTable.Name = "dbTable";
            dbTable.RowCount = 1;
            dbTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            dbTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            dbTable.Size = new Size(854, 52);
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
            lblDbServer.Size = new Size(54, 52);
            lblDbServer.TabIndex = 0;
            lblDbServer.Text = "Server";
            lblDbServer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDbServer
            // 
            txtDbServer.Dock = DockStyle.Fill;
            txtDbServer.Font = new Font("Segoe UI", 10F);
            txtDbServer.Location = new Point(63, 10);
            txtDbServer.Margin = new Padding(3, 10, 3, 3);
            txtDbServer.Name = "txtDbServer";
            txtDbServer.Size = new Size(160, 25);
            txtDbServer.TabIndex = 1;
            // 
            // lblDbUser
            // 
            lblDbUser.AutoSize = true;
            lblDbUser.Dock = DockStyle.Fill;
            lblDbUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDbUser.Location = new Point(229, 0);
            lblDbUser.Name = "lblDbUser";
            lblDbUser.Size = new Size(44, 52);
            lblDbUser.TabIndex = 2;
            lblDbUser.Text = "User:";
            lblDbUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDbUser
            // 
            txtDbUser.Dock = DockStyle.Fill;
            txtDbUser.Font = new Font("Segoe UI", 10F);
            txtDbUser.Location = new Point(279, 10);
            txtDbUser.Margin = new Padding(3, 10, 3, 3);
            txtDbUser.Name = "txtDbUser";
            txtDbUser.Size = new Size(160, 25);
            txtDbUser.TabIndex = 3;
            // 
            // lblDbPassword
            // 
            lblDbPassword.Location = new Point(445, 0);
            lblDbPassword.Name = "lblDbPassword";
            lblDbPassword.Size = new Size(74, 23);
            lblDbPassword.TabIndex = 4;
            lblDbPassword.Click += lblDbPassword_Click;
            // 
            // txtDbPassword
            // 
            txtDbPassword.Dock = DockStyle.Fill;
            txtDbPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDbPassword.Location = new Point(525, 3);
            txtDbPassword.Name = "txtDbPassword";
            txtDbPassword.Size = new Size(193, 25);
            txtDbPassword.TabIndex = 5;
            // 
            // btnSaveDbConfig
            // 
            btnSaveDbConfig.BackColor = Color.SteelBlue;
            btnSaveDbConfig.Dock = DockStyle.Fill;
            btnSaveDbConfig.FlatStyle = FlatStyle.Flat;
            btnSaveDbConfig.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveDbConfig.ForeColor = Color.White;
            btnSaveDbConfig.Location = new Point(724, 3);
            btnSaveDbConfig.Name = "btnSaveDbConfig";
            btnSaveDbConfig.Size = new Size(127, 46);
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
            grpGoogleDrive.Location = new Point(178, 503);
            grpGoogleDrive.Name = "grpGoogleDrive";
            grpGoogleDrive.Size = new Size(860, 134);
            grpGoogleDrive.TabIndex = 19;
            grpGoogleDrive.TabStop = false;
            grpGoogleDrive.Text = "Google Drive Configuration";
            // 
            // driveTable
            // 
            driveTable.ColumnCount = 3;
            driveTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            driveTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            driveTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            driveTable.Controls.Add(lblFolderId, 0, 0);
            driveTable.Controls.Add(txtDriveFolderName, 1, 0);
            driveTable.Controls.Add(btnLoginDrive, 2, 0);
            driveTable.Controls.Add(lblDriveStatus, 0, 1);
            driveTable.Controls.Add(lblDbList, 0, 2);
            driveTable.Controls.Add(txtDbList, 1, 2);
            driveTable.Dock = DockStyle.Fill;
            driveTable.Location = new Point(3, 19);
            driveTable.Name = "driveTable";
            driveTable.RowCount = 3;
            driveTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            driveTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            driveTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            driveTable.Size = new Size(854, 112);
            driveTable.TabIndex = 0;
            // 
            // lblFolderId
            // 
            lblFolderId.AutoSize = true;
            lblFolderId.Dock = DockStyle.Fill;
            lblFolderId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFolderId.Location = new Point(3, 0);
            lblFolderId.Name = "lblFolderId";
            lblFolderId.Size = new Size(94, 40);
            lblFolderId.TabIndex = 0;
            lblFolderId.Text = "Tên Thư Mục:";
            lblFolderId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDriveFolderName
            // 
            txtDriveFolderName.Dock = DockStyle.Fill;
            txtDriveFolderName.Font = new Font("Segoe UI", 10F);
            txtDriveFolderName.Location = new Point(103, 8);
            txtDriveFolderName.Margin = new Padding(3, 8, 3, 3);
            txtDriveFolderName.Name = "txtDriveFolderName";
            txtDriveFolderName.Size = new Size(598, 25);
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
            btnLoginDrive.Location = new Point(707, 3);
            btnLoginDrive.Name = "btnLoginDrive";
            btnLoginDrive.Size = new Size(144, 34);
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
            lblDriveStatus.Location = new Point(3, 40);
            lblDriveStatus.Name = "lblDriveStatus";
            lblDriveStatus.Size = new Size(848, 30);
            lblDriveStatus.TabIndex = 3;
            lblDriveStatus.Text = "Trạng thái: Chưa kết nối";
            lblDriveStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDbList
            // 
            lblDbList.AutoSize = true;
            lblDbList.Dock = DockStyle.Fill;
            lblDbList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDbList.Location = new Point(3, 70);
            lblDbList.Name = "lblDbList";
            lblDbList.Size = new Size(94, 42);
            lblDbList.TabIndex = 4;
            lblDbList.Text = "DB Chỉ định:";
            lblDbList.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDbList
            // 
            driveTable.SetColumnSpan(txtDbList, 2);
            txtDbList.Dock = DockStyle.Fill;
            txtDbList.Font = new Font("Segoe UI", 10F);
            txtDbList.Location = new Point(103, 78);
            txtDbList.Margin = new Padding(3, 8, 3, 3);
            txtDbList.Name = "txtDbList";
            txtDbList.Size = new Size(748, 25);
            txtDbList.TabIndex = 5;
            txtDbList.TextChanged += TxtDbList_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 700);
            Controls.Add(tbl);
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
    }
}
