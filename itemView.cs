using System;
using System.IO;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class itemView : Form
    {
        public String urlText = "Click here for item webpage";
        public String nullString = "No item is being tracked here";
        public String lastRefresh;
        public Boolean completed1;
        public Boolean completed2;
        public Boolean completed3;
        public Boolean completed4;
        public Boolean completed5;
        public Boolean allowOneTimeNotify = true;
        static WebBrowser web1 = new WebBrowser();
        static WebBrowser web2 = new WebBrowser();
        static WebBrowser web3 = new WebBrowser();
        static WebBrowser web4 = new WebBrowser();
        static WebBrowser web5 = new WebBrowser();
        public int currentUpdating;
        public int devCnt;
        public itemView()
        {
            InitializeComponent();
        }

        public void setCompleted(int identifier)
        {
            switch (identifier)
            {
                case 1:
                    completed1 = true;
                    break;
                case 2:
                    completed2 = true;
                    break;
                case 3:
                    completed3 = true;
                    break;
                case 4:
                    completed4 = true;
                    break;
                case 5:
                    completed5 = true;
                    break;
            }
        }

        public Boolean checkCompleted(int identifier)
        {
            switch (identifier)
            {
                case 1:
                    return completed1;
                case 2:
                    return completed2;
                case 3:
                    return completed3;
                case 4:
                    return completed4;
                case 5:
                    return completed5;
            }
            return false;
        }

        public String returnLastUpdate()
        {
            return lastRefresh;
        }

        public void setCompletedFalse()
        {
            completed1 = false;
            completed2 = false;
            completed3 = false;
            completed4 = false;
            completed5 = false;
        }

        public void supressScriptErrors()
        {
            web1.ScriptErrorsSuppressed = true;
            web2.ScriptErrorsSuppressed = true;
            web3.ScriptErrorsSuppressed = true;
            web4.ScriptErrorsSuppressed = true;
            web5.ScriptErrorsSuppressed = true;
        }

        private void setTimerInterval()
        {
            try
            {
                updateTimer.Interval = returnTime(Properties.Settings.Default.updateInterval);
            }
            catch
            {

            }
        }

        private void itemView_Load(object sender, EventArgs e)
        {
            supressScriptErrors();
            setTimerInterval();
            currentUpdating = -1;
            refreshNames();
        }

        public void refreshNames()
        {
            lastRefresh = DateTime.Now.ToString();
            if (Properties.Settings.Default.allowBackgroundUpdates.Equals(true))
            {
                updateTimer.Start();
            }

            //Tab One
            if (Properties.Settings.Default.itemSpot1 == false)
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
                if (Properties.Settings.Default.hideURL.Equals(true))
                {
                    label3.Text = urlText;
                }
                else
                {
                    if (Properties.Settings.Default.item1URL.Length >= 75)
                        label3.Text = Properties.Settings.Default.item1URL.Substring(0, 75) + "...";
                    else
                        label3.Text = Properties.Settings.Default.item1URL;
                }
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
                if (Properties.Settings.Default.hideURL.Equals(true))
                {
                    label6.Text = urlText;
                }
                else
                {
                    if (Properties.Settings.Default.item2URL.Length >= 75)
                        label6.Text = Properties.Settings.Default.item2URL.Substring(0, 75) + "...";
                    else
                        label6.Text = Properties.Settings.Default.item2URL;
                }
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
                if (Properties.Settings.Default.hideURL.Equals(true))
                {
                    label9.Text = urlText;
                }
                else
                {
                    if (Properties.Settings.Default.item3URL.Length >= 75)
                        label9.Text = Properties.Settings.Default.item3URL.Substring(0, 75) + "...";
                    else
                        label9.Text = Properties.Settings.Default.item3URL;
                }
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
                if (Properties.Settings.Default.hideURL.Equals(true))
                {
                    label12.Text = urlText;
                }
                else
                {
                    if (Properties.Settings.Default.item4URL.Length >= 75)
                        label12.Text = Properties.Settings.Default.item4URL.Substring(0, 75) + "...";
                    else
                        label12.Text = Properties.Settings.Default.item4URL;
                }
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
                if (Properties.Settings.Default.hideURL.Equals(true))
                {
                    label15.Text = urlText;
                }
                else
                {
                    if (Properties.Settings.Default.item5URL.Length >= 75)
                        label15.Text = Properties.Settings.Default.item5URL.Substring(0, 75) + "...";
                    else
                        label15.Text = Properties.Settings.Default.item5URL;
                }
                tabPage5.Text = Properties.Settings.Default.item5;
                updatePrices(5);
            }
        }

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
                        item1Status.Image = Properties.Resources.spinLoader;
                        setupBrowser(1);
                    }
                    StreamReader tabOne = new StreamReader(@"item1\item1.txt");
                    richTextBox1.Text = tabOne.ReadToEnd(); tabOne.Close();
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
                        item2Status.Image = Properties.Resources.spinLoader;
                        setupBrowser(2);
                    }
                    StreamReader tabTwo = new StreamReader(@"item2\item2.txt");
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
                        item3Status.Image = Properties.Resources.spinLoader;
                        setupBrowser(3);
                    }
                    StreamReader tabThree = new StreamReader(@"item3\item3.txt");
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
                        item4Status.Image = Properties.Resources.spinLoader;
                        setupBrowser(4);
                    }
                    StreamReader tabFour = new StreamReader(@"item4\item4.txt");
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
                        item5Status.Image = Properties.Resources.spinLoader;
                        setupBrowser(5);
                    }
                    StreamReader tabFive = new StreamReader(@"item5\item5.txt");
                    richTextBox5.Text = tabFive.ReadToEnd(); tabFive.Close();
                    break;
            }
        }

        private void setupBrowser(int identifier)
        {
            setCompletedFalse();
            switch (identifier)
            {
                case 1:
                    currentUpdating = 1;
                    web1.Navigate(Properties.Settings.Default.item1URL);
                    web1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(pageCompleted1);
                    completedChecker1.Start();
                    break;

                case 2:
                    currentUpdating = 2;
                    web2.Navigate(Properties.Settings.Default.item2URL);
                    web2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(pageCompleted2);
                    completedChecker2.Start();
                    break;

                case 3:
                    currentUpdating = 3;
                    web3.Navigate(Properties.Settings.Default.item3URL);
                    web3.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(pageCompleted3);
                    completedChecker3.Start();
                    break;

                case 4:
                    currentUpdating = 4;
                    web4.Navigate(Properties.Settings.Default.item4URL);
                    web4.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(pageCompleted4);
                    completedChecker4.Start();
                    break;

                case 5:
                    currentUpdating = 5;
                    web5.Navigate(Properties.Settings.Default.item5URL);
                    web5.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(pageCompleted5);
                    completedChecker5.Start();
                    break;
            }
        }

        private void checkPriceUpdate(int identifier)
        {
            String itemPrice = "";
            String updatePrice = "";
            switch (identifier)
            {
                case 1:
                    try
                    {
                        itemPrice = Properties.Settings.Default.price1;
                        updatePrice = web1.Document.GetElementById("priceblock_ourprice").OuterText;
                        if (!itemPrice.Equals(updatePrice))
                        {
                            StreamWriter sw = new StreamWriter(@"item1\item1.txt", true);
                            if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                item1Status.Image = (Properties.Resources.priceDown);
                            else
                                item1Status.Image = (Properties.Resources.priceUp);
                            Properties.Settings.Default.price1 = updatePrice;
                            sw.WriteLine(updatePrice); sw.Close();
                            label2.Text = updatePrice;
                            Properties.Settings.Default.Save();
                            web1.Stop();
                            break;
                        }
                        else
                        {
                            item1Status.Image = Properties.Resources.samePrice;
                            web1.Stop();
                            break;
                        }
                    }
                    catch
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price1;
                            updatePrice = web1.Document.GetElementById("priceblock_dealprice").OuterText;
                            if (!itemPrice.Equals(updatePrice))
                            {
                                StreamWriter sw = new StreamWriter(@"item1\item1.txt", true);
                                if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                    item1Status.Image = (Properties.Resources.priceDown);
                                else
                                    item1Status.Image = (Properties.Resources.priceUp);
                                Properties.Settings.Default.price1 = updatePrice;
                                sw.WriteLine(updatePrice); sw.Close();
                                label2.Text = updatePrice;
                                Properties.Settings.Default.Save();
                                web1.Stop();
                                break;
                            }
                            else
                            {
                                item1Status.Image = Properties.Resources.samePrice;
                                web1.Stop();
                                break;
                            }
                        }
                        catch
                        {
                            //Item not found / Not Avaliable
                            item1Status.Image = Properties.Resources.notFound;
                            web1.Stop();
                            break;
                        }
                    }

                case 2:
                    try
                    {
                        itemPrice = Properties.Settings.Default.price2;
                        updatePrice = web2.Document.GetElementById("priceblock_ourprice").OuterText;
                        if (!itemPrice.Equals(updatePrice))
                        {
                            StreamWriter sw = new StreamWriter(@"item2\item2.txt", true);
                            if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                item2Status.Image = (Properties.Resources.priceDown);
                            else
                                item2Status.Image = (Properties.Resources.priceUp);
                            Properties.Settings.Default.price2 = updatePrice;
                            sw.WriteLine(updatePrice); sw.Close();
                            label5.Text = updatePrice;
                            Properties.Settings.Default.Save();
                            web2.Stop();
                            break;
                        }
                        else
                        {
                            item2Status.Image = Properties.Resources.samePrice;
                            web2.Stop();
                            break;
                        }
                    }
                    catch
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price2;
                            updatePrice = web2.Document.GetElementById("priceblock_dealprice").OuterText;
                            if (!itemPrice.Equals(updatePrice))
                            {
                                StreamWriter sw = new StreamWriter(@"item2\item2.txt", true);
                                if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                    item2Status.Image = (Properties.Resources.priceDown);
                                else
                                    item2Status.Image = (Properties.Resources.priceUp);
                                Properties.Settings.Default.price2 = updatePrice;
                                sw.WriteLine(updatePrice); sw.Close();
                                label5.Text = updatePrice;
                                Properties.Settings.Default.Save();
                                web2.Stop();
                                break;
                            }
                            else
                            {
                                item2Status.Image = Properties.Resources.samePrice;
                                web2.Stop();
                                break;
                            }
                        }
                        catch
                        {
                            //Item not found / Not Avaliable
                            item2Status.Image = Properties.Resources.notFound;
                            web2.Stop();
                            break;
                        }
                    }

                case 3:
                    try
                    {
                        itemPrice = Properties.Settings.Default.price3;
                        updatePrice = web3.Document.GetElementById("priceblock_ourprice").OuterText;
                        if (!itemPrice.Equals(updatePrice))
                        {
                            StreamWriter sw = new StreamWriter(@"item3\item3.txt", true);
                            if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                item3Status.Image = (Properties.Resources.priceDown);
                            else
                                item3Status.Image = (Properties.Resources.priceUp);
                            Properties.Settings.Default.price3 = updatePrice;
                            sw.WriteLine(updatePrice); sw.Close();
                            label8.Text = updatePrice;
                            Properties.Settings.Default.Save();
                            web3.Stop();
                            break;
                        }
                        else
                        {
                            item3Status.Image = Properties.Resources.samePrice;
                            web3.Stop();
                            break;
                        }
                    }
                    catch
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price3;
                            updatePrice = web3.Document.GetElementById("priceblock_dealprice").OuterText;
                            if (!itemPrice.Equals(updatePrice))
                            {
                                StreamWriter sw = new StreamWriter(@"item3\item3.txt", true);
                                if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                    item3Status.Image = (Properties.Resources.priceDown);
                                else
                                    item3Status.Image = (Properties.Resources.priceUp);
                                Properties.Settings.Default.price3 = updatePrice;
                                sw.WriteLine(updatePrice); sw.Close();
                                label8.Text = updatePrice;
                                Properties.Settings.Default.Save();
                                web3.Stop();
                                break;
                            }
                            else
                            {
                                item3Status.Image = Properties.Resources.samePrice;
                                web3.Stop();
                                break;
                            }
                        }
                        catch
                        {
                            //Item not found / Not Avaliable
                            item3Status.Image = Properties.Resources.notFound;
                            web3.Stop();
                            break;
                        }
                    }

                case 4:
                    try
                    {
                        itemPrice = Properties.Settings.Default.price4;
                        updatePrice = web4.Document.GetElementById("priceblock_ourprice").OuterText;
                        if (!itemPrice.Equals(updatePrice))
                        {
                            StreamWriter sw = new StreamWriter(@"item4\item4.txt", true);
                            if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                item4Status.Image = (Properties.Resources.priceDown);
                            else
                                item4Status.Image = (Properties.Resources.priceUp);
                            Properties.Settings.Default.price4 = updatePrice;
                            sw.WriteLine(updatePrice); sw.Close();
                            label11.Text = updatePrice;
                            Properties.Settings.Default.Save();
                            web4.Stop();
                            break;
                        }
                        else
                        {
                            item4Status.Image = Properties.Resources.samePrice;
                            web4.Stop();
                            break;
                        }
                    }
                    catch
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price4;
                            updatePrice = web4.Document.GetElementById("priceblock_dealprice").OuterText;
                            if (!itemPrice.Equals(updatePrice))
                            {
                                StreamWriter sw = new StreamWriter(@"item4\item4.txt", true);
                                if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                    item4Status.Image = (Properties.Resources.priceDown);
                                else
                                    item4Status.Image = (Properties.Resources.priceUp);
                                Properties.Settings.Default.price4 = updatePrice;
                                sw.WriteLine(updatePrice); sw.Close();
                                label11.Text = updatePrice;
                                Properties.Settings.Default.Save();
                                web4.Stop();
                                break;
                            }
                            else
                            {
                                item4Status.Image = Properties.Resources.samePrice;
                                web4.Stop();
                                break;
                            }
                        }
                        catch
                        {
                            //Item not found / Not Avaliable
                            item4Status.Image = Properties.Resources.notFound;
                            web4.Stop();
                            break;
                        }
                    }

                case 5:
                    try
                    {
                        itemPrice = Properties.Settings.Default.price5;
                        updatePrice = web5.Document.GetElementById("priceblock_ourprice").OuterText;
                        if (!itemPrice.Equals(updatePrice))
                        {
                            StreamWriter sw = new StreamWriter(@"item5\item5.txt", true);
                            if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                item5Status.Image = (Properties.Resources.priceDown);
                            else
                                item5Status.Image = (Properties.Resources.priceUp);
                            Properties.Settings.Default.price5 = updatePrice;
                            sw.WriteLine(updatePrice); sw.Close();
                            label14.Text = updatePrice;
                            Properties.Settings.Default.Save();
                            web5.Stop();
                            break;
                        }
                        else
                        {
                            item5Status.Image = Properties.Resources.samePrice;
                            web5.Stop();
                            break;
                        }
                    }
                    catch
                    {
                        try
                        {
                            itemPrice = Properties.Settings.Default.price5;
                            updatePrice = web5.Document.GetElementById("priceblock_dealprice").OuterText;
                            if (!itemPrice.Equals(updatePrice))
                            {
                                StreamWriter sw = new StreamWriter(@"item5\item5.txt", true);
                                if (checkPriceIncrease(updatePrice, identifier).Equals(false))
                                    item5Status.Image = (Properties.Resources.priceDown);
                                else
                                    item5Status.Image = (Properties.Resources.priceUp);
                                Properties.Settings.Default.price5 = updatePrice;
                                sw.WriteLine(updatePrice); sw.Close();
                                label14.Text = updatePrice;
                                Properties.Settings.Default.Save();
                                web5.Stop();
                                break;
                            }
                            else
                            {
                                item5Status.Image = Properties.Resources.samePrice;
                                web5.Stop();
                                break;
                            }
                        }
                        catch
                        {
                            //Item not found / Not Avaliable
                            item5Status.Image = Properties.Resources.notFound;
                            web5.Stop();
                            break;
                        }
                    }


            }
        }

        //False: Price decreased, True: Price increased
        public Boolean checkPriceIncrease(String newPrice, int identifier)
        { 
            Boolean priceIncrease = false;
            double initialPrice;
            double newPriceS;
            double change;
            switch (identifier)
            {
                case 1:
                    initialPrice = Double.Parse(Properties.Settings.Default.price1.Substring(1, Properties.Settings.Default.price1.Length-1));
                    newPriceS = Double.Parse(newPrice.Substring(1,newPrice.Length-1));
                    if (newPriceS > initialPrice)
                    {
                        change = newPriceS - initialPrice;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(true, change, Properties.Settings.Default.item1, Properties.Settings.Default.price1, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = true;
                    }
                    else
                    {
                        change = initialPrice - newPriceS;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(true, change, Properties.Settings.Default.item1, Properties.Settings.Default.price1, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = false;
                    }
                    break;

                case 2:
                    initialPrice = Double.Parse(Properties.Settings.Default.price2.Substring(1, Properties.Settings.Default.price2.Length - 1));
                    newPriceS = Double.Parse(newPrice.Substring(1, newPrice.Length - 1));
                    if (newPriceS > initialPrice)
                    {
                        change = newPriceS - initialPrice;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(true, change, Properties.Settings.Default.item2, Properties.Settings.Default.price2, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = true;
                    }
                    else
                    {
                        change = initialPrice - newPriceS;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(false, change, Properties.Settings.Default.item2, Properties.Settings.Default.price2, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = false;
                    }
                    break;

                case 3:
                    initialPrice = Double.Parse(Properties.Settings.Default.price3.Substring(1, Properties.Settings.Default.price3.Length - 1));
                    newPriceS = Double.Parse(newPrice.Substring(1, newPrice.Length - 1));
                    if (newPriceS > initialPrice)
                    {
                        change = newPriceS - initialPrice;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(true, change, Properties.Settings.Default.item3, Properties.Settings.Default.price3, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = true;
                    }
                    else
                    {
                        change = initialPrice - newPriceS;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(false, change, Properties.Settings.Default.item3, Properties.Settings.Default.price3, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = false;
                    }
                    break;

                case 4:
                    initialPrice = Double.Parse(Properties.Settings.Default.price4.Substring(1, Properties.Settings.Default.price4.Length - 1));
                    newPriceS = Double.Parse(newPrice.Substring(1, newPrice.Length - 1));
                    if (newPriceS > initialPrice)
                    {
                        change = newPriceS - initialPrice;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(true, change, Properties.Settings.Default.item4, Properties.Settings.Default.price4, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = true;
                    }
                    else
                    {
                        change = initialPrice - newPriceS;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(false, change, Properties.Settings.Default.item4, Properties.Settings.Default.price4, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = false;
                    }
                    break;

                case 5:
                    initialPrice = Double.Parse(Properties.Settings.Default.price5.Substring(1, Properties.Settings.Default.price5.Length - 1));
                    newPriceS = Double.Parse(newPrice.Substring(1, newPrice.Length - 1));
                    if (newPriceS > initialPrice)
                    {
                        change = newPriceS - initialPrice;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(true, change, Properties.Settings.Default.item5, Properties.Settings.Default.price5, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = true;
                    }
                    else
                    {
                        change = initialPrice - newPriceS;
                        if (Properties.Settings.Default.allowNotifications.Equals(true))
                            sendNotficiation(false, change, Properties.Settings.Default.item5, Properties.Settings.Default.price5, newPrice);
                        if (Properties.Settings.Default.setAsterisk.Equals(true))
                            addAsterisk(identifier);
                        priceIncrease = false;
                    }
                    break;

            }
            return priceIncrease;    
        }

        //<--- Notification sender --->
        private void sendNotficiation(Boolean increase, double change, String name, String previousCost, String newPrice)
        {
            switch (increase)
            {
                case true:
                    notifyIcon1.BalloonTipTitle = "Price increased";
                    notifyIcon1.BalloonTipText = name + "'s price is now " + newPrice + "\nPreviously: " + previousCost + "\nDifference: $" + change;
                    notifyIcon1.ShowBalloonTip(1000);
                    break;

                case false:
                    notifyIcon1.BalloonTipTitle = "Price decreased";
                    notifyIcon1.BalloonTipText = name + "'s price is now " + newPrice + "\nPreviously: " + previousCost + "\nDifference: $" + change;
                    notifyIcon1.ShowBalloonTip(1000);
                    break;
            }
        }

        //<--- Delete button actions --->
        private void button1_Click(object sender, EventArgs e)
        {
            int identifier = 1;
            deleteThis(identifier);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int identifier = 2;
            deleteThis(identifier);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int identifier = 3;
            deleteThis(identifier);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int identifier = 4;
            deleteThis(identifier);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int identifier = 5;
            deleteThis(identifier);
        }

        //<--- Delete cases --->
        public void deleteThis(int identifier)
        {
            switch (identifier)
            {
                case 1:
                    visualDelete(identifier);
                    Properties.Settings.Default.itemSpot1 = false;
                    Properties.Settings.Default.item1 = "";
                    Properties.Settings.Default.price1 = "";
                    Properties.Settings.Default.item1URL = "";
                    if (Directory.Exists(@"item1"))
                    {
                        Directory.Delete(@"item1", true);
                    }
                    Properties.Settings.Default.Save();
                    break;

                case 2:
                    visualDelete(identifier);
                    Properties.Settings.Default.itemSpot2 = false;
                    Properties.Settings.Default.item2 = "";
                    Properties.Settings.Default.price2 = "";
                    Properties.Settings.Default.item2URL = "";
                    if (Directory.Exists(@"item2"))
                    {
                        Directory.Delete(@"item2", true);
                    }
                    Properties.Settings.Default.Save();
                    break;

                case 3:
                    visualDelete(identifier);
                    Properties.Settings.Default.itemSpot3 = false;
                    Properties.Settings.Default.item3 = "";
                    Properties.Settings.Default.price3 = "";
                    Properties.Settings.Default.item3URL = "";
                    if (Directory.Exists(@"item3"))
                    {
                        Directory.Delete(@"item3", true);
                    }
                    Properties.Settings.Default.Save();
                    break;

                case 4:
                    visualDelete(identifier);
                    Properties.Settings.Default.itemSpot4 = false;
                    Properties.Settings.Default.item4 = "";
                    Properties.Settings.Default.price4 = "";
                    Properties.Settings.Default.item4URL = "";
                    if (Directory.Exists(@"item4"))
                    {
                        Directory.Delete(@"item4", true);
                    }
                    Properties.Settings.Default.Save();
                    break;

                case 5:
                    visualDelete(identifier);
                    Properties.Settings.Default.itemSpot5 = false;
                    Properties.Settings.Default.item5 = "";
                    Properties.Settings.Default.price5 = "";
                    Properties.Settings.Default.item5URL = "";
                    if (Directory.Exists(@"item5"))
                    {
                        Directory.Delete(@"item5", true);
                    }
                    Properties.Settings.Default.Save();
                    break;
            }
        }

        //<--- Clears visual items --->
        private void visualDelete(int identifier)
        {
            switch (identifier)
            {
                case 1:
                    label1.Text = nullString;
                    label2.Text = nullString;
                    label3.Text = nullString;
                    tabPage1.Text = "Empty";
                    richTextBox1.Text = null;
                    item1Status.Image = null;
                    break;
                case 2:
                    label4.Text = nullString;
                    label5.Text = nullString;
                    label6.Text = nullString;
                    tabPage2.Text = "Empty";
                    richTextBox2.Text = null;
                    item2Status.Image = null;
                    break;
                case 3:
                    label7.Text = nullString;
                    label8.Text = nullString;
                    label9.Text = nullString;
                    tabPage3.Text = "Empty";
                    richTextBox3.Text = null;
                    item3Status.Image = null;
                    break;
                case 4:
                    label10.Text = nullString;
                    label11.Text = nullString;
                    label12.Text = nullString;
                    tabPage4.Text = "Empty";
                    richTextBox4.Text = null;
                    item4Status.Image = null;
                    break;
                case 5:
                    label13.Text = nullString;
                    label14.Text = nullString;
                    label15.Text = nullString;
                    tabPage5.Text = "Empty";
                    richTextBox5.Text = null;
                    item5Status.Image = null;
                    break;
            }
        }

        //<--- Page completed checkers --->
        private void completedChecker1_Tick(object sender, EventArgs e)
        {
            if (checkCompleted(1).Equals(true))
            {
                completedChecker1.Stop();
                checkPriceUpdate(1);
            }
        }

        private void completedChecker2_Tick(object sender, EventArgs e)
        {
            if (checkCompleted(2).Equals(true))
            {
                completedChecker2.Stop();
                checkPriceUpdate(2);
            }
        }

        private void completedChecker3_Tick(object sender, EventArgs e)
        {
            if (checkCompleted(3).Equals(true))
            {
                completedChecker3.Stop();
                checkPriceUpdate(3);
            }
        }

        private void completedChecker4_Tick(object sender, EventArgs e)
        {
            if (checkCompleted(4).Equals(true))
            {
                completedChecker4.Stop();
                checkPriceUpdate(4);
            }
        }

        private void completedChecker5_Tick(object sender, EventArgs e)
        {
            if (checkCompleted(5).Equals(true))
            {
                completedChecker5.Stop();
                checkPriceUpdate(5);
            }
        }

        //<--- Add asterisk --->
        private void addAsterisk(int identifier)
        {
            switch (identifier)
            {
                case 1:
                    tabPage1.Text = "* " + Properties.Settings.Default.item1;
                    break;
                case 2:
                    tabPage2.Text = "* " + Properties.Settings.Default.item2;
                    break;
                case 3:
                    tabPage3.Text = "* " + Properties.Settings.Default.item3;
                    break;
                case 4:
                    tabPage4.Text = "* " + Properties.Settings.Default.item4;
                    break;
                case 5:
                    tabPage5.Text = "* " + Properties.Settings.Default.item5;
                    break;
            }
        }

        //<--- Link label setup --->
        private void label3_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.itemSpot1.Equals(true))
                System.Diagnostics.Process.Start(Properties.Settings.Default.item1URL);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.itemSpot2.Equals(true))
                System.Diagnostics.Process.Start(Properties.Settings.Default.item2URL);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.itemSpot3.Equals(true))
                System.Diagnostics.Process.Start(Properties.Settings.Default.item3URL);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.itemSpot4.Equals(true))
                System.Diagnostics.Process.Start(Properties.Settings.Default.item4URL);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.itemSpot5.Equals(true))
                System.Diagnostics.Process.Start(Properties.Settings.Default.item5URL);
        }

        //<--- Page completed handlers --->
        public void pageCompleted1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            setCompleted(1);
        }

        public void pageCompleted2(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            setCompleted(2);
        }

        public void pageCompleted3(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            setCompleted(3);
        }

        public void pageCompleted4(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            setCompleted(4);
        }

        public void pageCompleted5(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            setCompleted(5);
        }

        //<--- Background tracker updater --->
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            int interval = Properties.Settings.Default.updateInterval;
            int time = updateTimer.Interval;
            if (checkUsingTrackers().Equals(false))
            {
                updateTimer.Stop();
            }
            if (Properties.Settings.Default.allowBackgroundUpdates.Equals(true) && returnTime(interval) >= time && Enabled != false)
            {
                lastRefresh = DateTime.Now.ToString();
                updateTimer.Stop();
                refreshNames();
                refreshUpdateTimer();
            }
        }

        private int returnTime(int interval)
        {
            //Intervals --> || 0: 1 Hour(s) || 1: 3 Hours(s) || 2: 6 Hour(s) || 3: 8 Hour(s) ||
            int time = -1;
            switch (interval)
            {
                case 0:
                    time = 3600000;
                    break;
                case 1:
                    time = 10800000;
                    break;
                case 2:
                    time = 21600000;
                    break;
                case 3:
                    time = 28800000;
                    break;
            }
            return time;
        }

        private void refreshUpdateTimer()
        {
            updateTimer.Start();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if(FormWindowState.Minimized.Equals(true))
            contextMenuStrip1.Show();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (Enabled.Equals(true))
            {
                WindowState = FormWindowState.Normal;
                Activate();
                Show();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private Boolean checkUsingTrackers()
        {
            if (Properties.Settings.Default.itemSpot1.Equals(true))
                return true;
            else if (Properties.Settings.Default.itemSpot2.Equals(true))
                return true;
            else if (Properties.Settings.Default.itemSpot3.Equals(true))
                return true;
            else if (Properties.Settings.Default.itemSpot4.Equals(true))
                return true;
            else if (Properties.Settings.Default.itemSpot5.Equals(true))
                return true;
            else
                return false;
        }

        private void itemView_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && Properties.Settings.Default.allowBackgroundUpdates.Equals(true) && allowOneTimeNotify.Equals(true) && !checkUsingTrackers().Equals(false))
            {
                sendRunningBackground();
                allowOneTimeNotify = false;
            }           
        }

        private void sendRunningBackground()
        {
            notifyIcon1.BalloonTipTitle = "Background updates enabled";
            notifyIcon1.BalloonTipText = "Application will check for updates in the background";
            notifyIcon1.ShowBalloonTip(1000);
        }

        //Developer test button
        private void devButton_Click(object sender, EventArgs e)
        {
            this.Close();
            developerTools tools = new developerTools();
            tools.Show();
        }

        private void itemView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Enabled = false;
        }

        private void item1Status_Click(object sender, EventArgs e)
        {
            devCnt++;
            if (devCnt == 10)
                devButton.Visible = true;
        }
    }
}
