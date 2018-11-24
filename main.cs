using System;
using System.Drawing;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Loading..";
            button2.Enabled = false;
            pictureBox1.Visible = true;
            try
            {
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
                String visibleName = itemName.Substring(0, 82);
                label2.Text = "Item Price: " + visibleName;
                Properties.Settings.Default.tempITEM = itemName;


            }
            catch
            {
                label2.Text = "Item name: Item not found";
                MessageBox.Show("Sorry, the name of the item was not found.", "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkPrice()
        {
            try
            {
                String itemPrice = webBrowser1.Document.GetElementById("priceblock_ourprice").OuterText;
                label3.Text = "Item Price: " + itemPrice;
                button2.Enabled = true;
                Properties.Settings.Default.tempPRICE = itemPrice;
            }
            catch
            {
                label3.Text = "Item price: Price not found";
                MessageBox.Show("Sorry, the price of that item was not found.","Price Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void main_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.tempITEM);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            itemView viewer = new itemView();
            viewer.Show();
        }
    }
}
