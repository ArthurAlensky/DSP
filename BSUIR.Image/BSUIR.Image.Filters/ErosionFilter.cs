using System;
using System.Drawing;
using System.Collections.Generic;

namespace BSUIR.Image.Filters
{
    public class ErosionFilter : IFilter
    {
        public Bitmap Filter(Bitmap src)
        {

            var core = new List<Color>() { 
                Color.White,Color.White,Color.Black,Color.White,Color.White,
                Color.White,Color.Black,Color.Black,Color.Black,Color.White,
                Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,
                Color.White,Color.Black,Color.Black,Color.Black,Color.White,
                Color.White,Color.White,Color.Black,Color.White,Color.White
            };

            var result = new Bitmap(src.Width, src.Height);

            bool[,] mask = { { true, true, true }, { true, true, true }, { true, true, true } };
            // W, H – размеры исходного и результирующего изображений
            // MW, MH – размеры структурного множества
            int y, x;
            int MH = 3, MW = 3;
            for (y = MH / 2; y < src.Height - MH / 2; y++)
            {
                for (x = MW / 2; x < src.Width - MW / 2; x++)
                {
                    int minR = 255, minG = 255, minB = 255;
                    for (int j = -MH / 2; j <= MH / 2; j++)
                    {
                        for (int i = -MW / 2; i <= MW / 2; i++)
                        {
                            if ((mask[Math.Abs(i), Math.Abs(j)]) && src.GetPixel(x + i, y + j).R < minR && src.GetPixel(x + i, y + j).G < minG && src.GetPixel(x + i, y + j).B < minB)
                            {
                                minR = src.GetPixel(x + i, y + j).R;
                                minG = src.GetPixel(x + i, y + j).G;
                                minB = src.GetPixel(x + i, y + j).B;
                            }
                        }
                        if (minR != 0 && minG != 0 && minB != 0)
                        {

                        }

                        result.SetPixel(x, y, Color.FromArgb(minR, minG, minB));
                    }
                }
            }
            return result;
        }
    }
}
