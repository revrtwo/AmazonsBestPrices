using System;
using System.Windows.Forms;

namespace Amazon_s_Best_Prices
{
    public partial class about : Form
    {
        public Boolean active = true; 

        public about()
        {
            InitializeComponent();
        }

        private void about_Load(object sender, EventArgs e)
        {
            label3.Text = "v" + Application.ProductVersion;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/rvertwo/AmazonsBestPrices");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/rvertwo");
        }

    }
}
