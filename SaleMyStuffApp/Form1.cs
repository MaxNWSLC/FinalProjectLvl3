using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form1 : Form
    {
        readonly string path = @"Resources\Settings.txt";
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(path))
            {// Create a file to write to.
                string setting = $"Linen,Left";
                File.WriteAllText(path, setting);
            }
            string[] settings = File.ReadAllText(path).Split(',');
            ApplyTheme(settings);
        }
        void ApplyTheme(string[] settings)
        {
            ThemeClass theme = new ThemeClass("", System.Drawing.Color.Wheat, System.Drawing.Color.Wheat, System.Drawing.Color.Wheat, System.Drawing.Color.Wheat, System.Drawing.Color.Wheat, System.Windows.Forms.DockStyle.Left);
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
                default:
                    theme.Linen();
                    break;
            }
            //apply theme to the controls
            Control[] primary = { panel1, label1, label2, label3, label4, linkLabel1, linkLabel2 };
            foreach (var item in primary) item.BackColor = theme.PrimaryBack;
            Control[] texts = { label1, label2, label3, label4, button1 };
            foreach (var item in texts) item.ForeColor = theme.TextColor;
            Control[] headers = { textBox1, textBox2, panel2 };
            foreach (var item in headers) item.BackColor = theme.Header;
            button1.BackColor = theme.Button;
        }
        /// <summary>
        /// login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            UsersClass zzz;// = new UsersClass(0, "", "");
            string login = textBox1.Text;
            string pass = textBox2.Text;

            if (login == "") login = "test";//only for testing purposes !!!
            if (pass == "") pass = "test";//must be deleted on release stage

            zzz = ca.UserLogin(login, pass);
            if (zzz.Id == 0)
                MessageBox.Show("|Ooops|");
            else
            {
                Form2 form2 = new Form2(zzz.Id);
                form2.ShowDialog();
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//register form
            Form5 regForm = new Form5("register");
            regForm.ShowDialog();
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//recover password form
            Form5 recForm = new Form5("recover");
            recForm.ShowDialog();
        }
    }
}
