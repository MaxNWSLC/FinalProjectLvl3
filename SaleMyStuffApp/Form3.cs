using System;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form3 : Form
    {
        Control[] appControls;
        Control[] accControls;
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        UsersClass reUser = new UsersClass(0, "", "");

        public Form3(int n)
        {
            InitializeComponent();
            appControls = new Control[] { newPassButton, newPassLabel, passBox1, passBox2 };
            newPassButton.Visible = false;
            newPassLabel.Visible = false;
            passBox2.Visible = false;
            passBox1.Visible = false;
            accControls = new Control[] { label1, label2, button1 , button4, button5, themeListBox };
            reUser.Id = n;


        }
        /// <summary>
        /// Set the Panel Controls
        /// </summary>
        /// <param name="n"></param>
        void SetPanel(int n = 0)
        {
            foreach (var item in appControls)
            {
                item.Visible = n == 1;
            }
            foreach (var item in accControls)
            {
                item.Visible = n != 1;
            }
            themeName.Visible = false;
        }

        /// <summary>
        /// Apply Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            
        }
        private void Button2_Click(object sender, EventArgs e)
        {//appSettings
            SetPanel();
        }

        private void Button3_Click(object sender, EventArgs e)
        {//accSettings
            SetPanel(1);
        }

        private void Button4_Click(object sender, EventArgs e)
        {//left
            sidePanel.Dock = DockStyle.Left;
        }

        private void Button5_Click(object sender, EventArgs e)
        {//right
            sidePanel.Dock = DockStyle.Right;
        }
        private void CloseForm_Click(object sender, EventArgs e)
        {//close
            this.Close();
        }

        private void newPassButton_Click(object sender, EventArgs e)
        {//change pass
            //check if boxes arent null or empty
            if (String.IsNullOrEmpty(passBox1.Text) | String.IsNullOrEmpty(passBox2.Text))
            {
                MessageBox.Show("Didn't you forgot something?", "Empty field found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //check if boxes are equal
            if (!passBox1.Text.Equals(passBox2.Text))
            {
                MessageBox.Show("Passwords must be Equal.", "Password fields error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            reUser.Pass = passBox1.Text;
            ca.SetPassword(reUser);
            if(ca.TestLogin(reUser.Id,passBox1.Text))
                MessageBox.Show("Password Changed", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            SetPanel();
        }

        private void themeListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            themeName.Visible = true;
            themeName.Text = themeListBox.SelectedItem.ToString();
        }
    }
}
