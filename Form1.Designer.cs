namespace ImgBB
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            label1 = new Label();
            txtFilePath = new TextBox();
            btnBrowse = new Button();
            label2 = new Label();
            rtbLog = new RichTextBox();
            label3 = new Label();
            txtURL = new TextBox();
            btnCopyURL = new Button();
            btnUpload = new Button();
            label4 = new Label();
            btnAPIKey = new Button();
            radioLocal = new RadioButton();
            radioRemote = new RadioButton();
            chkNarrator = new CheckBox();
            groupBox1 = new GroupBox();
            label5 = new Label();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripSplitButton2 = new ToolStripSplitButton();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            aboutImgBBUploaderToolStripMenuItem = new ToolStripMenuItem();
            factoryResetToolStripMenuItem = new ToolStripMenuItem();
            logToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 0;
            label1.Text = "Select an Image to upload:";
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(12, 49);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(377, 23);
            txtFilePath.TabIndex = 1;
            txtFilePath.TextChanged += textBox1_TextChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(395, 48);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 84);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "Console:";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(12, 102);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(455, 73);
            rtbLog.TabIndex = 4;
            rtbLog.Text = "Waiting";
            rtbLog.TextChanged += rtbLog_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 187);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 5;
            label3.Text = "Direct URL:";
            // 
            // txtURL
            // 
            txtURL.Location = new Point(12, 205);
            txtURL.Name = "txtURL";
            txtURL.ReadOnly = true;
            txtURL.Size = new Size(377, 23);
            txtURL.TabIndex = 6;
            txtURL.TextChanged += textBox2_TextChanged;
            // 
            // btnCopyURL
            // 
            btnCopyURL.Enabled = false;
            btnCopyURL.Location = new Point(395, 204);
            btnCopyURL.Name = "btnCopyURL";
            btnCopyURL.Size = new Size(75, 23);
            btnCopyURL.TabIndex = 7;
            btnCopyURL.Text = "Copy";
            btnCopyURL.UseVisualStyleBackColor = true;
            btnCopyURL.Click += button2_Click;
            // 
            // btnUpload
            // 
            btnUpload.Enabled = false;
            btnUpload.Location = new Point(242, 250);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(108, 23);
            btnUpload.TabIndex = 8;
            btnUpload.Text = "Begin Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(79, 282);
            label4.Name = "label4";
            label4.Size = new Size(321, 15);
            label4.TabIndex = 9;
            label4.Text = "This program is not owned by, or affiliated with ImgBB.com";
            // 
            // btnAPIKey
            // 
            btnAPIKey.Location = new Point(128, 250);
            btnAPIKey.Name = "btnAPIKey";
            btnAPIKey.Size = new Size(108, 23);
            btnAPIKey.TabIndex = 10;
            btnAPIKey.Text = "Change API Key";
            btnAPIKey.UseVisualStyleBackColor = true;
            btnAPIKey.Click += button1_Click_1;
            // 
            // radioLocal
            // 
            radioLocal.AutoSize = true;
            radioLocal.Checked = true;
            radioLocal.Location = new Point(165, 29);
            radioLocal.Name = "radioLocal";
            radioLocal.Size = new Size(110, 19);
            radioLocal.TabIndex = 11;
            radioLocal.TabStop = true;
            radioLocal.Text = "Upload from PC";
            radioLocal.UseVisualStyleBackColor = true;
            radioLocal.CheckedChanged += radioLocal_CheckedChanged;
            // 
            // radioRemote
            // 
            radioRemote.AutoSize = true;
            radioRemote.Location = new Point(281, 29);
            radioRemote.Name = "radioRemote";
            radioRemote.Size = new Size(116, 19);
            radioRemote.TabIndex = 12;
            radioRemote.Text = "Upload from URL";
            radioRemote.UseVisualStyleBackColor = true;
            radioRemote.CheckedChanged += radioRemote_CheckedChanged;
            // 
            // chkNarrator
            // 
            chkNarrator.AutoSize = true;
            chkNarrator.Location = new Point(12, 253);
            chkNarrator.Name = "chkNarrator";
            chkNarrator.Size = new Size(70, 19);
            chkNarrator.TabIndex = 13;
            chkNarrator.Text = "Narrator";
            chkNarrator.UseVisualStyleBackColor = true;
            chkNarrator.CheckedChanged += chkNarrator_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(webView21);
            groupBox1.Location = new Point(476, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(333, 266);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Preview";
            // 
            // label5
            // 
            label5.BackColor = Color.White;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 19);
            label5.Name = "label5";
            label5.Size = new Size(327, 244);
            label5.TabIndex = 15;
            label5.Text = "Preview will populate after upload.";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = false;
            webView21.BackColor = Color.White;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Enabled = false;
            webView21.Location = new Point(3, 19);
            webView21.Name = "webView21";
            webView21.Size = new Size(327, 244);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripSplitButton2 });
            statusStrip1.Location = new Point(0, 305);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(821, 22);
            statusStrip1.TabIndex = 15;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripSplitButton2
            // 
            toolStripSplitButton2.DropDownButtonWidth = 0;
            toolStripSplitButton2.Image = Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_edit_redo_256;
            toolStripSplitButton2.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton2.Name = "toolStripSplitButton2";
            toolStripSplitButton2.Size = new Size(125, 20);
            toolStripSplitButton2.Text = "Check for Updates";
            toolStripSplitButton2.ButtonClick += toolStripSplitButton2_ButtonClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, logToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(821, 24);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutImgBBUploaderToolStripMenuItem, factoryResetToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // aboutImgBBUploaderToolStripMenuItem
            // 
            aboutImgBBUploaderToolStripMenuItem.Name = "aboutImgBBUploaderToolStripMenuItem";
            aboutImgBBUploaderToolStripMenuItem.Size = new Size(196, 22);
            aboutImgBBUploaderToolStripMenuItem.Text = "About ImgBB Uploader";
            aboutImgBBUploaderToolStripMenuItem.Click += aboutImgBBUploaderToolStripMenuItem_Click;
            // 
            // factoryResetToolStripMenuItem
            // 
            factoryResetToolStripMenuItem.Name = "factoryResetToolStripMenuItem";
            factoryResetToolStripMenuItem.Size = new Size(196, 22);
            factoryResetToolStripMenuItem.Text = "Factory Reset";
            factoryResetToolStripMenuItem.Click += factoryResetToolStripMenuItem_Click;
            // 
            // logToolStripMenuItem
            // 
            logToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearToolStripMenuItem, saveAsToolStripMenuItem });
            logToolStripMenuItem.Name = "logToolStripMenuItem";
            logToolStripMenuItem.Size = new Size(62, 20);
            logToolStripMenuItem.Text = "Console";
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(114, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 327);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox1);
            Controls.Add(chkNarrator);
            Controls.Add(radioRemote);
            Controls.Add(radioLocal);
            Controls.Add(btnAPIKey);
            Controls.Add(label4);
            Controls.Add(btnUpload);
            Controls.Add(btnCopyURL);
            Controls.Add(txtURL);
            Controls.Add(label3);
            Controls.Add(rtbLog);
            Controls.Add(label2);
            Controls.Add(btnBrowse);
            Controls.Add(txtFilePath);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ImgBB Uploader";
            FormClosing += frmMain_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFilePath;
        private Button btnBrowse;
        private Label label2;
        private RichTextBox rtbLog;
        private Label label3;
        private TextBox txtURL;
        private Button btnCopyURL;
        private Button btnUpload;
        private Label label4;
        private Button btnAPIKey;
        private RadioButton radioLocal;
        private RadioButton radioRemote;
        private CheckBox chkNarrator;
        private GroupBox groupBox1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Label label5;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripSplitButton toolStripSplitButton2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem logToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutImgBBUploaderToolStripMenuItem;
        private ToolStripMenuItem factoryResetToolStripMenuItem;
    }
}
