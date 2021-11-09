using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form2 : Form
    {
        #region Init
        readonly ThemeClass theme = new ThemeClass("", Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat,
            Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, DockStyle.Left);
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        public UsersClass cu = new UsersClass(0, "", "", "", "", "", 0);
        readonly Control[] buttons;
        readonly Control[] headers;
        readonly Control[] labels;
        public Form2(int userID, ThemeClass colTheme)
        {
            InitializeComponent();
            cu = ca.CurrentUser(userID);
            InitHelper();
            theme = colTheme;
            labels = new Control[] { label1, label2, label3, panel1, panel2 };
            headers = new Control[] { label4, panel3 };
            buttons = new Control[] { button1, button2, button3, button4, button5, button6, button7, button8 };
            ApplyTheme();
        }
        void InitHelper()
        {
            label1.Text = $"Hello {cu.FirstName}!({cu.Id})";
            label2.Text = $"{cu.Money}£";
            if (cu.LastLogin == "0")
                label3.Visible = false;
            label3.Text = $"Last Time Seen: {cu.LastLogin}";

        }

        /// <summary>
        /// Apply the theme
        /// </summary>
        /// <param name="settings"></param>
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

            flowLayoutPanel1.BackColor = theme.SecondaryBack;
            panel2.Dock = theme.Dockstyle;
        }
        #endregion
        #region Methods

        /// <summary>
        /// change the string into an int[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Array of int[]</returns>
        int[] ParseMyData(string str)
        {
            if (str.Contains(",,"))
                str = str.Replace(",,", ",");
            if (str[0] == ',')
                str = str.Remove(0, 1);
            if (str.Length > 1 && str[str.Length - 1] == ',')
                str = str.Remove(str.Length - 1, 1);

            string[] strResults = str.Split(',');
            int[] results = new int[strResults.Length];
            for (int i = 0; i < strResults.Length; i++)
            {
                results[i] = int.Parse(strResults[i]);
            }
            return results;
        }

        /// <summary>
        /// Set the flowLayoutPanel
        /// </summary>
        /// <param name="field">string of: Inventory, Selling or Saved field</param>
        /// <param name="n">Current user Id</param>
        void PopulateFlowPanel(string field, int n)
        {
            flowLayoutPanel1.Controls.Clear();
            if (!String.IsNullOrEmpty(field))//field != ""
            {
                int[] tempArray = ParseMyData(field);
                ItemsClass[] tempItemsArray = ca.GetItems(tempArray);
                foreach (var item in tempItemsArray)
                {
                    var uc = new UserControl1(item, cu, theme, null, n);
                    flowLayoutPanel1.Controls.Add(uc);
                }
            }
            else return;
        }

        /// <summary>
        /// Set the flowLayoutPanel for Selling button
        /// </summary>
        void PopulateSellPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            ItemsClass[] tempItemsArray = ca.GetItemsForSale();
            foreach (var item in tempItemsArray)
            {
                if (item.Owner != cu.Id)
                {
                    var uc = new UserControl1(item, cu, theme);
                    flowLayoutPanel1.Controls.Add(uc);
                }
            }
        }

        /// <summary>
        /// Populate the flowLayoutPanel for History buttons
        /// </summary>
        /// <param name="n"></param>
        void PopulateHistory(int n)
        {
            flowLayoutPanel1.Controls.Clear();
            //get the buying history from db for current user
            History[] his = n == 4 ? ca.GetSellHistory(cu.Id) : ca.GetBuyHistory(cu.Id);
            //create the array of items from the DB
            List<int> numItems = new List<int>();
            foreach (var item in his)
            {
                numItems.Add(item.Item);
            }
            ItemsClass[] hisItems = ca.GetItems(numItems.ToArray());
            //populate the flowpanel with UserControls
            for (int i = 0; i < his.Length; i++)
            {
                var zz = new UserControl1(hisItems[i], null, theme, his[i], n);
                flowLayoutPanel1.Controls.Add(zz);
            }
        }

        /// <summary>
        /// set the color of selected button
        /// </summary>
        /// <param name="sender"></param>
        void SetButtonsColor(Button sender)
        {
            foreach (var item in buttons)
            {
                item.BackColor = item == sender ? theme.ButtonSelect : theme.ButtonBack;
            }
        }
        #endregion
        #region Buttons

        /// <summary>
        /// user can buy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button2_Click(object sender, EventArgs e)
        {
            PopulateSellPanel();
            SetButtonsColor(button2);
            if (panel4.Visible)
                panel4.Visible = false;
        }

        /// <summary>
        /// Inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button1_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(cu.Inventory, 1);
            if (panel4.Visible)
                panel4.Visible = false;
            SetButtonsColor(button1);
            if (panel4.Visible)
                panel4.Visible = false;
        }
        
        /// <summary>
        /// user is selling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button3_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(cu.Selling, 2);
            SetButtonsColor(button3);
            if (panel4.Visible)
                panel4.Visible = false;
        }

        /// <summary>
        /// saved items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button6_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(cu.Saved, 3);
            SetButtonsColor(button6);
            if (panel4.Visible)
                panel4.Visible = false;
        }

        /// <summary>
        /// Sell history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button4_Click(object sender, EventArgs e)
        {
            PopulateHistory(4);
            SetButtonsColor(button4);
        }

        /// <summary>
        /// Buy history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button5_Click(object sender, EventArgs e)
        {
            PopulateHistory(5);
            SetButtonsColor(button5);
        }

        /// <summary>
        /// settings...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button7_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(cu.Id, theme);
            form3.ShowDialog();
            SetButtonsColor(button7);
            if (panel4.Visible)
                panel4.Visible = false;
        }

        /// <summary>
        /// History Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button8_Click(object sender, EventArgs e)
        {
            SetButtonsColor(button8);
            panel4.Visible = !panel4.Visible;
        }

        /// <summary>
        /// Close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CloseForm_Click(object sender, EventArgs e)
        {
            cu.LastLogin = DateTime.Now.ToLongDateString();
            ca.SetLastLogin(cu);
            this.Close();
        }
        #endregion

        #region BuyBot
        readonly Random random = new Random();

        private void TimerBuyBot_Tick(object sender, EventArgs e)
        {
            //get Items for sale
            ItemsClass[] itemsForSale = ca.GetItemsForSale(true);
            if (itemsForSale.Length > 0)
            {
                //choose one random item
                int itemIndex = random.Next(itemsForSale.Length);
                ItemsClass choosenItem = itemsForSale[itemIndex];
                //delete from olduser selling column DB
                UsersClass owner = ca.CurrentUser(choosenItem.Owner);
                ca.SetSelling(owner.CancelSelling(choosenItem.Id), owner.Id);
                //add money to the olduser
                decimal price = choosenItem.TempPrice == 0 ? choosenItem.Price : choosenItem.TempPrice;
                owner.Money += price;
                ca.SetMoney(owner.Money, owner.Id);
                //set notForSale
                ca.SetState("NotForSale", choosenItem.Id);
                //reset price, owner
                ca.SetOwner(0, choosenItem.Id);
                choosenItem.TempPrice = 0;
                ca.SetTempPrice(0, choosenItem.Id);
                //write to history
                History transaction = new History(0, 0, owner.Id, choosenItem.Id, price,
                    $"{DateTime.Now.ToLongDateString()}-{DateTime.Now.ToShortTimeString()}");
                ca.WriteTransaction(transaction);
                if (owner.Id == cu.Id)
                {
                    cu.CancelSelling(choosenItem.Id);
                    label2.Text = $"{owner.Money}£";
                }
            }
        }
        private void TimerSellBot_Tick(object sender, EventArgs e)
        {
            //get Items notForSale with owner == 0
            ItemsClass[] notForSale = ca.NotForSale();
            if (notForSale.Length > 0)
            {
                //choose one random item to sell
                int itemIndex = random.Next(notForSale.Length);
                ItemsClass choosenItem = notForSale[itemIndex];
                //sell item
                ca.SetState("ForSale", choosenItem.Id);
            }
        }
        #endregion

    }
}
