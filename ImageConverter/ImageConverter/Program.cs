using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageConverter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            StringWriter colorString = new StringWriter();
            Bitmap bitmap = new Bitmap(@"C:\dev\limejs\545\assets\test.png");
            int sizeX = 10;
            int sizeY = 10;

            colorString.Write("[");
            for (int y = 0; y < bitmap.Height; y += sizeY)
                for (int x = 0; x < bitmap.Width; x += sizeX)
                {
                    uint averageR = 0;
                    uint averageG = 0;
                    uint averageB = 0;
                    Color currentColor;

                    for(int innerX = x; innerX < x + sizeX; ++innerX)
                        for (int innerY = y; innerY < y + sizeY; ++innerY)
                        {
                            currentColor = bitmap.GetPixel(innerX, innerY);
                            averageR += currentColor.R;
                            averageG += currentColor.G;
                            averageB += currentColor.B;
                        }

                    averageR /= (uint)(sizeX * sizeY);
                    averageG /= (uint)(sizeX * sizeY);
                    averageB /= (uint)(sizeX * sizeY);

                    colorString.Write("'#" + averageR.ToString("X2") + averageG.ToString("X2") + averageB.ToString("X2") + "',");
                }

            colorString.Write("]");
            Clipboard.SetText(colorString.ToString());
        }
    }
}
