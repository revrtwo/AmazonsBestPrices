using System;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class developerTools : Form
    {
        itemView view = new itemView();
        public int time = 0;
        public developerTools()
        {
            InitializeComponent();
        }

        private void developerTools_Load(object sender, EventArgs e)
        {
            label9.Text = Properties.Settings.Default.allowBackgroundUpdates.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.item1URL = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 5; i++)
            view.deleteThis(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view.Text = "<--- Developer Mode --->";
            view.devButton.Visible = false;
            view.Activate();
            refreshWatcher.Start();
            view.Show();
            view.WindowState = FormWindowState.Normal;
        }

        private void refreshWatcher_Tick(object sender, EventArgs e)
        {
            if (view.updateTimer.Enabled == true)
                label6.Text = "Background updates running";
            label5.Text = view.updateTimer.Interval.ToString();
            label8.Text = view.returnLastUpdate();
        }

        private String mstoSec(int time)
        {
            int converted = time / 1000;
            return time.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString();
            view.refreshNames();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.item2URL = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.item3URL = textBox3.Text;
            Properties.Settings.Default.Save();
        }
    }
}
