using System;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form5 : Form
    {
        #region Init
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        UsersClass reUser = new UsersClass(0, "", "");
        public Form5(string str)
        {
            InitializeComponent();
            if (str.Equals("recover"))
            {
                //hide some controls
                //change some controls ;)
                headerLabel.Text = "Recover Password";
                searchButton.Visible = true;
                passBox2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                surnameBox.Visible = false;
                label6.Text = "New Password";
                label2.Text = "New Password";
                nameBox.Enabled = false;
                nameBox.PasswordChar = '*';
                passBox1.Enabled = false;
                CreateButton.Text = "Apply";
                CreateButton.Click += ApplyButton_Click;
                CreateButton.Enabled = false;
            } else CreateButton.Click += CreateButton_Click;
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
            string login    =   LoginBox.Text;
            string pass    =   passBox1.Text;
            string pass2    =   passBox2.Text;
            string dob      =   dateTime.Text;
            string firstName =  nameBox.Text;
            string lastName =   surnameBox.Text;

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
                MessageBocMethod("notUniq",login);
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
                passBox1.Text = reUser.Pass;
                nameBox.Text = reUser.Pass;
                searchButton.Enabled = false;
            }
        }

        private void CancelSellButton_Click(object sender, EventArgs e) {this.Close();}
        private void CloseForm_Click(object sender, EventArgs e) { this.Close(); }
    }
    #endregion
}
