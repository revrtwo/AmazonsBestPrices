using System;
using System.IO;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class itemView : Form
    {
        public String urlText = "Click here for item webpage";
        public String nullString = "No item is being tracked here";
        public Boolean completed;
        public static String currentItem = "";

        public itemView()
        {
            InitializeComponent();
        }

        private void itemView_Load(object sender, EventArgs e)
        {
            
        }

        public String getCurrentRefresh()
        {
            return currentItem;
        }

        public void refreshNames()
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
                if (Properties.Settings.Default.item1URL.Length >= 75)
                    label3.Text = Properties.Settings.Default.item1URL.Substring(0, 75) + "...";
                else
                    label3.Text = Properties.Settings.Default.item1URL;
                tabPage1.Text = Properties.Settings.Default.item1;
                updatePrices(1);
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
                if (Properties.Settings.Default.item2URL.Length >= 75)
                    label6.Text = Properties.Settings.Default.item2URL.Substring(0, 75) + "...";
                else
                    label6.Text = Properties.Settings.Default.item2URL;
                tabPage2.Text = Properties.Settings.Default.item2;
                updatePrices(2);
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
                if (Properties.Settings.Default.item3URL.Length >= 75)
                    label9.Text = Properties.Settings.Default.item3URL.Substring(0, 75) + "...";
                else
                    label9.Text = Properties.Settings.Default.item3URL;
                tabPage3.Text = Properties.Settings.Default.item3;
                updatePrices(3);
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
                if (Properties.Settings.Default.item4URL.Length >= 75)
                    label12.Text = Properties.Settings.Default.item4URL.Substring(0, 75) + "...";
                else
                    label12.Text = Properties.Settings.Default.item4URL;
                tabPage4.Text = Properties.Settings.Default.item4;
                updatePrices(4);
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
                if (Properties.Settings.Default.item5URL.Length >= 75)
                    label15.Text = Properties.Settings.Default.item5URL.Substring(0, 75) + "...";
                else
                    label15.Text = Properties.Settings.Default.item5URL;
                tabPage5.Text = Properties.Settings.Default.item5;
                updatePrices(5);
            }
            currentItem = "finished";
        }
        //Method in development
        //If path == true, possible err
        private void updatePrices(int identifier)
        {
            switch (identifier)
            {
                case 1:
                    Directory.CreateDirectory("item1");
                    if (!File.Exists(@"item1\item1.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(@"item1\item1.txt"))
                        {
                            sw.WriteLine(Properties.Settings.Default.price1);
                        }
                    }
                    else
                    {
                        checkPrice(1);
                    }
                    StreamReader tabOne = new System.IO.StreamReader(@"item1\item1.txt");
                    richTextBox1.Text = tabOne.ReadToEnd(); tabOne.Close(); tabOne.Close();
                    break;
                case 2:
                    Directory.CreateDirectory("Item2");
                    if (!File.Exists(@"item2\item2.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(@"item2\item2.txt"))
                        {
                            sw.WriteLine(Properties.Settings.Default.price2);
                        }
                    }
                    else
                    {
                        checkPrice(2);
                    }
                    StreamReader tabTwo = new System.IO.StreamReader(@"item2\item2.txt");
                    richTextBox2.Text = tabTwo.ReadToEnd(); tabTwo.Close();
                    break;
                case 3:
                    Directory.CreateDirectory("Item3");
                    if (!File.Exists(@"item3\item3.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(@"item3\item3.txt"))
                        {
                            sw.WriteLine(Properties.Settings.Default.price3);
                        }
                    }
                    else
                    {
                        checkPrice(3);
                    }
                    StreamReader tabThree = new System.IO.StreamReader(@"item3\item3.txt");
                    richTextBox3.Text = tabThree.ReadToEnd(); tabThree.Close();
                    break;
                case 4:
                    Directory.CreateDirectory("Item4");
                    if (!File.Exists(@"item4\item4.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(@"item4\item4.txt"))
                        {
                            sw.WriteLine(Properties.Settings.Default.price4);
                        }
                    }
                    else
                    {
                       checkPrice(4);
                    }
                    StreamReader tabFour = new System.IO.StreamReader(@"item4\item4.txt");
                    richTextBox4.Text = tabFour.ReadToEnd(); tabFour.Close();
                    break;
                case 5:
                    Directory.CreateDirectory("Item5");
                    if (!File.Exists(@"item5\item5.txt"))
                    {
                        using (StreamWriter sw = File.CreateText(@"item5\item5.txt"))
                        {
                            sw.WriteLine(Properties.Settings.Default.price5);
                        }
                    }
                    else
                    {
                        checkPrice(5);
                    }
                    StreamReader tabFive = new System.IO.StreamReader(@"item5\item5.txt");
                    richTextBox5.Text = tabFive.ReadToEnd(); tabFive.Close(); 
                    break;
            }
        }

        private void checkPrice(int identifier)
        {
            String itemPrice = "";
            String updatePrice = "";
            webTimer.Start();
            switch (identifier)
            {
                case 1:
                    webBrowser1.Navigate(Properties.Settings.Default.item1URL);
                    currentItem = "Updating " + Properties.Settings.Default.item1;
                    while (completed == true)
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price1;
                            updatePrice = webBrowser1.Document.GetElementById("priceblock_ourprice").OuterText;
                            if(itemPrice != updatePrice)
                            {
                                StreamWriter sw = new StreamWriter(@"item1\item1.txt", true);
                                Properties.Settings.Default.price1 = updatePrice;
                                sw.WriteLine(updatePrice);
                                label2.Text = updatePrice;
                                sw.Close();
                                break;
                                
                            }
                            else
                            {
                                //No update found
                                break;
                            }
                        }
                        catch
                        {
                            try
                            {
                                itemPrice = Properties.Settings.Default.price1;
                                updatePrice = webBrowser1.Document.GetElementById("priceblock_dealprice").OuterText;
                                if (itemPrice != updatePrice)
                                {
                                    StreamWriter sw = new StreamWriter(@"item1\item1.txt", true);
                                    Properties.Settings.Default.price1 = updatePrice;
                                    sw.WriteLine(updatePrice);
                                    label2.Text = updatePrice;
                                    sw.Close();
                                    break;

                                }
                                else
                                {
                                    //No update found
                                    break;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Price update was not found","Item Not Avaliable");
                                break;
                            }
                        }
                    }
                    break;

                case 2:
                    webBrowser1.Navigate(Properties.Settings.Default.item2URL);
                    currentItem = "Updating " + Properties.Settings.Default.item2;
                    while (completed == true)
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price2;
                            updatePrice = webBrowser1.Document.GetElementById("priceblock_ourprice").OuterText;
                            if (itemPrice != updatePrice)
                            {
                                StreamWriter sw = new StreamWriter(@"item2\item2.txt", true);
                                Properties.Settings.Default.price2 = updatePrice;
                                sw.WriteLine(updatePrice);
                                label5.Text = updatePrice;
                                sw.Close();
                                break;

                            }
                            else
                            {
                                //No update found
                                break;
                            }
                        }
                        catch
                        {
                            try
                            {
                                itemPrice = Properties.Settings.Default.price2;
                                updatePrice = webBrowser1.Document.GetElementById("priceblock_dealprice").OuterText;
                                if (itemPrice != updatePrice)
                                {
                                    StreamWriter sw = new StreamWriter(@"item2\item2.txt", true);
                                    Properties.Settings.Default.price2 = updatePrice;
                                    sw.WriteLine(updatePrice);
                                    label5.Text = updatePrice;
                                    sw.Close();
                                    break;

                                }
                                else
                                {
                                    //No update found
                                    break;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Price update was not found", "Item Not Avaliable");
                                break;
                            }
                        }
                    }
                    break;

                case 3:
                    webBrowser1.Navigate(Properties.Settings.Default.item3URL);
                    currentItem = "Updating " + Properties.Settings.Default.item3;
                    while (completed == true)
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price3;
                            updatePrice = webBrowser1.Document.GetElementById("priceblock_ourprice").OuterText;
                            if (itemPrice != updatePrice)
                            {
                                StreamWriter sw = new StreamWriter(@"item3\item3.txt", true);
                                Properties.Settings.Default.price3 = updatePrice;
                                sw.WriteLine(updatePrice);
                                label8.Text = updatePrice;
                                sw.Close();
                                break;

                            }
                            else
                            {
                                //No update found
                                break;
                            }
                        }
                        catch
                        {
                            try
                            {
                                itemPrice = Properties.Settings.Default.price3;
                                updatePrice = webBrowser1.Document.GetElementById("priceblock_dealprice").OuterText;
                                if (itemPrice != updatePrice)
                                {
                                    StreamWriter sw = new StreamWriter(@"item3\item3.txt", true);
                                    Properties.Settings.Default.price3 = updatePrice;
                                    sw.WriteLine(updatePrice);
                                    label8.Text = updatePrice;
                                    sw.Close();
                                    break;

                                }
                                else
                                {
                                    //No update found
                                    break;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Price update was not found", "Item Not Avaliable");
                                break;
                            }
                        }
                    }
                    break;

                case 4:
                    webBrowser1.Navigate(Properties.Settings.Default.item4URL);
                    currentItem = "Updating " + Properties.Settings.Default.item4;
                    while (completed == true)
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price4;
                            updatePrice = webBrowser1.Document.GetElementById("priceblock_ourprice").OuterText;
                            if (itemPrice != updatePrice)
                            {
                                StreamWriter sw = new StreamWriter(@"item4\item4.txt", true);
                                Properties.Settings.Default.price4 = updatePrice;
                                sw.WriteLine(updatePrice);
                                label11.Text = updatePrice;
                                sw.Close();
                                break;

                            }
                            else
                            {
                                //No update found
                                break;
                            }
                        }
                        catch
                        {
                            try
                            {
                                itemPrice = Properties.Settings.Default.price4;
                                updatePrice = webBrowser1.Document.GetElementById("priceblock_dealprice").OuterText;
                                if (itemPrice != updatePrice)
                                {
                                    StreamWriter sw = new StreamWriter(@"item4\item4.txt", true);
                                    Properties.Settings.Default.price4 = updatePrice;
                                    sw.WriteLine(updatePrice);
                                    label11.Text = updatePrice;
                                    sw.Close();
                                    break;

                                }
                                else
                                {
                                    //No update found
                                    break;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Price update was not found", "Item Not Avaliable");
                                break;
                            }
                        }
                    }
                    break;

                case 5:
                    webBrowser1.Navigate(Properties.Settings.Default.item5URL);
                    currentItem = "Updating " + Properties.Settings.Default.item5;
                    while (completed == true)
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price5;
                            updatePrice = webBrowser1.Document.GetElementById("priceblock_ourprice").OuterText;
                            if (itemPrice != updatePrice)
                            {
                                StreamWriter sw = new StreamWriter(@"item5\item5.txt", true);
                                Properties.Settings.Default.price5 = updatePrice;
                                sw.WriteLine(updatePrice);
                                label14.Text = updatePrice;
                                sw.Close();
                                break;

                            }
                            else
                            {
                                //No update found
                                break;
                            }
                        }
                        catch
                        {
                            try
                            {
                                itemPrice = Properties.Settings.Default.price5;
                                updatePrice = webBrowser1.Document.GetElementById("priceblock_dealprice").OuterText;
                                if (itemPrice != updatePrice)
                                {
                                    StreamWriter sw = new StreamWriter(@"item5\item5.txt", true);
                                    Properties.Settings.Default.price5 = updatePrice;
                                    sw.WriteLine(updatePrice);
                                    label14.Text = updatePrice;
                                    sw.Close();
                                    break;

                                }
                                else
                                {
                                    //No update found
                                    break;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Price update was not found", "Item Not Avaliable");
                                break;
                            }
                        }
                    }
                    break;


            }
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
                    if(Directory.Exists(@"item1"))
                    {
                        Directory.Delete(@"item1", true);
                    }
                    richTextBox1.Text = null;
                    break;
                case 2:
                    Properties.Settings.Default.itemSpot2 = false;
                    Properties.Settings.Default.item2 = "";
                    Properties.Settings.Default.price2 = "";
                    Properties.Settings.Default.item2URL = "";
                    if (Directory.Exists(@"item2"))
                    {
                        Directory.Delete(@"item2", true);
                    }
                    richTextBox2.Text = null;
                    break;
                case 3:
                    Properties.Settings.Default.itemSpot3 = false;
                    Properties.Settings.Default.item3 = "";
                    Properties.Settings.Default.price3 = "";
                    Properties.Settings.Default.item3URL = "";
                    if (Directory.Exists(@"item3"))
                    {
                        Directory.Delete(@"item3", true);
                    }
                    richTextBox3.Text = null;
                    break;
                case 4:
                    Properties.Settings.Default.itemSpot4 = false;
                    Properties.Settings.Default.item4 = "";
                    Properties.Settings.Default.price4 = "";
                    Properties.Settings.Default.item4URL = "";
                    if (Directory.Exists(@"item4"))
                    {
                        Directory.Delete(@"item4", true);
                    }
                    richTextBox4.Text = null;
                    break;
                case 5:
                    Properties.Settings.Default.itemSpot5 = false;
                    Properties.Settings.Default.item5 = "";
                    Properties.Settings.Default.price5 = "";
                    Properties.Settings.Default.item5URL = "";
                    if (Directory.Exists(@"item5"))
                    {
                        Directory.Delete(@"item5", true);
                    }
                    richTextBox5.Text = null;
                    break;
            }
        }
        //<--- Delete button actions --->
        private void button1_Click(object sender, EventArgs e)
        {
            int identifier = 1;
            deleteThis(identifier);
            refreshNames();
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

        //<--- Link label actions --->
        private void label3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.item1URL);
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

        private void webTimer_Tick(object sender, EventArgs e)
        {
            if(webTimer.Interval == 1)
            {
                completed = true;
                webTimer.Stop();
            }
        }
  
    }
}
