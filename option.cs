using System;
using System.IO;
using System.Windows.Forms;
using Trackers;
namespace Amazon_s_Best_Prices
{
    public partial class option : Form
    {
        Tracker[] temp = new Tracker[1];
        public option(Tracker t)
        {
            InitializeComponent();
            temp[0] = t;
        }

        private void option_Load(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.ControlBox = false;
            addButton.Enabled = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            String itemName = "";
            String itemCost = temp[0].getPrice();
            String itemURL = temp[0].getURL();
            if (itemNameBox.Text == "")
            {
                itemName = temp[0].getName();
            }
            else
            {
                itemName = itemNameBox.Text;
            }
            createObject(itemName, itemCost, itemURL);
        }

        private void createObject(string itemName, string itemCost, string itemURL)
        {
            String directory = Properties.Settings.Default.userDirectory;
            String trackerUID = "[" + Properties.Settings.Default.trackerUID++ + "]";
            try
            {
                if (File.Exists("Trackers.DAT"))
                {
                    File.AppendAllText("Trackers.DAT", "\n" + trackerUID  + itemName + "\n" + trackerUID + itemCost + "\n" + trackerUID  + itemURL);
                    MessageBox.Show("Tracker saved onto existing list.");
                
                }
                else
                {
                    StreamWriter sw = new StreamWriter("Trackers.DAT");
                    sw.Write(trackerUID + itemName + "\n" + trackerUID  + itemCost + "\n" + trackerUID + itemURL);
                    sw.Close();
                    
                    MessageBox.Show("Tracker file created and tracker saved");
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.trackerUID = 0;
            Properties.Settings.Default.Save();
        }
    }
}



