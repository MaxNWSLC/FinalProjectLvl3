using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class UserControl1 : UserControl
    {
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");

        readonly UsersClass cu;//Current User
        readonly ItemsClass ci;//Current Item
        public UserControl1(ItemsClass item, UsersClass user , int buttonSet = 2)
        {
            InitializeComponent();
            ci = item;
            cu = user;

            nameLabel.Text = ci.Name;
            PriceLabel.Text = ci.TempPrice == 0 ? $"{ci.Price}£" : $"{ci.TempPrice}£";
            infoLabel.Text = ci.Info;
            pictureBox1.Image = Image.FromFile($"Resources/{ci.Image}");

            //set the buttons
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
                    if (ci.State != "Selling")
                        button1.Enabled = false;
                    button1.Text = "Buy";
                    button1.Click += ButtonBuy_Click;
                    button2.Text = "UnSave";
                    button2.Click += ButtonUnSave_Click;
                    button2.Image = Image.FromFile($"Resources/smallunsave.png");
                    break;
                default://items user can buy or save
                    button1.Click += ButtonBuy_Click;
                    if (cu.Saved.Contains(ci.Id.ToString()))
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
            decimal price = ci.TempPrice == 0 ? ci.Price : ci.TempPrice;
            if (cu.Money >= price)//check if the user have enought Money
            {
                cu.Money -= price;
                string newInventory = cu.InventoryIn(ci.Id);
                ca.SetInventory(newInventory, cu.Id);
                ca.SetMoney(cu.Money, cu.Id);
                //sendMoney to oldowner
                int oldOwner = ci.Owner;
                UsersClass owner = ca.CurrentUser(oldOwner);
                decimal tm = owner.Money + price;
                ca.SetMoney(tm, oldOwner);
                //remove from selling of the prev owner
                ca.SetSelling(owner.CancelSelling(ci.Id), owner.Id);
                //set newOwner
                ca.SetOwner(cu.Id, ci.Id);
                //if saved=>unsave when buy
                if (cu.Saved.Contains($"{ci.Id}"))
                    ca.SetSaved(cu.UnSave(ci.Id), cu.Id);
                //accesing parent form(Form2) to change the label that show user's Money
                Form2 form2;
                form2 = (Form2)this.FindForm();
                form2.label2.Text = $"{cu.Money}£";
                this.Dispose(Visible);
            }
            else
                MessageBox.Show("No money?\nNo Honey!");
        }

        private void ButtonUnSave_Click(object sender, EventArgs e )
        {
            string newSave = cu.UnSave(ci.Id);
            ca.SetSaved(newSave, cu.Id);
            this.Dispose(Visible);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Saved") 
            {
                string newSave = cu.UnSave(ci.Id);
                ca.SetSaved(newSave, cu.Id);
                this.button2.Text = "Save";
                button2.Image = Image.FromFile($"Resources/smallsave.png");
            }
            else
            {
                string newSave = cu.Save(ci.Id);
                ca.SetSaved(newSave, cu.Id);
                this.button2.Text = "Saved";
                button2.Image = Image.FromFile($"Resources/smallsaved.png");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            string newSelling = cu.CancelSelling(ci.Id);
            string newInventory = cu.InventoryIn(ci.Id);
            ca.SetInventory(newInventory, cu.Id);
            ca.SetSelling(newSelling, cu.Id);
            ca.SetState("NotForSale", cu.Id);
            //reset the tempPrice
            ca.SetTempPrice(0, ci.Id);
            this.Dispose(Visible);
        }

        private void ButtonSell_Click(object sender, EventArgs e)
        {
            Form4 sellForm = new Form4(cu, ci);
            sellForm.ShowDialog();
            this.Dispose(Visible);
        }
    }
}
