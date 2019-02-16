using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class main : Form
    {
        public String itemPrice;
        public Boolean completed;
        public int formOpener = -1;
        public WebBrowser web = new WebBrowser();
        public WebClient web1 = new WebClient();
        public String version;
        public String latest;
        public int latestI;
        public int versionI;
        bool connection = NetworkInterface.GetIsNetworkAvailable();
        static itemView view = new itemView();

        public main()
        {
            InitializeComponent();
        }

        private void setCompleted()
        {
            completed = true;
        }

        private Boolean checkCompleted()
        {
            return completed;
        }

        private void setURL(String url)
        {
            Properties.Settings.Default.tempURL = url;
        }

        private void main_Load(object sender, EventArgs e)
        {
            view.Enabled = false;
            checkForUpdates();
            web.ScriptErrorsSuppressed = true;
        }

        private void checkForUpdates()
        {
            version = ProductVersion;
            version = version.Replace(".", "");
            versionI = int.Parse(version);
            if (connection.Equals(true))
            {
                try
                {
                    latest = web1.DownloadString(Properties.Settings.Default.versionControl);
                    latest = latest.Replace(".", "");
                    latestI = int.Parse(latest);
                    if (versionI < latestI)
                    {
                        updateAvaliableToolStripMenuItem.Visible = true;
                    }
                }
                catch
                {
                    //Connection cannot be made
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            option option = new option();
            option.SizeGripStyle = SizeGripStyle.Hide;
            option.ShowDialog();
            this.Show();
            resetDisplay();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            itemView showCase = new itemView();
            showCase.Show();
        }

        public void searchBtn_Click(object sender, EventArgs e)
        {
            searchBtn.Text = "Loading..";
            completed = false;
            searchBtn.Enabled = false;
            addBtn.Enabled = false;
            trackedToolStripMenuItem.Enabled = false;
            pictureBox1.Visible = true;
            try
            {
                Properties.Settings.Default.tempITEM = "";
                Properties.Settings.Default.tempPRICE = "";
                web.Navigate(textBox1.Text);
                setURL(textBox1.Text);
                web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(pageCompleted);
                completedChecker.Start();
            }
            catch
            {
               MessageBox.Show("An error has occured, please try again.", "URL error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void resetDisplay()
        {
            label2.Text = "Item name:";
            label3.Text = "Item price:";
            textBox1.Text = "";
        }

        private void checkName()
        {
            try
            {
                String itemName = web.Document.GetElementById("productTitle").OuterText;
                if(itemName.Length>= 72)
                {
                    String visibleName = itemName.Substring(0, 72);
                    label2.Text = "Item name: " + visibleName + "...";
                }
                else
                {
                    label2.Text = "Item name: " + itemName;
                }
                Properties.Settings.Default.tempITEM = itemName;  
            }
            catch
            {
                MessageBox.Show("Sorry, the name of the item was not found.", "Item not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label2.Text = "Item name: Item not found";
            }
        }

        private void checkPrice()
        {
                try
                {
                    itemPrice = web.Document.GetElementById("priceblock_ourprice").OuterText;
                    Properties.Settings.Default.tempPRICE = itemPrice;
                }
                catch
                {
                    try
                    {
                        if (itemPrice == null)
                        {
                        itemPrice = web.Document.GetElementById("priceblock_dealprice").OuterText;
                        Properties.Settings.Default.tempPRICE = itemPrice;
                        }
                    }
                     catch
                    {
                        Properties.Settings.Default.tempPRICE = "";
                    }
                }
                itemPrice = Properties.Settings.Default.tempPRICE;
            if (Properties.Settings.Default.tempPRICE == "")
            {
                MessageBox.Show("Sorry, the price of that item was not found.", "Price not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label3.Text = "Item price: Price not found";
                addBtn.Enabled = false;
            }
            else
            {
                label3.Text = "Item price: " + itemPrice;
                addBtn.Enabled = true;
                trackedToolStripMenuItem.Enabled = true;
                Properties.Settings.Default.tempPRICE = itemPrice;
            }
        }

        private void completedChecker_Tick(object sender, EventArgs e)
        {
            searchBtn.Enabled = false;
            if (checkCompleted())
            {
                completedChecker.Stop();
                searchBtn.Text = "Search";
                checkName();
                checkPrice();
                searchBtn.Enabled = true;
                trackedToolStripMenuItem.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        private void pageCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            setCompleted();
        }

        private void trackedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            view.Enabled = true;
            view.SizeGripStyle = SizeGripStyle.Hide;
            view.ShowDialog();
            this.Show();
        }

        private void optionStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            settings settings = new settings();
            settings.ShowDialog();
            this.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.ShowDialog();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.clearURLBox.Equals(true))
            {
                textBox1.Text = null;
            }
        }

        private void updateAvaliableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updater update = new updater();
            update.SizeGripStyle = SizeGripStyle.Hide;
            update.ShowDialog();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        //Developer test button
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
