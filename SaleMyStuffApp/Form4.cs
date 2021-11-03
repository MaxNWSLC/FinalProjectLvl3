using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form4 : Form
    {
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        readonly UsersClass cu;
        readonly ItemsClass ci;
        readonly string recPrice;
        public Form4(UsersClass currentUser, ItemsClass currentItem)
        {
            InitializeComponent();
            cu = currentUser;
            ci = currentItem;
            nameLabel.Text = ci.Name;
            ShopPriceLabel.Text = $"Shop price: {ci.Price}£";
            recPrice = $"{ci.Price * (decimal)1.10:0.00}";
            PriceLabel.Text = $"Recommended selling price: {recPrice}£";
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
            string infotext = infoTextBox.Text;
            if (decimal.TryParse(recPrice, out decimal price) && infotext != "")
            {
                //set item status to selling
                //remove from user inventory
                //add to user selling

                //user price is different from shop price i have to modify the db 
                //add new column "tempPrice" | "userPrice"
                //
            }
            else
                MessageBox.Show($"|Ooops!\nMissed something?|");
        }
        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
