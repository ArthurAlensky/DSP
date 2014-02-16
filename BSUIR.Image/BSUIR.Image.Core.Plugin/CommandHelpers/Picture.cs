using System.Drawing;

namespace BSUIR.Image.Core.Plugin.CommandHelpers
{
    public class Picture
    {
        public Bitmap Image { set; get; }

        private int[,] _labels;

        private int _l;

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

        public void Labeling()
        {
            _l = 1;
            _labels = new int[Image.Width, Image.Height];
            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width; x++)
                {
                    _l++;
                    Fill( x, y);
                }
            }
        }

        private void Fill(int x, int y)
        {
            var pixel = Image.GetPixel(x, y);
            var brightness = pixel.GetBrightness();
            if (_labels[x, y] == 0 && brightness == 1)
            {
                _labels[x,y] = _l;
                if (x > 0)
                    Fill(x - 1, y);

                if (x < Image.Width - 1)
                    Fill(x + 1, y);

                if (y > 0)
                    Fill(x, y - 1);

                if (y < Image.Height - 1)
                    Fill(x, y + 1);
            }
        }
    }
}
