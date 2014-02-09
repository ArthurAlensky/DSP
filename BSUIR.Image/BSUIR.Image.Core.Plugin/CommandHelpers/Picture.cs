using System.Drawing;

namespace BSUIR.Image.Core.Plugin.CommandHelpers
{
    public class Picture
    {
        public static Bitmap ToBinary(Bitmap image, double b)
        {
            var result = new Bitmap(image.Width, image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (image.GetPixel(x, y).GetBrightness() >= b)
                        result.SetPixel(x, y, Color.Black);
                    else result.SetPixel(x, y, Color.White);
                }
            }
            return result;
        }

        public static int[,] Labeling(Bitmap image)
        {
            int L = 1;
            int[,] labels = new int[image.Width, image.Height];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Fill(image, labels, x, y, L++);
                }
            }
            return labels;
        }

        private static void Fill(Bitmap image, int[,] labels, int x, int y, int L)
        {
            if (labels[x,y] == 0 && image.GetPixel(x, y).GetBrightness() == 1)
            {
                labels[x,y] = L;
                if (x > 0)
                    Fill(image, labels, x - 1, y, L);

                if (x < image.Width - 1)
                    Fill(image, labels, x + 1, y, L);

                if (y > 0)
                    Fill(image, labels, x, y - 1, L);

                if (y < image.Height - 1)
                    Fill(image, labels, x, y + 1, L);
            }
        }
    }
}
