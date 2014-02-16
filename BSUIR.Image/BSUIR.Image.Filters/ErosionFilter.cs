using System;
using System.Drawing;
using System.Collections.Generic;

namespace BSUIR.Image.Filters
{
    public class ErosionFilter : IFilter
    {
        public Bitmap Filter(Bitmap image)
        {

            var core = new List<Color>() { 
                Color.White,Color.White,Color.Black,Color.White,Color.White,
                Color.White,Color.Black,Color.Black,Color.Black,Color.White,
                Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,
                Color.White,Color.Black,Color.Black,Color.Black,Color.White,
                Color.White,Color.White,Color.Black,Color.White,Color.White
            };

            Bitmap transformed = new Bitmap(image.Width, image.Height);

            for (int y = 2; y < image.Height - 2; y++)
            {
                for (int x = 2; x < image.Width - 2; x++)
                {
                    for (int z = 0, t = 0; z < 4; z++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            var color1 = core[t++] == Color.White ? 1 : 0;
                            var color2 = image.GetPixel(x + k - 2, y + z - 2) == Color.White ? 1 : 0;
                            transformed.SetPixel(x + k - 2, y + z - 2, color1 * color2 == 0 ? Color.Black : Color.White);
                        }
                    }
                }
            }
            return transformed;
        }
    }
}
