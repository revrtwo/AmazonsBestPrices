using System;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class itemView : Form
    {
        public static String urlText = "Click here for item webpage";
        public static String nullString = "No item is being tracked here";

        public itemView()
        {
            InitializeComponent();
        }

        private void itemView_Load(object sender, EventArgs e)
        {
            refreshNames();
        }

        private void refreshNames()
        {
            //Tab One
            if(Properties.Settings.Default.itemSpot1 == false)
            {
                label1.Text = nullString;
                label2.Text = nullString;
                label3.Text = nullString;
                tabPage1.Text = "Empty";
            }
            else
            {
                label1.Text = Properties.Settings.Default.item1;
                label2.Text = Properties.Settings.Default.price1;
                label3.Text = Properties.Settings.Default.item1URL;
                tabPage1.Text = Properties.Settings.Default.item1;
            }
            //Tab Two
            if (Properties.Settings.Default.itemSpot2 == false)
            {
                label4.Text = nullString;
                label5.Text = nullString;
                label6.Text = nullString;
                tabPage2.Text = "Empty";
            }
            else
            {
                label4.Text = Properties.Settings.Default.item2;
                label5.Text = Properties.Settings.Default.price2;
                label6.Text = Properties.Settings.Default.item2URL;
                tabPage2.Text = Properties.Settings.Default.item2;
            }
            //Tab Three
            if (Properties.Settings.Default.itemSpot3 == false)
            {
                label7.Text = nullString;
                label8.Text = nullString;
                label9.Text = nullString;
                tabPage3.Text = "Empty";
            }
            else
            {
                label7.Text = Properties.Settings.Default.item3;
                label8.Text = Properties.Settings.Default.price3;
                label9.Text = Properties.Settings.Default.item3URL;
                tabPage3.Text = Properties.Settings.Default.item3;
            }
            //Tab Four
            if (Properties.Settings.Default.itemSpot4 == false)
            {
                label10.Text = nullString;
                label11.Text = nullString;
                label12.Text = nullString;
                tabPage4.Text = "Empty";
            }
            else
            {
                label10.Text = Properties.Settings.Default.item4;
                label11.Text = Properties.Settings.Default.price4;
                label12.Text = Properties.Settings.Default.item4URL;
                tabPage4.Text = Properties.Settings.Default.item4;
            }
            //Tab Five
            if (Properties.Settings.Default.itemSpot5 == false)
            {
                label13.Text = nullString;
                label14.Text = nullString;
                label15.Text = nullString;
                tabPage5.Text = "Empty";
            }
            else
            {
                label13.Text = Properties.Settings.Default.item5;
                label14.Text = Properties.Settings.Default.price5;
                label15.Text = Properties.Settings.Default.item5URL;
                tabPage5.Text = Properties.Settings.Default.item5;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.item1URL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int identifier = 1;
            deleteThis(identifier);
            refreshNames();
        }

        private void deleteThis(int identifier)
        {

            switch (identifier)
            {
                case 1:
                    Properties.Settings.Default.itemSpot1 = false;
                    Properties.Settings.Default.item1 = "";
                    Properties.Settings.Default.price1 = "";
                    Properties.Settings.Default.item1URL = "";
                    break;
                case 2:
                    Properties.Settings.Default.itemSpot2 = false;
                    Properties.Settings.Default.item2 = "";
                    Properties.Settings.Default.price2 = "";
                    Properties.Settings.Default.item2URL = "";
                    break;
                case 3:
                    Properties.Settings.Default.itemSpot3 = false;
                    Properties.Settings.Default.item3 = "";
                    Properties.Settings.Default.price3 = "";
                    Properties.Settings.Default.item3URL = "";
                    break;
                case 4:
                    Properties.Settings.Default.itemSpot4 = false;
                    Properties.Settings.Default.item4 = "";
                    Properties.Settings.Default.price4 = "";
                    Properties.Settings.Default.item4URL = "";
                    break;
                case 5:
                    Properties.Settings.Default.itemSpot5 = false;
                    Properties.Settings.Default.item5 = "";
                    Properties.Settings.Default.price5 = "";
                    Properties.Settings.Default.item5URL = "";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int identifier = 2;
            deleteThis(identifier);
            refreshNames();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int identifier = 3;
            deleteThis(identifier);
            refreshNames();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int identifier = 4;
            deleteThis(identifier);
            refreshNames();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int identifier = 5;
            deleteThis(identifier);
            refreshNames();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.item2URL);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.item3URL);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.item4URL);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.item5URL);
        }
    }
}
