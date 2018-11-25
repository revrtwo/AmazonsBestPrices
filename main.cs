using System;
using System.Drawing;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class main : Form
    {
        String itemPrice;
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Loading..";
            button2.Enabled = false;
            pictureBox1.Visible = true;
            try
            {
                Properties.Settings.Default.tempITEM = "";
                Properties.Settings.Default.tempPRICE = "";
                progressBar1.Value = 0;
                webBrowser1.Navigate(textBox1.Text);
                setURL(textBox1.Text);
                timer2.Start();
            }
            catch
            {
               MessageBox.Show("An error has occured, please try again.", "URL Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            option option = new option();
            option.Show();
            this.Hide();
        }

        private void checkName()
        {
            try
            {
                String itemName = webBrowser1.Document.GetElementById("productTitle").OuterText;
                if(itemName.Length>= 80)
                {
                    String visibleName = itemName.Substring(0, 80);
                    label2.Text = "Item Price: " + visibleName;
                }
                else
                {
                    label2.Text = "Item Price: " + itemName;
                }
                Properties.Settings.Default.tempITEM = itemName;  
            }
            catch
            {
                MessageBox.Show("Sorry, the name of the item was not found.", "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label2.Text = "Item name: Item not found";
            }
        }

        private void checkPrice()
        {
                try
                {
                    itemPrice = webBrowser1.Document.GetElementById("priceblock_ourprice").OuterText;
                    Properties.Settings.Default.tempPRICE = itemPrice;
                }
                catch
                {
                    try
                    {
                        if (itemPrice == null)
                        {
                        itemPrice = webBrowser1.Document.GetElementById("priceblock_dealprice").OuterText;
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
                MessageBox.Show("Sorry, the price of that item was not found.", "Price Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label3.Text = "Item price: Price not found"; 
                }
                else
                    label3.Text = "Item Price: " + itemPrice;
                button2.Enabled = true;
                Properties.Settings.Default.tempPRICE = itemPrice;
 
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button1.Enabled = false;
            progressBar1.Increment(+1);
            if (progressBar1.Value == 100)
            {
                timer2.Stop();
                button1.Text = "Search";
                checkName();
                checkPrice();
                button1.Enabled = true;
                button1.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        public String getName()
        {
            return Properties.Settings.Default.tempITEM;
        }

        public String getPrice()
        {
            return Properties.Settings.Default.tempPRICE;
        }

        public String getURL()
        {
            return Properties.Settings.Default.tempURL;
        }

        public void setURL(String url)
        {
            Properties.Settings.Default.tempURL = url;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(webBrowser1.Document.GetElementById("productTitle").OuterText);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            itemView viewer = new itemView();
            viewer.Show();
        }

    }
}
