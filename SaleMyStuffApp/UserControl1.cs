using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class UserControl1 : UserControl
    {
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");

        string newSave;
        readonly UsersClass currentUser;
        readonly ItemsClass currentItem;
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
                    button1.Image = Image.FromFile($"Resources/smallsell.png");
                    button2.Visible = false;
                    break;
                case 3://items user sells
                    button1.Text = "Cancel";
                    button1.Click += ButtonCancel_Click;
                    button1.Image = Image.FromFile($"Resources/smallcancel.png");
                    button2.Visible = false;
                    break;
                case 5://saved items
                    button1.Text = "Buy";
                    button1.Click += ButtonBuy_Click;
                    button2.Text = "UnSave";
                    button2.Click += ButtonUnSave_Click;
                    button2.Image = Image.FromFile($"Resources/smallunsave.png");
                    break;
                default://items user can buy or save
                    button1.Click += ButtonBuy_Click;
                    if (user.Saved.Contains(item.Id.ToString()))
                    {
                        button2.Text = "Saved";
                        button2.Image = Image.FromFile($"Resources/smallsaved.png");
                    }
                    button2.Click += ButtonSave_Click;
                    break;
            }
        }

        private void ButtonBuy_Click(object sender, EventArgs e)
        {
            if (currentUser.Money >= currentItem.Price)//check if the user have enought Money
            {
                currentUser.Money -= currentItem.Price;
                string newInventory = currentUser.InventoryIn(currentUser.Inventory, currentItem.Id);
                ca.SetMoney(currentUser.Money, currentUser.Id);
                ca.WriteItemInInventory(newInventory, currentUser.Id);

                //accesing parent form(Form2) to change the label that show user's Money
                Form2 form2;
                form2 = (Form2)this.FindForm();
                form2.label2.Text = $"{currentUser.Money}£";
                //
                //Need to send money to the seller
                //
                this.Dispose(Visible);
            }
            else
                MessageBox.Show("Looks like You do not have enought Money :(");
        }

        private void ButtonUnSave_Click(object sender, EventArgs e )
        {
            newSave = currentUser.UnSave(currentUser.Saved, currentItem.Id);
            ca.UnSaveTheItem(newSave, currentUser.Id);
            this.Dispose(Visible);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Saved")
                MessageBox.Show("You already saved this Item.");
            else
            {
                newSave = currentUser.Save(currentUser.Saved, currentItem.Id);
                ca.SaveTheItem(newSave, currentUser.Id);
                this.button2.Text = "Saved";
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            string newSelling = currentUser.CancelSelling(currentUser.Selling, currentItem.Id);
            string newInventory = currentUser.InventoryIn(currentUser.Inventory, currentItem.Id);
            ca.WriteItemInInventory(newInventory, currentUser.Id);
            ca.UnSaleTheItem(newSelling, currentItem.Id);
            ca.DeleteItemFromSelling(currentUser.Id);
            this.Dispose(Visible);
        }

        private void ButtonSell_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Sell Button is Not implemented yet");
        }
    }
}
