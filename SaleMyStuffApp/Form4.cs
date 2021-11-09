using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form4 : Form
    {
        readonly ThemeClass theme = new ThemeClass("", Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, 
            Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, DockStyle.Left);
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        readonly UsersClass cu;
        readonly ItemsClass ci;
        readonly Control[] buttons;
        readonly Control[] headers;
        readonly Control[] labels;
        public Form4(UsersClass currentUser, ItemsClass currentItem, ThemeClass colorTheme)
        {
            InitializeComponent();
            cu = currentUser;
            ci = currentItem;
            InitForm();
            theme = colorTheme;
            labels = new Control[] { label1, infoLabel, nameLabel, PriceLabel, ShopPriceLabel };
            headers = new Control[] { priceTextBox, infoTextBox, label2, panel2 };
            buttons = new Control[] { SellButton, CancelSellButton };
            ApplyTheme();
        }
        void InitForm()
        {
            nameLabel.Text = ci.Name;
            ShopPriceLabel.Text = $"Shop price: {ci.Price}£";
            string recPrice = $"{ci.Price * (decimal)1.10:0.00}";
            PriceLabel.Text = $"Recommended selling price: {recPrice}£";
            priceTextBox.Text = recPrice;
            pictureBox1.Image = Image.FromFile($"Resources/Images/{ci.Image}");
            infoTextBox.Text = ci.Info;
        }
        void ApplyTheme()
        {
            this.BackColor = theme.PrimaryBack;
            foreach (var item in labels)
            {
                item.BackColor = theme.PrimaryBack;
                item.ForeColor = theme.TextColor;
            }
            foreach (var item in buttons)
            {
                item.BackColor = theme.ButtonBack;
                item.ForeColor = theme.ButtonFront;
            }
            foreach (var item in headers)
            {
                item.BackColor = theme.HeaderBack;
                item.ForeColor = theme.HeaderFront;
            }
        }
        private void SellButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(priceTextBox.Text, out decimal price) && infoTextBox.Text != "")
            {
                cu.InventoryOut(ci.Id);
                cu.AddSelling(ci.Id);
                ca.SetState("ForSale", ci.Id);
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
