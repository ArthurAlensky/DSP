using System;
using System.Drawing;
using System.Collections.Generic;

namespace BSUIR.Image.Filters
{
    public class RobertsFilter : IFilter
    {
        public Bitmap Filter(Bitmap image)
        {
            Bitmap transformed = new Bitmap(image);

            for (int y = 0; y < image.Height - 1; y++)
            {
                for (int x = 0; x < image.Width - 1; x++)
                {
                    var q = new
                    {
                        R = image.GetPixel(x, y).R - image.GetPixel(x + 1, y + 1).R,
                        G = image.GetPixel(x, y).G - image.GetPixel(x + 1, y + 1).G,
                        B = image.GetPixel(x, y).B - image.GetPixel(x + 1, y + 1).B
                    };
                    var p = new
                    {
                        R = image.GetPixel(x + 1, y).R - image.GetPixel(x, y + 1).R,
                        G = image.GetPixel(x + 1, y).G - image.GetPixel(x, y + 1).G,
                        B = image.GetPixel(x + 1, y).B - image.GetPixel(x, y + 1).B
                    };
                    Color s = Color.FromArgb(
                        (byte)Math.Sqrt(Math.Pow(p.R, 2) + Math.Pow(q.R, 2)),
                        (byte)Math.Sqrt(Math.Pow(p.G, 2) + Math.Pow(q.G, 2)),
                        (byte)Math.Sqrt(Math.Pow(p.B, 2) + Math.Pow(q.B, 2)));

                    transformed.SetPixel(x, y, s);
                }
            }
            return transformed;
        }
    }
}
