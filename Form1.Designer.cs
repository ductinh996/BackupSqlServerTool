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
            btnUpdate = new Button();
            tblFolder = new TextBox();
            Folder = new Label();
            btnSelectFolder = new Button();
            label4 = new Label();
            tbl.SuspendLayout();
            SuspendLayout();
            // 
            // tbl
            // 
            tbl.BackColor = SystemColors.ControlLight;
            tbl.ColumnCount = 3;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.26614F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.7338638F));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 61F));
            tbl.Controls.Add(label1, 1, 0);
            tbl.Controls.Add(rtbLog, 1, 1);
            tbl.Controls.Add(btnUpdate, 1, 3);
            tbl.Controls.Add(tblFolder, 1, 2);
            tbl.Controls.Add(Folder, 0, 2);
            tbl.Controls.Add(btnSelectFolder, 2, 2);
            tbl.Controls.Add(label4, 0, 1);
            tbl.Dock = DockStyle.Fill;
            tbl.Location = new Point(0, 0);
            tbl.Margin = new Padding(4, 5, 4, 5);
            tbl.Name = "tbl";
            tbl.RowCount = 4;
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tbl.Size = new Size(1143, 750);
            tbl.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(244, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(356, 48);
            label1.TabIndex = 7;
            label1.Text = "RENAME TEMPLATE";
            label1.Click += label1_Click;
            // 
            // rtbLog
            // 
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            rtbLog.Location = new Point(244, 72);
            rtbLog.Margin = new Padding(4, 5, 4, 5);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(833, 506);
            rtbLog.TabIndex = 8;
            rtbLog.Text = "";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.MenuHighlight;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(244, 655);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(231, 80);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Backup Now";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // tblFolder
            // 
            tblFolder.Dock = DockStyle.Fill;
            tblFolder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            tblFolder.Location = new Point(244, 588);
            tblFolder.Margin = new Padding(4, 5, 4, 5);
            tblFolder.Name = "tblFolder";
            tblFolder.Size = new Size(833, 45);
            tblFolder.TabIndex = 9;
            tblFolder.Text = "C:\\BackupSQL";
            // 
            // Folder
            // 
            Folder.AutoSize = true;
            Folder.Dock = DockStyle.Fill;
            Folder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            Folder.Location = new Point(4, 583);
            Folder.Margin = new Padding(4, 0, 4, 0);
            Folder.Name = "Folder";
            Folder.Size = new Size(232, 67);
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
            btnSelectFolder.Location = new Point(1085, 588);
            btnSelectFolder.Margin = new Padding(4, 5, 4, 5);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(50, 57);
            btnSelectFolder.TabIndex = 11;
            btnSelectFolder.UseVisualStyleBackColor = false;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            label4.Location = new Point(4, 67);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(232, 516);
            label4.TabIndex = 12;
            label4.Text = "Clear folder Obj if build fail";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(tbl);
            Margin = new Padding(4, 5, 4, 5);
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
    }
}
