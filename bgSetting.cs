using System;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class bgSetting : Form
    {
        public bgSetting()
        {
            InitializeComponent();
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("No interval was selected.", "Interval selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            else if (listBox1.SelectedIndex.Equals(0))
            {
                Properties.Settings.Default.updateInterval = listBox1.SelectedIndex;
                Properties.Settings.Default.allowBackgroundUpdates = true;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else if (listBox1.SelectedIndex.Equals(1))
            {
                Properties.Settings.Default.updateInterval = listBox1.SelectedIndex;
                Properties.Settings.Default.allowBackgroundUpdates = true;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else if (listBox1.SelectedIndex.Equals(2))
            {
                Properties.Settings.Default.updateInterval = listBox1.SelectedIndex;
                Properties.Settings.Default.allowBackgroundUpdates = true;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else if (listBox1.SelectedIndex.Equals(3))
            {
                Properties.Settings.Default.updateInterval = listBox1.SelectedIndex;
                Properties.Settings.Default.allowBackgroundUpdates = true;
                Properties.Settings.Default.Save();
                this.Close();
            }
        }

        private void bgSetting_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.updateInterval.Equals(-1))
            {
                this.Close();
            }
        }
    }
}
