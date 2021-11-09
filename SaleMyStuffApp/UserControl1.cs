using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class UserControl1 : UserControl
    {
        #region Init
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        readonly ThemeClass theme = new ThemeClass("", Color.Wheat, Color.Wheat, Color.Wheat, 
            Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, DockStyle.Left);
        readonly UsersClass cu;
        readonly ItemsClass ci;
        readonly History hs;
        readonly Control[] buttons;
        readonly Control[] labels;
        public UserControl1(ItemsClass item, UsersClass user , ThemeClass colorTheme,History history = null, int buttonSet = 0)
        {
            InitializeComponent();
            cu = user;
            ci = item;
            hs = history;
            theme = colorTheme;
            labels = new Control[] { timeLabel, infoLabel, nameLabel, PriceLabel };
            buttons = new Control[] { button1, button2 };
            InitHelper(buttonSet);
            ApplyTheme();
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
        }
        void InitHelper(int buttonSet = 0)
        {

            if (buttonSet == 4 | buttonSet == 5)
            {
                nameLabel.Text = ci.Name;
                PriceLabel.Text = $"{hs.Price}£";
                infoLabel.Text = ci.Info;
                timeLabel.Visible = true;
                timeLabel.Text = $"Transaction made on: {hs.Date}";
                pictureBox1.Image = Image.FromFile($"Resources/Images/{ci.Image}");
            }
            else
            {
                nameLabel.Text = ci.Name;
                PriceLabel.Text = ci.TempPrice == 0 ? $"{ci.Price}£" : $"{ci.TempPrice}£";
                infoLabel.Text = ci.Info;
                pictureBox1.Image = Image.FromFile($"Resources/Images/{ci.Image}");
            }

            //set the buttons
            switch (buttonSet)
            {
                case 1://inventory
                    button1.Text = "Sell";
                    button1.Click += ButtonSell_Click;
                    button1.Image = Image.FromFile($"Resources/Icons/smallsell.png");
                    button2.Visible = false;
                    break;
                case 2://items user sells
                    button1.Text = "Cancel";
                    button1.Click += ButtonCancel_Click;
                    button1.Image = Image.FromFile($"Resources/Icons/smallcancel.png");
                    button2.Visible = false;
                    break;
                case 3://saved items
                    if (ci.State != "ForSale")
                        button1.Enabled = false;
                    button1.Text = "Buy";
                    button1.Click += ButtonBuy_Click;
                    button2.Text = "UnSave";
                    button2.Click += ButtonUnSave_Click;
                    button2.Image = Image.FromFile($"Resources/Icons/smallunsave.png");
                    break;
                case 4://sell history
                    button1.Visible = false;
                    button2.Visible = false;

                    break;
                case 5://buy history
                    button1.Visible = false;
                    button2.Visible = false;

                    break;
                default://items user can buy or save
                    button1.Click += ButtonBuy_Click;
                    if (cu.Saved.Contains(ci.Id.ToString()))
                    {
                        button2.Text = "Saved";
                        button2.Image = Image.FromFile($"Resources/Icons/smallsaved.png");
                    }
                    button2.Click += ButtonSave_Click;
                    break;
            }
        }
        #endregion
        #region Buttons
        void ButtonBuy_Click(object sender, EventArgs e)
        {
            decimal price = ci.TempPrice == 0 ? ci.Price : ci.TempPrice;
            if (cu.Money >= price)//check if the user have enought Money
            {
                //take the money
                cu.Money -= price;
                ca.SetMoney(cu.Money, cu.Id);
                //put in inventory
                string newInventory = cu.InventoryIn(ci.Id);
                ca.SetInventory(newInventory, cu.Id);
                //sendMoney to oldowner
                int oldOwner = ci.Owner;
                UsersClass owner = ca.CurrentUser(oldOwner);
                decimal tm = owner.Money + price;
                ca.SetMoney(tm, oldOwner);
                //remove from selling of the prev owner
                ca.SetSelling(owner.CancelSelling(ci.Id), owner.Id);
                //set notForSale
                ca.SetState("NotForSale", ci.Id);
                //set newOwner
                ca.SetOwner(cu.Id, ci.Id);
                //if saved=>unsave when buy
                if (cu.Saved.Contains($"{ci.Id}"))
                    ca.SetSaved(cu.UnSave(ci.Id), cu.Id);
                //accesing parent form(Form2) to change the label that show user's Money
                Form2 form2;
                form2 = (Form2)this.FindForm();
                form2.label2.Text = $"{cu.Money}£";
                //write transaction in history
                History transaction = new History(0, cu.Id, oldOwner, ci.Id, price, $"{DateTime.Now.ToLongDateString()}-{DateTime.Now.ToShortTimeString()}");
                ca.WriteTransaction(transaction);

                this.Dispose(Visible);
            }
            else
                MessageBox.Show("No money?\nNo Honey!");
        }

        void ButtonUnSave_Click(object sender, EventArgs e )
        {
            string newSave = cu.UnSave(ci.Id);
            ca.SetSaved(newSave, cu.Id);
            this.Dispose(Visible);
        }

        void ButtonSave_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Saved") 
            {
                string newSave = cu.UnSave(ci.Id);
                ca.SetSaved(newSave, cu.Id);
                this.button2.Text = "Save";
                button2.Image = Image.FromFile($"Resources/Icons/smallsave.png");
            }
            else
            {
                string newSave = cu.Save(ci.Id);
                ca.SetSaved(newSave, cu.Id);
                this.button2.Text = "Saved";
                button2.Image = Image.FromFile($"Resources/Icons/smallsaved.png");
            }
        }

        void ButtonCancel_Click(object sender, EventArgs e)
        {
            string newSelling = cu.CancelSelling(ci.Id);
            string newInventory = cu.InventoryIn(ci.Id);
            ca.SetInventory(newInventory, cu.Id);
            ca.SetSelling(newSelling, cu.Id);
            ca.SetState("NotForSale", cu.Id);
            ca.SetTempPrice(0, ci.Id);
            this.Dispose(Visible);
        }

        void ButtonSell_Click(object sender, EventArgs e)
        {
            Form4 sellForm = new Form4(cu, ci, theme);
            sellForm.ShowDialog();
            this.Dispose(Visible);
        }
        #endregion
    }
}
