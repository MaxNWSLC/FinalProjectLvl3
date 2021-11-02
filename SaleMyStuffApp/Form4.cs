using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form4 : Form
    {
        UsersClass cu;
        ItemsClass ci;
        public Form4(UsersClass currentUser, ItemsClass currentItem)
        {
            InitializeComponent();
            cu = currentUser;
            ci = currentItem;
            nameLabel.Text = ci.Name;
            ShopPriceLabel.Text = $"Shop price: {ci.Price}£";
            string recPrice = $"{(ci.Price * (decimal)1.10).ToString("0.00")}";
            PriceLabel.Text = $"Recommended price: {recPrice}£";
            priceTextBox.Text = recPrice;
            pictureBox1.Image = Image.FromFile($"Resources/{ci.Image}");
            infoTextBox.Text = ci.Info;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SellButton_Click(object sender, EventArgs e)
        {

        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
