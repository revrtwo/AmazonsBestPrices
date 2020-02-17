using System;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Trackers;

namespace Amazon_s_Best_Prices
{
    public partial class main : Form
    {
        public int formOpener = -1;
        public WebClient web1 = new WebClient();
        public String version;
        public String latest;
        public int latestI;
        public int versionI;
        bool connection = NetworkInterface.GetIsNetworkAvailable();
        static itemView view = new itemView();

        Tracker[] tempList = new Tracker[1];
        BackgroundWorker bg = new BackgroundWorker();

        public main()
        {
            InitializeComponent();
            bg.DoWork += Bg_DoWork;
            bg.WorkerReportsProgress = true;
            bg.WorkerSupportsCancellation = true;
            view.Enabled = false;
        }

        private void main_Load(object sender, EventArgs e)
        {
            checkForUpdates();
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= 15; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    worker.ReportProgress(i * 10);
                }

                if (tempList[0].getCompleted())
                {
                    if(label2.InvokeRequired && label3.InvokeRequired)
                    {
                        label2.Invoke(new Action(() => label2.Text = "Item name: " + nameMinimizer(tempList[0].getName())));
                        label3.Invoke(new Action(() => label3.Text = "Item price: " + tempList[0].getPrice()));
                    }
                    else
                    {
                        label2.Text = "Item name: " + nameMinimizer(tempList[0].getName());
                        label3.Text = "Item price: " + tempList[0].getPrice();
                    }
                    simulateLoading(false);
                    break;
                }

                if(i >= 15)
                {
                    MessageBox.Show("A listing for this item may not be available at this time.", "Item unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    simulateLoading(false);
                }
            }
        }

        //Button action
        public void searchBtn_Click(object sender, EventArgs e)
        {
            simulateLoading(true);
            tempList[0] = new Tracker(textBox1.Text);
            bg.RunWorkerAsync();

        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            itemView showCase = new itemView();
            showCase.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            option op = new option(tempList[0]);
            op.SizeGripStyle = SizeGripStyle.Hide;
            op.ShowDialog();
            resetDisplay();
        }

        //Visual methods
        private string nameMinimizer(string name)
        {
            if (name.Length >= 72)
            {
                name = name.Substring(0, 72) + "...";
            }
            return name;
        }

        private void resetDisplay()
        {
            label2.Text = "Item name:";
            label3.Text = "Item price:";
            textBox1.Text = "";
        }

        private void simulateLoading(Boolean status)
        {
            if (status)
            {
                searchBtn.Invoke(new Action(() => searchBtn.Text = "Loading.."));
                searchBtn.Invoke(new Action(() => searchBtn.Enabled = false));
                addBtn.Invoke(new Action(() => addBtn.Enabled = false));
                this.Invoke(new Action(() => trackedToolStripMenuItem.Enabled = false));
                pictureBox1.Invoke(new Action(() => pictureBox1.Visible = true));
            }
            else
            {
                searchBtn.Invoke(new Action(() => searchBtn.Text = "Search"));
                searchBtn.Invoke(new Action(() => searchBtn.Enabled = true));
                addBtn.Invoke(new Action(() => addBtn.Enabled = true));
                this.Invoke(new Action(() => trackedToolStripMenuItem.Enabled = true));
                pictureBox1.Invoke(new Action(() => pictureBox1.Visible = false));
            }
        }

        //User enable options
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.clearURLBox.Equals(true))
            {
                textBox1.Text = null;
            }
        }

        //Version control
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

        //MenuStrip Actions
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

        private void updateAvaliableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updater update = new updater();
            update.SizeGripStyle = SizeGripStyle.Hide;
            update.ShowDialog();
        }

        //Actions when form closes
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //actions when form closes
        }

        //Developer test button
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
