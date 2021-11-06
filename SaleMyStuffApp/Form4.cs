using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form4 : Form
    {
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        readonly UsersClass cu;
        readonly ItemsClass ci;
        public Form4(UsersClass currentUser, ItemsClass currentItem)
        {
            InitializeComponent();
            cu = currentUser;
            ci = currentItem;

            nameLabel.Text = ci.Name;
            ShopPriceLabel.Text = $"Shop price: {ci.Price}£";
            string recPrice = $"{ci.Price * (decimal)1.10:0.00}";
            PriceLabel.Text = $"Recommended selling price: {recPrice}£";
            priceTextBox.Text = recPrice;
            pictureBox1.Image = Image.FromFile($"Resources/Images/{ci.Image}");
            infoTextBox.Text = ci.Info;
        }
        private void SellButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(priceTextBox.Text, out decimal price) && infoTextBox.Text != "")
            {
                cu.InventoryOut(ci.Id);
                cu.AddSelling(ci.Id);
                ca.SetState("Selling", ci.Id);
                ca.SetSelling(cu.Selling, cu.Id);
                ca.SetInventory(cu.Inventory, cu.Id);
                ca.SetTempPrice(price, ci.Id);
                this.Close();
            }
            else
                MessageBox.Show($"|Ooops!\nMissed something?|");
        }
        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
