using System;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form1 : Form
    {
        
        static readonly CatalogAcces ca = new CatalogAcces("Data Source = Resources/SellMyStuff.db");
        public Form1()
        {
            InitializeComponent();
        }

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
    }
}
