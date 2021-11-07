using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    class ThemeClass
    {
        string name;
        Color primaryBack;
        Color secondaryBack;
        Color textColor;
        Color button;
        Color header;
        DockStyle dockstyle;

        public ThemeClass(string name, Color primaryBack, Color secondaryBack, Color textColor, Color button, Color header, DockStyle dockstyle)
        {
            this.name = name;
            this.primaryBack = primaryBack;
            this.secondaryBack = secondaryBack;
            this.textColor = textColor;
            this.button = button;
            this.header = header;
            this.dockstyle = dockstyle;
        }

        public string Name { get => name; set => name = value; }
        public Color PrimaryBack { get => primaryBack; set => primaryBack = value; }
        public Color SecondaryBack { get => secondaryBack; set => secondaryBack = value; }
        public Color TextColor { get => textColor; set => textColor = value; }
        public Color Button { get => button; set => button = value; }
        public DockStyle Dockstyle { get => dockstyle; set => dockstyle = value; }
        public Color Header { get => header; set => header = value; }

        public void Linen()
        {
            Name = "Linen";
            PrimaryBack = Color.Linen;
            SecondaryBack = Color.LightSlateGray;
            TextColor = Color.Black;
            Button = Color.Wheat;
            Header = Color.White;
        }
        public void Dark()
        {
            Name = "Dark";
            PrimaryBack = Color.DimGray;
            SecondaryBack = Color.Gainsboro;
            TextColor = Color.WhiteSmoke;
            Button = Color.Gray;
            Header = Color.Gainsboro;
        }
        public void Lime()
        {
            Name = "Lime";
            PrimaryBack = Color.MediumSeaGreen;
            SecondaryBack = Color.SeaGreen;
            TextColor = Color.WhiteSmoke;
            Button = Color.SeaGreen;
            Header = Color.White;
        }
        public void Orange()
        {
            Name = "Orange";
            PrimaryBack = Color.LightSalmon;
            SecondaryBack = Color.Gainsboro;
            TextColor = Color.Black;
            Button = Color.Tomato;
            Header = Color.WhiteSmoke;
        }
    }
}
