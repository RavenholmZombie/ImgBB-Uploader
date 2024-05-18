using ImgBB.Properties;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Media;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using System.Windows.Forms;


namespace ImgBB
{
    public partial class frmMain : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        public frmMain()
        {
            InitializeComponent();
            webView21.EnsureCoreWebView2Async(null);
        }

        private string APIKeyCipher(string key)
        {
            try
            {
                return key = new string('X', key.Length - 4) + key.Substring(key.Length - 4);
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForUpdateAsync("https://raw.githubusercontent.com/RavenholmZombie/RavenholmZombie/main/imgbb.txt", Application.ProductVersion);

            bool runningInVisualStudio = IsRunningInVisualStudio();
            if (!runningInVisualStudio)
            {
                factoryResetToolStripMenuItem.Visible = false;
            }
            else
            {
                factoryResetToolStripMenuItem.Visible = true;
            }

            if (String.IsNullOrEmpty(Properties.Settings.Default.apiKey))
            {
                frmAPIKey frm = new frmAPIKey(this);
                frm.ShowDialog();
            }

            if (String.IsNullOrEmpty(Properties.Settings.Default.uiState) || Properties.Settings.Default.uiState == "local")
            {
                radioLocal.Checked = true;
                label5.Visible = true;
                label5.Text = "Selected image will be shown here.";
            }
            else
            {
                radioRemote.Checked = true;
                label5.Visible = true;
                label5.Text = "Preview will populate after upload.";
                label5.BringToFront();
            }

            addToLog("Found API Key: " + APIKeyCipher(Properties.Settings.Default.apiKey));
            Text = "ImgBB Uploader - " + ProductVersion;

            chkNarrator.Checked = Properties.Settings.Default.useNarrator;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFilePath.Text))
            {
                btnUpload.Enabled = false;
                btnAPIKey.Enabled = false;
                ControlBox = false;
                addToLog("Queueing upload...");
                if (radioRemote.Checked)
                {
                    UploadRemoteImage(txtFilePath.Text);
                }
                else
                {
                    try
                    {
                        string apiKey = Properties.Settings.Default.apiKey;
                        string imagePath = txtFilePath.Text;
                        string apiUrl = "https://api.imgbb.com/1/upload";

                        using (var client = new HttpClient())
                        {
                            using (var formData = new MultipartFormDataContent())
                            {
                                formData.Add(new StringContent(apiKey), "key");
                                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                                formData.Add(new ByteArrayContent(imageBytes), "image", ofd.FileName + ofd.AddExtension);
                                var response = await client.PostAsync(apiUrl, formData);
                                addToLog("Starting upload...");


                                if (response.IsSuccessStatusCode)
                                {
                                    var responseContent = await response.Content.ReadAsStringAsync();
                                    dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
                                    string imageUrl = jsonResponse.data.url;
                                    txtURL.Text = imageUrl;
                                    addToLog($"Server returned HTTP {response.StatusCode} ({(int)response.StatusCode})");
                                    addToLog("Upload successful! Server returned URL " + imageUrl);
                                    NarrateAsync("Image Upload Successful.");
                                    SystemSounds.Exclamation.Play();
                                    generatePreview(imageUrl);
                                    groupBox1.Text = "Preview (Live on ImgBB)";
                                    txtFilePath.Clear();
                                    btnUpload.Enabled = true;
                                    btnAPIKey.Enabled = true;
                                    ControlBox = true;
                                }
                                else
                                {
                                    addToLog("Unable to upload.");
                                    NarrateAsync("Unable to upload.");
                                    SystemSounds.Hand.Play();
                                    btnUpload.Enabled = true;
                                    btnAPIKey.Enabled = true;
                                    ControlBox = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        addToLog("A fatal error occurred: " + ex.Message);
                        SystemSounds.Hand.Play();
                        NarrateAsync("A fatal error occurred");
                        btnUpload.Enabled = true;
                        btnAPIKey.Enabled = true;
                        ControlBox = true;
                    }
                }
            }
            else
            {
                addToLog("Unable to process upload request at this time.");
                SystemSounds.Hand.Play();
                NarrateAsync("Unable to process upload request at this time.");
                btnUpload.Enabled = true;
                btnAPIKey.Enabled = true;
                ControlBox = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtURL.Text);
            addToLog("URL copied to clipboard");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select an image to upload to ImgBB";
            ofd.Filter = "Image Files (*.png;*.jpeg;*.jpg;*.gif;*.bmp;)|*.png;*.jpeg;*.jpg;*.gif;*.bmp";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
                addToLog("Image selected");
                generatePreview(ofd.FileName);
                groupBox1.Text = "Preview (Local)";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            btnCopyURL.Enabled = !String.IsNullOrEmpty(txtURL.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnUpload.Enabled = !String.IsNullOrEmpty(txtFilePath.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmAPIKey frm = new frmAPIKey(this);
            frm.ShowDialog(this);
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void radioRemote_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRemote.Checked)
            {
                btnBrowse.Enabled = false;
                txtFilePath.ReadOnly = false;
                txtFilePath.Text = "";
                txtFilePath.PlaceholderText = "ex: https://i.imgur.com/JbwGiyf.png";
                label1.Text = "Paste Image URL:";
                label5.Visible = true;
                label5.Text = "Preview will populate after upload.";
                label5.BringToFront();
                webView21.Source = new Uri("about:blank");
                webView21.SendToBack();
                groupBox1.Text = "Preview";

                Properties.Settings.Default.uiState = "remote";
                Properties.Settings.Default.Save();
            }
        }

        private void radioLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLocal.Checked)
            {
                btnBrowse.Enabled = true;
                txtFilePath.ReadOnly = true;
                txtFilePath.Text = "";
                txtFilePath.PlaceholderText = "";
                label1.Text = "Select an Image to Upload:";
                label5.Visible = true;
                label5.Text = "Selected image will be shown here.";
                groupBox1.Text = "Preview";

                webView21.Source = new Uri("about:blank");
                webView21.SendToBack();

                Properties.Settings.Default.uiState = "local";
                Properties.Settings.Default.Save();
            }
        }

        private async Task<string> UploadRemoteImage(string imageUrl)
        {
            string fileExtension = Path.GetExtension(imageUrl);
            string fileName = Path.GetFileName(imageUrl);
            btnUpload.Enabled = false;
            btnAPIKey.Enabled = false;
            ControlBox = false;
            if (string.IsNullOrEmpty(fileExtension))
            {
                addToLog("Alert: Potentially invalid URL. Some URLs that do not provide direct file access may still upload to ImgBB anyways. Check the URL if it fails to upload.");
            }

            using (HttpClient client = new HttpClient())
            {
                String fullAPIKey = Properties.Settings.Default.apiKey;
                String cipheredKey = APIKeyCipher(fullAPIKey);

                addToLog($"Remote URL: {imageUrl}");
                addToLog("Starting upload using API key " + cipheredKey);

                byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

                var content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(imageBytes), "image", fileName + fileExtension);

                HttpResponseMessage response = await client.PostAsync($"https://api.imgbb.com/1/upload?key={Properties.Settings.Default.apiKey}", content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON response
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

                    // Extract URL of the uploaded image
                    string uploadedImageUrl = jsonResponse.data.url;
                    txtURL.Text = uploadedImageUrl;
                    addToLog($"Server returned HTTP {response.StatusCode} ({(int)response.StatusCode})");
                    addToLog("Remote Upload Successful. New URL: " + uploadedImageUrl);
                    NarrateAsync("Remote Upload Successful.");
                    SystemSounds.Exclamation.Play();
                    txtFilePath.Clear();
                    generatePreview(uploadedImageUrl);
                    groupBox1.Text = "Preview (Live on ImgBB)";
                    btnUpload.Enabled = true;
                    btnAPIKey.Enabled = true;
                    ControlBox = true;
                    return uploadedImageUrl;
                }
                else
                {
                    addToLog($"Failed to upload file. Status code: {response.StatusCode}");
                    NarrateAsync("Remote Upload Failed.");
                    label5.Text = "Failed to generate preview";
                    SystemSounds.Hand.Play();
                    btnUpload.Enabled = true;
                    btnAPIKey.Enabled = true;
                    ControlBox = true;
                    return null;
                }
            }
        }

        private void addToLog(string info)
        {
            rtbLog.AppendText("\n" + info);
        }

        private async Task NarrateAsync(string text)
        {
            if (Properties.Settings.Default.useNarrator)
            {
                try
                {
                    using (SpeechSynthesizer synth = new SpeechSynthesizer())
                    {
                        await Task.Run(() => synth.Speak(text));
                    }
                }
                catch(Exception ex)
                {
                    addToLog($"Unable to reach Narrator. {ex.Message}");
                }
            }
        }

        private void chkNarrator_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.useNarrator = chkNarrator.Checked;
            Properties.Settings.Default.Save();

            if (chkNarrator.Checked)
            {
                NarrateAsync($"Hello {Environment.UserName}, Welcome to ImgBB Uploader version {Application.ProductVersion}. Narrator is enabled.");
                addToLog("Narrator on");
            }
            else
            {
                addToLog("Narrator off");
            }
        }

        private void generatePreview(string path)
        {
            try
            {
                webView21.Source = new Uri(path);
                label5.Visible = false;
            }
            catch (Exception ex)
            {
                webView21.Source = new Uri("about:blank");
                label5.Visible = true;
                label5.Text = "Unable to generate preview.";
            }
        }

        public void NotifyKeyUpdate(string key)
        {
            addToLog("API Key change detected.");
            addToLog($"New Key: {APIKeyCipher(key)}");
            NarrateAsync("API key change detected.");
        }

        public async Task CheckForUpdateAsync(string remoteUrl, string currentVersion)
        {
            toolStripStatusLabel1.Text = "Contacting Update Server...";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string latestVersion = await client.GetStringAsync(remoteUrl).ConfigureAwait(false);
                    latestVersion = latestVersion.Trim();

                    if (IsNewerVersion(latestVersion, currentVersion))
                    {
                        toolStripStatusLabel1.Text = $"{latestVersion} is available.";
                        // Current version is outdated.
                        if (MessageBox.Show($"An updated version of ImgBB Uploader is available. You must update before you can continue using this program. \n\nCurrent Version: {Application.ProductVersion} \nLatest Version: {latestVersion} \n\nPress OK to download the latest version of ImgBB Uploader.", "Update Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            Process.Start("https://github.com/RavenholmZombie/ImgBB-Uploader/releases/tag/" + latestVersion);
                            Application.Exit();
                        }
                    }
                    else if (IsVersionAhead(latestVersion, currentVersion))
                    {
                        toolStripStatusLabel1.Text = $"Beta Version Detected (Current: {currentVersion} > Prod: {latestVersion})";
                        return;
                    }
                    else
                    {
                        // Current version is latest, do nothing.
                        toolStripStatusLabel1.Text = "App is up to date";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // Error
                toolStripStatusLabel1.Text = "Unable to reach server.";
            }
        }

        private static bool IsNewerVersion(string versionA, string versionB)
        {
            string[] partsA = versionA.Split('.');
            string[] partsB = versionB.Split('.');

            for (int i = 0; i < Math.Min(partsA.Length, partsB.Length); i++)
            {
                int partA = int.Parse(partsA[i]);
                int partB = int.Parse(partsB[i]);

                if (partA > partB)
                    return true;
                else if (partA < partB)
                    return false;
            }
            return false;
        }

        private static bool IsVersionAhead(string versionA, string versionB)
        {
            string[] partsA = versionA.Split('.');
            string[] partsB = versionB.Split('.');

            for (int i = 0; i < Math.Min(partsA.Length, partsB.Length); i++)
            {
                int partA = int.Parse(partsA[i]);
                int partB = int.Parse(partsB[i]);

                if (partA < partB)
                    return true;
                else if (partA > partB)
                    return false;
            }
            return false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            CheckForUpdateAsync("https://raw.githubusercontent.com/RavenholmZombie/RavenholmZombie/main/imgbb.txt", Application.ProductVersion);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        private void aboutImgBBUploaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Console Output to Text File";
            sfd.Filter = "Plain Text File|*.txt";
            sfd.FileName = $"ImgBB-Uploader-Log-{timestamp}";

            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, rtbLog.Text);
                addToLog($"Console Log Saved - {DateTime.Now}");
                addToLog(sfd.FileName);
            }
        }
        static bool IsRunningInVisualStudio()
        {
            // Check environment variable
            string visualStudioDir = Environment.GetEnvironmentVariable("VisualStudioDir");
            if (visualStudioDir != null)
            {
                return true;
            }

            // Check loaded assemblies
            foreach (ProcessModule processModule in Process.GetCurrentProcess().Modules)
            {
                if (processModule.ModuleName.StartsWith("VisualStudio"))
                {
                    return true;
                }
            }

            return false;
        }

        private void factoryResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            Application.Exit();
        }
    }
}
