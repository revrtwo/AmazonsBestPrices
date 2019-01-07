using System;
using System.Windows.Forms;
namespace Amazon_s_Best_Prices
{
    public partial class option : Form
    {

        public option()
        {
            InitializeComponent();
        }

        private void option_Load(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.ControlBox = false;
            addButton.Enabled = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            main main = new main();
            String itemName = itemNameBox.Text;
            String itemCost = Properties.Settings.Default.tempPRICE;
            String itemURL = Properties.Settings.Default.tempURL;
            int avaliableIndex = locateIndex();
            if (itemName != "")
            {
                //Valid name
                if (!avaliableIndex.Equals(-1))
                {
                    add(avaliableIndex, itemName, itemCost, itemURL);
                    this.Close();
                    main.Show();
                }
                else
                {
                    this.Close();
                    main.Show();
                }
            }
            else
            {
                //No name entered
                MessageBox.Show("A name is required to track this product.","Name required", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private int locateIndex()
        {
            int identifier = 0;
            if (Properties.Settings.Default.itemSpot1 == false)
            {
                identifier = 1;
                Properties.Settings.Default.itemSpot1 = true;
            }
            else if (Properties.Settings.Default.itemSpot2 == false)
            {
                identifier = 2;
                Properties.Settings.Default.itemSpot2 = true;
            }
            else if (Properties.Settings.Default.itemSpot3 == false)
            {
                identifier = 3;
                Properties.Settings.Default.itemSpot3 = true;
            }
            else if (Properties.Settings.Default.itemSpot4 == false)
            {
                identifier = 4;
                Properties.Settings.Default.itemSpot4 = true;
            }
            else if (Properties.Settings.Default.itemSpot5 == false)
            {
                identifier = 5;
                Properties.Settings.Default.itemSpot5 = true;
            }
            else
            {
                identifier = -1;
                MessageBox.Show("All trackers are occupied (limit 5)", "No available trackers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return identifier;
        }

        private void add(int avaliableIndex, String itemName, String itemCost, String itemURL)
        {
            switch (avaliableIndex)
            {
                case 1:
                    Properties.Settings.Default.itemSpot1 = true;
                    Properties.Settings.Default.item1 = itemName;
                    Properties.Settings.Default.price1 = itemCost;
                    Properties.Settings.Default.item1URL = itemURL;
                    break;
                case 2:
                    Properties.Settings.Default.itemSpot2 = true;
                    Properties.Settings.Default.item2 = itemName;
                    Properties.Settings.Default.price2 = itemCost;
                    Properties.Settings.Default.item2URL = itemURL;
                    break;
                case 3:
                    Properties.Settings.Default.itemSpot3 = true;
                    Properties.Settings.Default.item3 = itemName;
                    Properties.Settings.Default.price3 = itemCost;
                    Properties.Settings.Default.item3URL = itemURL;
                    break;
                case 4:
                    Properties.Settings.Default.itemSpot4 = true;
                    Properties.Settings.Default.item4 = itemName;
                    Properties.Settings.Default.price4 = itemCost;
                    Properties.Settings.Default.item4URL = itemURL;
                    break;
                case 5:
                    Properties.Settings.Default.itemSpot5 = true;
                    Properties.Settings.Default.item5 = itemName;
                    Properties.Settings.Default.price5 = itemCost;
                    Properties.Settings.Default.item5URL = itemURL;
                    break;
            }

        }

    }

}



