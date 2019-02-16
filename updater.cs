using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class updater : Form
    {
        public WebClient web1 = new WebClient();
        public String version;
        public String latest;
        public int latestI;
        public int versionI;
        public Boolean allowRedirection;
        bool connection = NetworkInterface.GetIsNetworkAvailable();
        public updater()
        {
            InitializeComponent();
        }

        private void updater_Load(object sender, EventArgs e)
        {
            version = ProductVersion;
            version = version.Replace(".","");
            versionI = int.Parse(version);
            label2.Text = "Current version: v" + ProductVersion;
            if (connection.Equals(true))
            {
                try
                {
                    latest = web1.DownloadString(Properties.Settings.Default.versionControl);
                    latest = latest.Replace(".", "");
                    latestI = int.Parse(latest);

                    if(versionI == latestI)
                    {
                        pictureBox1.Visible = false;
                        label1.Text = "Updater";
                        label3.Text = "You're running the latest version.";
                    }
                    else if(versionI < latestI)
                    {
                        pictureBox1.Visible = false;
                        label1.Text = "Newer version found";
                        label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
                        label3.Text = "Click for download webpage redirection.";
                        allowRedirection = true;
                    }
                }
                catch
                {
                    Close();
                }
            }
            else
            {
                pictureBox1.Visible = false;
                label3.Text = "Connection cannot be established.";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (allowRedirection.Equals(true))
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.downloadsSite);
                Close();
            }
                
        }
    }
}
