using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class viewLoader : Form
    {

       public viewLoader()
        {
            InitializeComponent();
        }

        public void browserTimer_Tick(object sender, EventArgs e)
        {
            itemView itemview = new itemView();
            itemview.refreshNames();
            label1.Text = "Loading " + itemView.currentItem;
            if(itemview.getCurrentRefresh() == "finished")
            {
                browserTimer.Stop();
                itemview.Show();
            }
        }

        private void viewLoader_Load(object sender, EventArgs e)
        {

        }

    }
}
