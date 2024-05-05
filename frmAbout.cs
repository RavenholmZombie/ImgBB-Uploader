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

namespace ImgBB
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version " + ProductVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://mesabrook.com");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/RavenholmZombie/ImgBB-Uploader");
            Close();
        }
    }
}
