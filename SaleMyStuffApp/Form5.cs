using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form5 : Form
    {
        #region Init
        readonly ThemeClass theme = new ThemeClass("", Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, 
            Color.Wheat, Color.Wheat, Color.Wheat, DockStyle.Left);
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        readonly Control[] disables;
        readonly Control[] hiders;
        readonly Control[] buttons;
        readonly Control[] strBoxes;
        readonly Control[] labels;
        UsersClass reUser = new UsersClass(0, "", "");
        public Form5(string str, ThemeClass colorTheme)
        {
            InitializeComponent();
            theme = colorTheme;
            labels = new Control[] { label1, label2, label3, label4, label6, label7 };
            strBoxes = new Control[] { LoginBox, nameBox, surnameBox, passBox1, passBox2 };
            buttons = new Control[] { searchButton, CreateButton, CancelSellButton };
            disables = new Control[] { nameBox, passBox1, CreateButton, label6, label2 };
            hiders = new Control[] { passBox2, label3, label4, surnameBox };
            SetPanel(str);
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
            foreach (var item in strBoxes)
            {
                item.BackColor = theme.HeaderBack;
                item.ForeColor = theme.ButtonFront;
            }
        }
        void SetPanel(string str)
        {
            if (str.Equals("recover"))
            {
                searchButton.Visible = true;
                foreach (var item in hiders) item.Visible = false;
                foreach (var item in disables) item.Enabled = false;
                headerLabel.Text = "Recover Password";
                label6.Text = "New Password";
                label2.Text = "New Password";
                nameBox.PasswordChar = '*';
                CreateButton.Text = "Apply";
                CreateButton.Click += ApplyButton_Click;
            }
            else CreateButton.Click += CreateButton_Click;
        }
        #endregion
        private void MessageBocMethod(string str, string login = "")
        {
            switch (str)
            {
                case "notFound":
                    MessageBox.Show($"OOops, Combinations did't been found.", "Wrong login/dob error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "notUniq":
                    MessageBox.Show($"Login {login} exist.\nChange the Login please.", "Dublicate login found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "tooYoung":
                    MessageBox.Show("You are a bit too young my friend\nOnly older than 12 years are aloud ;)", "DOB error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "nonEqual":
                    MessageBox.Show("Passwords must be Equal.", "Password fields error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "empty":
                    MessageBox.Show("Didn't you forgot something?", "Empty field found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                default:
                    MessageBox.Show("Ooops", "Unkown Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }

        }

        #region Buttons
        private void CreateButton_Click(object sender, EventArgs e)
        {
            string login = LoginBox.Text;
            string pass = passBox1.Text;
            string pass2 = passBox2.Text;
            string dob = dateTime.Text;
            string firstName = nameBox.Text;
            string lastName = surnameBox.Text;

            //no empty fields allowed
            if (String.IsNullOrEmpty(login) | String.IsNullOrEmpty(pass) | String.IsNullOrEmpty(pass2) | String.IsNullOrEmpty(firstName) | String.IsNullOrEmpty(lastName))
            {
                MessageBocMethod("empty");
                return;
            }
            //passwords must be equal
            if (pass != pass2)
            {
                MessageBocMethod("nonEqual");
                return;
            }
            //user must be at least 12 years old
            if (DateTime.Now.Year - dateTime.Value.Year < 12)
            {
                MessageBocMethod("tooYoung");
                return;
            }
            //login must be uniq
            if (ca.CheckLogin(login))
            {
                MessageBocMethod("notUniq", login);
                return;
            }
            //finaly register the user to the db 
            UsersClass newUser = new UsersClass(login, pass, dob, firstName, lastName);
            ca.CreateUser(newUser);
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string pass = passBox1.Text;
            string pass2 = nameBox.Text;
            //no empty pass
            if (pass == "" | pass2 == "")
            {
                MessageBocMethod("empty");
                return;
            }
            //passwords must be equal
            if (pass != pass2)
            {
                MessageBocMethod("nonEqual");
                return;
            }
            //accesissing DB
            reUser.Pass = pass;
            ca.SetPassword(reUser);
            this.Close();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string login = LoginBox.Text;
            string dob = dateTime.Text;
            //no empty login
            if (login.Length == 0)
            {
                MessageBocMethod("empty");
                return;
            }
            //user must be at least 12 years old
            if (DateTime.Now.Year - dateTime.Value.Year < 12)
            {
                MessageBocMethod("tooYoung");
                return;
            }
            //now checking combination
            reUser = ca.SearchUser(login, dob);
            if (reUser.Id == 0)
            {
                MessageBocMethod("notFound");
                return;
            }
            else
            {
                LoginBox.Enabled = false;
                dateTime.Enabled = false;
                passBox1.Enabled = true;
                nameBox.Enabled = true;
                label2.Enabled = true;
                label6.Enabled = true;
                passBox1.Text = reUser.Pass;
                nameBox.Text = reUser.Pass;
                searchButton.Enabled = false;
            }
        }

        private void CancelSellButton_Click(object sender, EventArgs e) { this.Close(); }
        private void CloseForm_Click(object sender, EventArgs e) { this.Close(); }
    }
    #endregion
}
