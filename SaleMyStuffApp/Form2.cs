using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form2 : Form
    {
        #region Init
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        public UsersClass cu = new UsersClass(0, "", "", "", "", "", 0);
        public Form2(int userID)
        {
            InitializeComponent();
            cu = ca.CurrentUser(userID);
            label1.Text = $"Hello {cu.FirstName}";
            label2.Text = $"{cu.Money}£";
            if (cu.LastLogin == "0")
                label3.Visible = false;
            label3.Text = $"Last Time Seen: {cu.LastLogin}";
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
        /// <param name="field"></param>
        public void PopulateFlowPanel(string field, int n)
        {
            flowLayoutPanel1.Controls.Clear();
            if (!String.IsNullOrEmpty(field))//field != ""
            {
                int[] tempArray = ParseMyData(field);
                ItemsClass[] tempItemsArray = ca.GetItems(tempArray);
                foreach (var item in tempItemsArray)
                {
                    var uc = new UserControl1(item, cu, null, n);
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
                if (item.Owner == cu.Id) continue;
                var uc = new UserControl1(item, cu);
                flowLayoutPanel1.Controls.Add(uc);
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
                var zz = new UserControl1(hisItems[i], null, his[i], n);
                flowLayoutPanel1.Controls.Add(zz);
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
        }
        /// <summary>
        /// Inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button1_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(cu.Inventory, 1);
        }
        /// <summary>
        /// user is selling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button3_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(cu.Selling, 2);
        }
        /// <summary>
        /// saved items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button6_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(cu.Saved, 3);
        }
        /// <summary>
        /// Sell history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button4_Click(object sender, EventArgs e)
        {
            PopulateHistory(4);
        }
        /// <summary>
        /// Buy history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button5_Click(object sender, EventArgs e)
        {
            PopulateHistory(5);
        }
        /// <summary>
        /// settings...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button7_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(cu.Id);
            form3.ShowDialog();
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
    }
}
