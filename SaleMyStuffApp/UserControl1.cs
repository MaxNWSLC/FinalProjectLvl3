using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class UserControl1 : UserControl
    {
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");

        string newSave;
        UsersClass currentUser;
        ItemsClass currentItem;
        public UserControl1(ItemsClass item, UsersClass user , int buttonSet = 2)
        {
            InitializeComponent();
            nameLabel.Text = item.Name;
            PriceLabel.Text = $"{item.Price}£";
            infoLabel.Text = item.Info;
            pictureBox1.Image = Image.FromFile($"Resources/{item.Image}");
            currentItem = item;
            currentUser = user;
            switch (buttonSet)
            {
                case 1://inventory
                    button1.Text = "Sell";
                    button1.Click += ButtonSell_Click;
                    button2.Visible = false;
                    break;
                case 3://items user sells
                    button1.Text = "Cancel";
                    button1.Click += ButtonCancel_Click;
                    button2.Visible = false;
                    break;
                case 5://saved items
                    button1.Text = "Buy";
                    button1.Click += ButtonBuy_Click;
                    button2.Text = "UnSave";
                    button2.Click += ButtonUnSave_Click;
                    break;
                default://items user can buy or save
                    button1.Click += ButtonBuy_Click;
                    if (user.Saved.Contains(item.Id.ToString()))
                        button2.Text = "Saved";
                    button2.Click += ButtonSave_Click;
                    break;
            }
        }

        private void ButtonBuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Buy Button is not implemented yet");
        }

        private void ButtonUnSave_Click(object sender, EventArgs e )
        {
            if (button2.Text == "Save")
                MessageBox.Show("Shushhh");
            else
            {
                newSave = currentUser.SaveOut(currentItem.Id);
                ca.UnSaveTheItem(newSave, currentUser.Id);
                this.button2.Text = "Save";
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Saved")
                MessageBox.Show("You already saved this Item.");
            else
            {
                newSave = currentUser.SaveIn(currentItem.Id);
                ca.SaveTheItem(newSave, currentUser.Id);
                this.button2.Text = "Saved";
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Cancel Button is Not implemented yet");
        }

        private void ButtonSell_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Sell Button is Not implemented yet");
        }
    }
}
