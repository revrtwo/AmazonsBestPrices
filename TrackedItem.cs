using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    class TrackedItem
    {
        //Object class for more tarckers in development
        private int itemID;
        private string itemName;
        private string itemCost;
        private string itemUrl;

        public TrackedItem()
        {
            setID(-1);
            setName("null");
            setCost("$0.00");
            setUrl("null");
        }

        public TrackedItem(int id, string name, string cost, string url)
        {
            setID(id);
            setName(name);
            setCost(cost);
            setUrl(url);
        }

        public void setID(int id)
        {
            this.itemID = id;
        }

        public void setName(String name)
        {
            this.itemName = name;
        }

        public void setCost(String cost)
        {
            this.itemCost = cost;
        }

        public void setUrl(string url)
        {
            this.itemUrl = url;
        }

        public int getID()
        {
            return itemID;
        }

        public String getName()
        {
            return itemName;
        }

        public String getCost()
        {
            return itemCost;
        }

        public string getUrl()
        {
            return itemUrl;
        }
    }
}
