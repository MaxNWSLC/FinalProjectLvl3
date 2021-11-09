using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form3 : Form
    {
        readonly Control[] appControls;
        readonly Control[] accControls;
        readonly Control[] buttons;
        readonly Control[] headers;
        readonly Control[] labels;
        readonly ThemeClass theme = new ThemeClass("", Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat,
            Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, DockStyle.Left); 
        readonly ThemeClass tempTheme = new ThemeClass("", Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat,
            Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, DockStyle.Left);
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        readonly string path = @"Resources\Settings.txt";
        readonly UsersClass reUser = new UsersClass(0, "", "");

        public Form3(int n, ThemeClass colorTheme)
        {
            InitializeComponent();
            reUser.Id = n;
            theme = colorTheme;
            accControls = new Control[] { button6, newPassLabel, passBox1, passBox2 };
            appControls = new Control[] { label1, label2, button1, button4, 
                button5, themeListBox, panel3 };
            buttons = new Control[] { button1, button2, button3, button4, button5, button6, button7 };
            labels = new Control[] { label1, label2, newPassLabel };
            headers = new Control[] { passBox1, passBox2, panel2 };
            ApplyTheme();
            SetPanel();
            Preview();
            button2.BackColor = theme.ButtonSelect;
            if (theme.Dockstyle == DockStyle.Left)
                button4.BackColor = theme.ButtonSelect;
            else button5.BackColor = theme.ButtonSelect;
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
            sidePanel.BackColor = theme.SecondaryBack;
            sidePanel.Dock = theme.Dockstyle;
        }

        /// <summary>
        /// Set the Panel Controls
        /// </summary>
        /// <param name="n"></param>
        void SetPanel(int n = 0)
        {
            foreach (var item in appControls)
            {
                item.Visible = n != 1;
            }
            foreach (var item in accControls)
            {
                item.Visible = n == 1;
            }
        }

        /// <summary>
        /// Apply Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            int i = themeListBox.SelectedIndex;
            string colour = 0 <= i && i < 4 ? themeListBox.SelectedItem.ToString() : theme.Name;
            string side = sidePanel.Dock.ToString();
            File.WriteAllText(path, $"{colour},{side}");
            MessageBox.Show("Job Done!\nYou have to close and open  the App\nChanges to be aplied"
                , "Settings Saved",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Button2_Click(object sender, EventArgs e)
        {//appSettings
            SetPanel();
            button2.BackColor = theme.ButtonSelect;
            button3.BackColor = theme.ButtonBack;
        }

        private void Button3_Click(object sender, EventArgs e)
        {//accSettings
            SetPanel(1);
            button3.BackColor = theme.ButtonSelect;
            button2.BackColor = theme.ButtonBack;
        }

        private void Button4_Click(object sender, EventArgs e)
        {//left
            sidePanel.Dock = DockStyle.Left;
            button4.BackColor = theme.ButtonSelect;
            button5.BackColor = theme.ButtonBack;
        }

        private void Button5_Click(object sender, EventArgs e)
        {//right
            sidePanel.Dock = DockStyle.Right;
            button5.BackColor = theme.ButtonSelect;
            button4.BackColor = theme.ButtonBack;
        }
        private void CloseForm_Click(object sender, EventArgs e)
        {//close
            this.Close();
        }

        private void NewPassButton_Click(object sender, EventArgs e)
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
            if (ca.TestLogin(reUser.Id, passBox1.Text))
                MessageBox.Show("Password Changed", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            SetPanel();
        }

        private void ThemeListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string testText = themeListBox.SelectedItem.ToString();
            Preview(testText);
        }
        void Preview(string str = "z")
        {
            switch (str)
            {
                case "Dark":
                    tempTheme.Dark();
                    break;
                case "Lime":
                    tempTheme.Lime();
                    break;
                case "Orange":
                    tempTheme.Orange();
                    break;
                default:
                    tempTheme.Linen();
                    break;
            }
            panel3.Visible = true;
            panel5.BackColor = tempTheme.PrimaryBack;
            panel1.BackColor = tempTheme.SecondaryBack;
            panel4.BackColor = tempTheme.HeaderBack;
            themeName.Text = tempTheme.Name;
            themeName.ForeColor = tempTheme.TextColor;
            button8.ForeColor = tempTheme.TextColor;
            button9.ForeColor = tempTheme.TextColor;
            button10.ForeColor = tempTheme.TextColor;
            button8.BackColor = tempTheme.ButtonBack;
            button8.ForeColor = tempTheme.ButtonFront;
            button9.BackColor = tempTheme.ButtonBack;
            button9.ForeColor = tempTheme.ButtonFront;
            button10.BackColor = tempTheme.ButtonBack;
            button10.ForeColor = tempTheme.ButtonFront;
        }

        void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
