using System;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            refreshSettings();
        }

        private void clearBox_CheckedChanged(object sender, EventArgs e)
        {
            if (clearBox.Checked.Equals(true))
            {
                Properties.Settings.Default.clearURLBox = true;
            }
            else
            {
                Properties.Settings.Default.clearURLBox = false;
            }
        }

        private void notificationBox_CheckedChanged(object sender, EventArgs e)
        {
            if (notificationBox.Checked.Equals(true))
            {
                Properties.Settings.Default.allowNotifications = true;
            }
            else
            {
                Properties.Settings.Default.allowNotifications = false;
            }
        }

        private void asteriskBox_CheckedChanged(object sender, EventArgs e)
        {
            if (asteriskBox.Checked.Equals(true))
            {
                Properties.Settings.Default.setAsterisk = true;
            }
            else
            {
                Properties.Settings.Default.setAsterisk = false;
            }
        }

        private void refreshSettings()
        {
            if (Properties.Settings.Default.clearURLBox.Equals(true))
            {
                clearBox.Checked = true;
            }
            else
            {
                clearBox.Checked = false;
            }

            if (Properties.Settings.Default.allowNotifications.Equals(true))
            {
                notificationBox.Checked = true;
            }
            else
            {
                notificationBox.Checked = false;
            }

            if (Properties.Settings.Default.setAsterisk.Equals(true))
            {
                asteriskBox.Checked = true;
            }
            else
            {
                asteriskBox.Checked = false;
            }
        }

        private void settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
            main main = new main();
            main.Show();
        }

        
    }
}
