using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form2 : Form
    {
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        public UsersClass currentUser = new UsersClass(0, "", "", "", "", "", 0);
        public Form2(int userID)
        {
            InitializeComponent();
            currentUser = ca.CurrentUser(userID);
            label1.Text = $"Hello {currentUser.FirstName}";
            label2.Text = $"{currentUser.Money}£";
            label3.Text = $"Last Time Seen: Not implemented yet";
        }

        /// <summary>
        /// change the string into an int[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Array of int[]</returns>
        int[] ParseMyData(string str)
        {
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
        private void PopulateFlowPanel(string field, int n)
        {
            flowLayoutPanel1.Controls.Clear();
            if (field != "")
            {
                int[] tempArray = ParseMyData(field);
                ItemsClass[] tempItemsArray = ca.GetItems(tempArray);
                foreach (var item in tempItemsArray)
                {
                    var zz = new UserControl1(item, currentUser, n);
                    flowLayoutPanel1.Controls.Add(zz);
                }
            }
            else return;
        }
        /// <summary>
        /// Set the flowLayoutPanel for Selling button
        /// </summary>
        public void PopulateSellPanel()
        {
            flowLayoutPanel1.Controls.Clear();
            ItemsClass[] tempItemsArray = ca.GetItemsForSale();
            foreach (var item in tempItemsArray)
            {
                if (item.Owner == currentUser.Id) continue;
                var zz = new UserControl1(item, currentUser);
                flowLayoutPanel1.Controls.Add(zz);
            }
        }
        /// <summary>
        /// Inventory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(currentUser.Inventory, 1);
        }
        /// <summary>
        /// Here you can buy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            PopulateSellPanel();
        }
        /// <summary>
        /// History of sold items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            MessageBox.Show($"Not implemented yet");
        }
        /// <summary>
        /// Items you are selling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(currentUser.Selling, 3);
        }
        /// <summary>
        /// Items saved for later
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, EventArgs e)
        {
            PopulateFlowPanel(currentUser.Saved, 5);
        }
        /// <summary>
        /// settings...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
