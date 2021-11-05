using System;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form5 : Form
    {
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
            } else CreateButton.Click += CreateButton_Click;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string login    =   LoginBox.Text;
            string pass    =   passBox1.Text;
            string pass2    =   passBox2.Text;
            string dob      =   dateTime.Text;
            string firstName =  nameBox.Text;
            string lastName =   surnameBox.Text;

            //no empty fields allowed
            if (login == "" | pass == "" | pass2 == "" | firstName == "" | lastName == "")
            {
                MessageBox.Show("Didn't you forgot something?");
                return;
            }
            //passwords must be equal
            if (pass != pass2)
            {
                MessageBox.Show("Passwords must be Equal.");
                return;
            }
            //user must be at least 12 years old
            if (DateTime.Now.Year - dateTime.Value.Year < 12)
            {
                MessageBox.Show("You are a bit too young my friend\nOnly older than 12 years are aloud ;)");
                return;
            }
            //login must be uniq
            if (ca.CheckLogin(login))
            {
                MessageBox.Show($"Login {login} exist.\nChange the Login please.");
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
                MessageBox.Show("Didn't you forgot something?");
                return;
            }
            //passwords must be equal
            if (pass != pass2)
            {
                MessageBox.Show("Passwords must be Equal.");
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
                MessageBox.Show("Didn't you forgot something?");
                return;
            }
            //user must be at least 12 years old
            if (DateTime.Now.Year - dateTime.Value.Year < 12)
            {
                MessageBox.Show("You are a bit too young my friend\nOnly older than 12 years are aloud ;)");
                return;
            }
            //now checking combination
            reUser = ca.SearchUser(login, dob);
            if (reUser.Id == 0)
            {
                MessageBox.Show("OOops, Combinations did't been found.");
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
}
