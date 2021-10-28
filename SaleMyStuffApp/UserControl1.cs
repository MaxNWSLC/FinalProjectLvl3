using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public partial class UserControl1 : UserControl
    {
        
        public UserControl1(String[] fields)
        {
            InitializeComponent();
            nameLabel.Text = fields[0];
            PriceLabel.Text = fields[1];
            infoLabel.Text = fields[2];
            pictureBox1.Image = Image.FromFile($"{fields[3]}");
        }
    }
}
