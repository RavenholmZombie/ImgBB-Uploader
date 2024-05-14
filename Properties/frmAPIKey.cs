using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImgBB.Properties
{
    public partial class frmAPIKey : Form
    {
        private frmMain mainForm;
        public frmAPIKey(frmMain mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void frmAPIKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.apiKey))
            {
                Application.Exit();
            }
        }

        private void btnGetKey_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://api.imgbb.com/");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool containsInvalidCharacters = false;
            foreach (char c in txtAPIKey.Text)
            {
                if (char.IsWhiteSpace(c) || !IsValidCharacter(c) || txtAPIKey.Text.Length < 32 || txtAPIKey.Text.Length > 32)
                {
                    containsInvalidCharacters = true;
                    break;
                }

                if (String.IsNullOrEmpty(txtAPIKey.Text) || String.IsNullOrWhiteSpace(txtAPIKey.Text))
                {
                    containsInvalidCharacters = true;
                    break;
                }
            }

            int messageLength = txtAPIKey.Text.Length;

            if (containsInvalidCharacters)
            {
                MessageBox.Show("Your key could not be valided. Please ensure that it meets the following criteria: \n\nAPI key must not contain spaces\nAPI key must not contain special characters\nAPI key cannot be longer than 32 characters.\nAPI key cannot be shorter than 32 characters.\n\nPlease check your entered API key or generate a new one and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                Properties.Settings.Default.apiKey = txtAPIKey.Text;
                Properties.Settings.Default.Save();

                mainForm.NotifyKeyUpdate(Properties.Settings.Default.apiKey);

                Close();
            }

            bool IsValidCharacter(char c)
            {
                return char.IsLetterOrDigit(c);
            }
        }

        private void frmAPIKey_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.apiKey))
            {
                txtAPIKey.Text = Properties.Settings.Default.apiKey;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["frmMain"];
            if (fc != null)
            {
                Close();
            }
            else
            {
                Application.Exit();
            }
        }

        private void txtAPIKey_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !String.IsNullOrEmpty(txtAPIKey.Text) && !String.IsNullOrWhiteSpace(txtAPIKey.Text);
        }
    }
}
