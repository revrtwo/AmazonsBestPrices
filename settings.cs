using System;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class settings : Form
    {
        private bgSetting bgSetting;

        public settings()
        {
            InitializeComponent();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            refreshSettings();
        }

        //Substitute tracker url setting
        private void urlBox_CheckedChanged(object sender, EventArgs e)
        {
            if (urlBox.Checked.Equals(true))
            {
                Properties.Settings.Default.hideURL = true;
            }
            else
            {
                Properties.Settings.Default.hideURL = false;

            }
        }

        //Clear url box setting
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

        //Allow notifications setting
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

        //Asterisk Setting
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

        //Allow backgrounds updates settings
        private void updateBox_CheckedChanged(object sender, EventArgs e)
        {
            if (updateBox.Checked.Equals(true) && Properties.Settings.Default.allowBackgroundUpdates.Equals(false))
            {
                this.Hide();
                bgSetting = new bgSetting();
                bgSetting.SizeGripStyle = SizeGripStyle.Hide;
                bgSetting.ShowDialog();
                this.Show();
            }
            else if (updateBox.Checked.Equals(false))
            {
                Properties.Settings.Default.allowBackgroundUpdates = false;
                Properties.Settings.Default.updateInterval = -1;
                Properties.Settings.Default.Save();
                updateBox.Checked = false;
            }
            else if (Properties.Settings.Default.allowBackgroundUpdates.Equals(true))
            {
                updateBox.Checked = true;
            }

        }

        private void refreshSettings()
        {
            if (Properties.Settings.Default.hideURL.Equals(true))
            {
                urlBox.Checked = true;
            }
            else
            {
                urlBox.Checked = false;
            }

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

            if (Properties.Settings.Default.allowBackgroundUpdates.Equals(true))
            {
                updateBox.Checked = true;
            }
            else
            {
                updateBox.Checked = false;
            }
        }

        private void settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
