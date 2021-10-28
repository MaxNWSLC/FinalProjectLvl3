using System;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class Form2 : Form
    {
        public string[] tempUserControl= new string[4];
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 1; i++)
            {
                tempUserControl[0] = "Black Chair";
                tempUserControl[1] = "19.55 £";
                tempUserControl[2] = "A lovely chair hardly have been used :D";
                tempUserControl[3] = "Resources/blackChair.jpg";
                var zz = new UserControl1(tempUserControl);
                flowLayoutPanel1.Controls.Add(zz);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 2; i++)
            {
                tempUserControl[0] = "chair";
                tempUserControl[1] = "19.55 £";
                tempUserControl[2] = "A lovely chair hardly have been used :D"; 
                tempUserControl[3] = "Resources/diningBrownChair.jpg";
                var zz = new UserControl1(tempUserControl);
                flowLayoutPanel1.Controls.Add(zz);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 4; i++)
            {
                tempUserControl[0] = "chair";
                tempUserControl[1] = "19.55 £";
                tempUserControl[2] = "A lovely chair hardly have been used :D";
                tempUserControl[3] = "Resources/diningBrownChair.jpg";
                var zz = new UserControl1(tempUserControl);
                flowLayoutPanel1.Controls.Add(zz);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 3; i++)
            {
                tempUserControl[0] = "chair";
                tempUserControl[1] = "19.55 £";
                tempUserControl[2] = "A lovely chair hardly have been used :D";
                tempUserControl[3] = "Resources/diningBrownChair.jpg";
                var zz = new UserControl1(tempUserControl);
                flowLayoutPanel1.Controls.Add(zz);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 5; i++)
            {
                tempUserControl[0] = "table";
                tempUserControl[1] = "19.55 £";
                tempUserControl[2] = "A lovely chair hardly have been used :D";
                tempUserControl[3] = "Resources/diningWhiteChair.jpg";
                var zz = new UserControl1(tempUserControl);
                flowLayoutPanel1.Controls.Add(zz);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
