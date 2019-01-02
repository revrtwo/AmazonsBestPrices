using System;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class main : Form
    {
        String itemPrice;
        public Boolean completed;
        static WebBrowser web = new WebBrowser();

        public main()
        {
            InitializeComponent();
        }

        private void setCompleted()
        {
            completed = true;
        }

        private Boolean checkCompleted()
        {
            return completed;
        }

        private void setURL(String url)
        {
            Properties.Settings.Default.tempURL = url;
        }

        private void main_Load(object sender, EventArgs e)
        {
            web.ScriptErrorsSuppressed = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            option option = new option();
            option.Show();
            this.Hide();
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            itemView showCase = new itemView();
            showCase.Show();
        }

        public void searchBtn_Click(object sender, EventArgs e)
        {
            searchBtn.Text = "Loading..";
            completed = false;
            searchBtn.Enabled = false;
            addBtn.Enabled = false;
            viewBtn.Enabled = false;
            pictureBox1.Visible = true;
            try
            {
                Properties.Settings.Default.tempITEM = "";
                Properties.Settings.Default.tempPRICE = "";
                web.Navigate(textBox1.Text);
                setURL(textBox1.Text);
                web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(pageCompleted);
                completedChecker.Start();
            }
            catch
            {
               MessageBox.Show("An error has occured, please try again.", "URL error",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void checkName()
        {
            try
            {
                String itemName = web.Document.GetElementById("productTitle").OuterText;
                if(itemName.Length>= 72)
                {
                    String visibleName = itemName.Substring(0, 72);
                    label2.Text = "Item Name: " + visibleName + "...";
                }
                else
                {
                    label2.Text = "Item Name: " + itemName;
                }
                Properties.Settings.Default.tempITEM = itemName;  
            }
            catch
            {
                MessageBox.Show("Sorry, the name of the item was not found.", "Item not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label2.Text = "Item name: Item not found";
            }
        }

        private void checkPrice()
        {
                try
                {
                    itemPrice = web.Document.GetElementById("priceblock_ourprice").OuterText;
                    Properties.Settings.Default.tempPRICE = itemPrice;
                }
                catch
                {
                    try
                    {
                        if (itemPrice == null)
                        {
                        itemPrice = web.Document.GetElementById("priceblock_dealprice").OuterText;
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
                MessageBox.Show("Sorry, the price of that item was not found.", "Price not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label3.Text = "Item price: Price not found";
                addBtn.Enabled = false;
            }
            else
            {
                label3.Text = "Item Price: " + itemPrice;
                addBtn.Enabled = true;
                viewBtn.Enabled = true;
                Properties.Settings.Default.tempPRICE = itemPrice;
            }
        }

        private void completedChecker_Tick(object sender, EventArgs e)
        {
            searchBtn.Enabled = false;
            if (checkCompleted())
            {
                completedChecker.Stop();
                searchBtn.Text = "Search";
                checkName();
                checkPrice();
                searchBtn.Enabled = true;
                viewBtn.Enabled = true;
                pictureBox1.Visible = false;
            }
        }

        //Dev. test button
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void pageCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            setCompleted();
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Exit();
        }

    }
}
