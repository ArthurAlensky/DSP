using System;
using System.Drawing;
using System.Collections.Generic;

namespace BSUIR.Image.Filters
{
    public class LogCorrectionFilter : IFilter
    {
        public double C { get; set; }
        public Bitmap Filter(Bitmap image)
        {
            Bitmap transformed = new Bitmap(image);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var pixel = image.GetPixel(x, y);
                    byte r = (byte)(C * Math.Log(1 + pixel.R));
                    byte g = (byte)(C * Math.Log(1 + pixel.G));
                    byte b = (byte)(C * Math.Log(1 + pixel.B));
                    transformed.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return transformed;
        }
    }
}
