using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace BSUIR.Image.Filters
{
    public class MedianFilter : IFilter
    {
        public System.Drawing.Bitmap Filter(Bitmap image)
        {
            Bitmap transformed = new Bitmap(image);

            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    var pixels =  this.GetPixels(image, x, y);
                    pixels.Sort((pixel1, pixel2) => { return pixel1.GetBrightness().CompareTo(pixel2.GetBrightness()); });
                    if (pixels[4].GetBrightness() == pixels[0].GetBrightness())
                    {
                        pixels[0] = pixels[1];
                    }
                    if (pixels[4].GetBrightness() == pixels[8].GetBrightness())
                    {
                        pixels[0] = pixels[7];
                    }

                    this.SetPixels(transformed, x, y, pixels);
                }
            }
            return transformed;
        }

        protected List<Color> GetPixels( Bitmap src, int x, int y )
        {
            return new List<Color>(9)
            {
                src.GetPixel(x-1,y-1),
                src.GetPixel(x,y-1),
                src.GetPixel(x+1,y-1),
                src.GetPixel(x-1,y),
                src.GetPixel(x,y),
                src.GetPixel(x+1,y),
                src.GetPixel(x-1,y+1),
                src.GetPixel(x,y+1),
                src.GetPixel(x+1,y+1)
            };
        }

        protected void SetPixels(Bitmap src, int x, int y, List<Color> pixels)
        {
            src.SetPixel(x - 1, y - 1, pixels[0]);
            src.SetPixel(x, y - 1, pixels[1]);
            src.SetPixel(x + 1, y - 1, pixels[2]);
            src.SetPixel(x - 1, y, pixels[3]);
            src.SetPixel(x, y, pixels[4]);
            src.SetPixel(x + 1, y, pixels[5]);
            src.SetPixel(x - 1, y + 1, pixels[6]);
            src.SetPixel(x, y + 1, pixels[7]);
            src.SetPixel(x + 1, y + 1, pixels[8]);
        }
    }
}
