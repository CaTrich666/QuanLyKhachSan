using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controls
{
    public static class ThemeColor
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }
        public static List<string> ColorList = new List<string>() { "#1E88E5", "#2980B9", "#5DADE2", "#2ECC71", "#27AE60", "#16A085", "#1ABC9C", "#E67E22",
                                                                    "#D35400", "#F39C12", "#F7DC6F", "#C0392B", "#E91E63", "#8E44AD", "#9B59B6", "#3498DB",
                                                                    "#D35400", "#52BE80", "#7D3C98", "#F5B041", "#48C9B0", "#AF7AC5", "#2E86C1", "#DC7633"
        };
        


        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            //If correction factor is less than 0, darken color.
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            //If correction factor is greater than zero, lighten color.
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }


    }
}
