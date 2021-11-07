using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    public class ThemeClass
    {
        string name;
        Color primaryBack;
        Color secondaryBack;
        Color textColor;
        Color buttonFront;
        Color buttonBack;
        Color headerFront;
        Color headerBack;
        DockStyle dockstyle;

        public ThemeClass(string name, Color primaryBack, Color secondaryBack, Color textColor, 
            Color buttonFront, Color buttonBack, Color headerFront, Color headerBack, DockStyle dockstyle)
        {
            this.name = name;
            this.primaryBack = primaryBack;
            this.secondaryBack = secondaryBack;
            this.textColor = textColor;
            this.buttonFront = buttonFront;
            this.buttonBack = buttonBack;
            this.headerFront = headerFront;
            this.headerBack = headerBack;
            this.dockstyle = dockstyle;
        }

        public string Name { get => name; set => name = value; }
        public Color PrimaryBack { get => primaryBack; set => primaryBack = value; }
        public Color SecondaryBack { get => secondaryBack; set => secondaryBack = value; }
        public Color TextColor { get => textColor; set => textColor = value; }
        public Color ButtonFront { get => buttonFront; set => buttonFront = value; }
        public Color ButtonBack { get => buttonBack; set => buttonBack = value; }
        public DockStyle Dockstyle { get => dockstyle; set => dockstyle = value; }
        public Color HeaderBack { get => headerBack; set => headerBack = value; }
        public Color HeaderFront { get => headerFront; set => headerFront = value; }

        public void Linen()
        {
            Name = "Linen";
            PrimaryBack = Color.Linen;
            SecondaryBack = Color.LightSlateGray;
            TextColor = Color.Black;
            ButtonFront = Color.Black;
            ButtonBack = Color.Wheat;
            HeaderFront = Color.Black;
            HeaderBack = Color.WhiteSmoke;
        }
        public void Dark()
        {
            Name = "Dark";
            PrimaryBack = Color.FromArgb(64, 64, 64);
            SecondaryBack = Color.Black;
            TextColor = Color.Gainsboro;
            ButtonFront = Color.WhiteSmoke;
            ButtonBack = Color.Gray;
            HeaderFront = Color.Black;
            HeaderBack = Color.Gainsboro;
        }
        public void Lime()
        {
            Name = "Lime";
            PrimaryBack = Color.MediumSeaGreen;
            SecondaryBack = Color.DarkSeaGreen;
            TextColor = Color.WhiteSmoke;
            ButtonFront = Color.WhiteSmoke;
            ButtonBack = Color.SeaGreen;
            HeaderFront = Color.Black;
            HeaderBack = Color.WhiteSmoke;
        }
        public void Orange()
        {
            Name = "Orange";
            PrimaryBack = Color.LightSalmon;
            SecondaryBack = Color.Silver;
            TextColor = Color.SeaShell;
            ButtonFront = Color.WhiteSmoke;
            ButtonBack = Color.Tomato;
            HeaderFront = Color.Black;
            HeaderBack = Color.WhiteSmoke;
        }
        public DockStyle Left()
        {
            return Dockstyle = DockStyle.Left;
        }
        public DockStyle Right()
        {
            return Dockstyle = DockStyle.Right;
        }
    }
}
