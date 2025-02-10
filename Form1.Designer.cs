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
            tbl.SuspendLayout();
            SuspendLayout();
            // 
            // tbl
            // 
            tbl.BackColor = SystemColors.ControlLight;
            tbl.ColumnCount = 3;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl.Controls.Add(label1, 1, 0);
            tbl.Controls.Add(rtbLog, 1, 2);
            tbl.Controls.Add(tblFolder, 1, 3);
            tbl.Controls.Add(Folder, 0, 3);
            tbl.Controls.Add(btnSelectFolder, 2, 3);
            tbl.Controls.Add(label4, 0, 2);
            tbl.Controls.Add(btnUpdate, 1, 4);
            tbl.Controls.Add(rtdFail, 2, 2);
            tbl.Controls.Add(label2, 1, 1);
            tbl.Controls.Add(label3, 2, 1);
            tbl.Controls.Add(btnDeleteFolder, 2, 4);
            tbl.Controls.Add(btnOpenLog, 0, 4);
            tbl.Dock = DockStyle.Fill;
            tbl.Location = new Point(0, 0);
            tbl.Margin = new Padding(3, 4, 3, 4);
            tbl.Name = "tbl";
            tbl.RowCount = 5;
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tbl.Size = new Size(1190, 600);
            tbl.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(203, 0);
            label1.Name = "label1";
            label1.Size = new Size(295, 41);
            label1.TabIndex = 7;
            label1.Text = "BACKUP DATABASE";
            label1.Click += label1_Click;
            // 
            // rtbLog
            // 
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rtbLog.Location = new Point(203, 108);
            rtbLog.Margin = new Padding(3, 4, 3, 4);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(489, 354);
            rtbLog.TabIndex = 8;
            rtbLog.Text = "";
            // 
            // tblFolder
            // 
            tblFolder.Dock = DockStyle.Fill;
            tblFolder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            tblFolder.Location = new Point(203, 470);
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
            Folder.Location = new Point(3, 466);
            Folder.Name = "Folder";
            Folder.Size = new Size(194, 54);
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
            btnSelectFolder.Location = new Point(698, 470);
            btnSelectFolder.Margin = new Padding(3, 4, 3, 4);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(40, 46);
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
            label4.Size = new Size(194, 362);
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
            btnUpdate.Location = new Point(203, 524);
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
            rtdFail.Size = new Size(489, 356);
            rtdFail.TabIndex = 14;
            rtdFail.Text = "";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(203, 54);
            label2.Name = "label2";
            label2.Size = new Size(489, 50);
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
            label3.Location = new Point(698, 54);
            label3.Name = "label3";
            label3.Size = new Size(489, 50);
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
            btnDeleteFolder.Location = new Point(698, 524);
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
            btnOpenLog.Location = new Point(3, 524);
            btnOpenLog.Margin = new Padding(3, 4, 3, 4);
            btnOpenLog.Name = "btnOpenLog";
            btnOpenLog.Size = new Size(185, 64);
            btnOpenLog.TabIndex = 17;
            btnOpenLog.Text = "Open Log";
            btnOpenLog.UseVisualStyleBackColor = false;
            btnOpenLog.Click += btnOpenLogFile_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 600);
            Controls.Add(tbl);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Backup SQL Server";
            tbl.ResumeLayout(false);
            tbl.PerformLayout();
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
    }
}
