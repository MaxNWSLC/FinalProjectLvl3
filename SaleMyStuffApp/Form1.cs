using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form1 : Form
    {
        readonly string path = @"Resources\Settings.txt";
        readonly ThemeClass theme = new ThemeClass("", Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, 
            Color.Wheat, Color.Wheat, Color.Wheat, Color.Wheat, DockStyle.Left);
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        readonly Control[] headers;
        readonly Control[] labels; 

        public Form1()
        {
            InitializeComponent();
            labels = new Control[] { label1, label2, label3, label4, linkLabel1, linkLabel2, panel1 };
            headers = new Control[] { textBox1, textBox2, panel2 };
            if (!File.Exists(path)) 
                File.WriteAllText(path, $"Linen,Left");
            ApplyTheme(File.ReadAllText(path).Split(','));
        }
        /// <summary>
        /// Apply the theme
        /// </summary>
        /// <param name="settings"></param>
        void ApplyTheme(string[] settings)
        {
            switch (settings[0])
            {
                case "Dark":
                    theme.Dark();
                    break;
                case "Lime":
                    theme.Lime();
                    break;
                case "Orange":
                    theme.Orange();
                    break;
                case "Blue":
                    theme.Blue();
                    break;
                default:
                    theme.Linen();
                    break;
            }
            theme.Dockstyle = settings[1] == "Left" ? theme.Left() : theme.Right();
            //apply theme to the controls
            this.BackColor = theme.PrimaryBack;
            foreach (var item in labels)
            {
                item.BackColor = theme.PrimaryBack;
                item.ForeColor = theme.TextColor;
            }
            foreach (var item in headers)
            {
                item.BackColor = theme.HeaderBack;
                item.ForeColor = theme.HeaderFront;
            }
            button1.BackColor = theme.ButtonBack;
            button1.ForeColor = theme.ButtonFront;
        }

        /// <summary>
        /// login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            UsersClass userLogin;// = new UsersClass(0, "", "");
            string login = textBox1.Text;
            string pass = textBox2.Text;

            if (login == "") login = "test";//only for testing purposes !!!
            if (pass == "") pass = "test";//must be deleted on release stage

            userLogin = ca.UserLogin(login, pass);
            if (userLogin.Id == 0)
                MessageBox.Show("|Ooops|");
            else
            {
                Form2 form2 = new Form2(userLogin.Id, theme);
                form2.ShowDialog();
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//register form
            Form5 regForm = new Form5("register", theme);
            regForm.ShowDialog();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//recover password form
            Form5 recForm = new Form5("recover", theme);
            recForm.ShowDialog();
        }
    }
}
