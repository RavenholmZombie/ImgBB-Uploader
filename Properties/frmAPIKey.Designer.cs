namespace ImgBB.Properties
{
    partial class frmAPIKey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtAPIKey = new TextBox();
            btnSave = new Button();
            btnGetKey = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(301, 15);
            label1.TabIndex = 0;
            label1.Text = "To use this program, please provide your ImgBB API Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 43);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 1;
            label2.Text = "API Key:";
            // 
            // txtAPIKey
            // 
            txtAPIKey.Location = new Point(12, 61);
            txtAPIKey.Name = "txtAPIKey";
            txtAPIKey.Size = new Size(312, 23);
            txtAPIKey.TabIndex = 2;
            txtAPIKey.TextChanged += txtAPIKey_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(249, 100);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnGetKey
            // 
            btnGetKey.Location = new Point(155, 100);
            btnGetKey.Name = "btnGetKey";
            btnGetKey.Size = new Size(88, 23);
            btnGetKey.TabIndex = 4;
            btnGetKey.Text = "Get a Key";
            btnGetKey.UseVisualStyleBackColor = true;
            btnGetKey.Click += btnGetKey_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 100);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmAPIKey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 135);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(btnGetKey);
            Controls.Add(btnSave);
            Controls.Add(txtAPIKey);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAPIKey";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "API Key";
            FormClosing += frmAPIKey_FormClosing;
            Load += frmAPIKey_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtAPIKey;
        private Button btnSave;
        private Button btnGetKey;
        private Button button1;
    }
}