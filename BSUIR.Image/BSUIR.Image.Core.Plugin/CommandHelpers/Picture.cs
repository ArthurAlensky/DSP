using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BSUIR.Image.Core.Plugin.Utilities;

namespace BSUIR.Image.Core.Plugin.CommandHelpers
{
    public class Picture
    {
        private static readonly int _iterationsMax = 1000;

        public int Width { get; private set; }
        public int Height { get; private set; }
        private int[,] _image;
        private Dictionary<int, Color> _colors = new Dictionary<int,Color>();

        public Dictionary<int, Color> ColorTable { get { return _colors; } }
        public int[,] Labels { get { return _image; } }

        static List<Point> executeList = new List<Point>();

        public Bitmap ToBinary(Bitmap image, double b)
        {
            var result = new Bitmap(Width = image.Width, Height = image.Height);
            _image = new int[image.Width, image.Height];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (image.GetPixel(x, y).GetBrightness() >= b)
                    {
                        result.SetPixel(x, y, Color.Black);
                        _image[x, y] = 1;
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.White);
                        _image[x, y] = 0;
                    }
                }
            }
            return result;
        }


        public void Labeling()
        {
            int grad = 2;
            Random rand = new Random();
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                {
                    if (_image[i, j] == 1)
                    {
                        if (!_colors.ContainsKey(grad))
                        {
                            _colors.Add(grad, Color.White);
                        }
                        _colors[grad] = Color.FromArgb((byte)rand.Next(DateTime.Now.Millisecond) % 256,
                            (byte)rand.Next(DateTime.Now.Millisecond) % 256, (byte)rand.Next(DateTime.Now.Millisecond) % 256);
                        //countIterations = 0;
                        Fill(i, j, grad, 0);
                        grad++;
                        executeList.Clear();
                    }
                }
        }

        public void Fill(int x, int y, int grad, int countIterations)
        {
            if (_image[x, y] == 1 && countIterations < _iterationsMax)
            {
                try
                {
                    if (countIterations == 0)
                    {
                        if (x > 0 && _image[x - 1, y] > 1)
                            grad = _image[x - 1, y];

                        if (x < Width - 1 && _image[x + 1, y] > 1)
                            grad = _image[x + 1, y];

                        if (y > 0 && _image[x, y - 1] > 1)
                            grad = _image[x, y - 1];

                        if (y < Height - 1 && _image[x, y + 1] > 1)
                            grad = _image[x, y + 1];
                    }

                    _image[x, y] = grad;
                    countIterations++;
                    if (countIterations == _iterationsMax)
                    {
                        executeList.Add(new Point(x, y));
                    }
                }

                catch (Exception)
                {
                    //picture.SetPixel(x, y, Color.Red);
                }

                ExecuteNextFill( x, y, grad, countIterations);

                if (countIterations == 1)
                {
                    //countIterations = 0;
                    for (int i = 0; i < executeList.Count; i++)
                        ExecuteNextFill(executeList[i].X, executeList[i].Y, grad, 0);
                }
            }
        }

        public void ExecuteNextFill(int x, int y, int grad, int countIterations)
        {
            if (x > 0)
                Fill(x - 1, y, grad, countIterations);

            if (x < Width - 1)
                Fill(x + 1, y, grad, countIterations);

            if (y > 0)
                Fill(x, y - 1, grad, countIterations);

            if (y < Height - 1)
                Fill(x, y + 1, grad, countIterations);
        }

        public Dictionary<int, Params> GetParams()
        {
            var parametres = new Dictionary<int, Params>();
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                {
                    if (_image[i, j] > 1)
                    {
                        if (!parametres.ContainsKey(_image[i, j]))
                        {
                            parametres.Add(_image[i, j], new Params());
                        }

                        parametres[_image[i, j]].Area++;

                        parametres[_image[i, j]].AverageX += i;
                        parametres[_image[i, j]].AverageY += j;

                        bool isLast = false;

                        if (i > 0 && _image[i - 1, j] != _image[i, j])
                            isLast = true;

                        if (i < Width - 1 && _image[i + 1, j] != _image[i, j])
                            isLast = true;

                        if (j > 0 && _image[i, j - 1] != _image[i, j])
                            isLast = true;

                        if (j < Height - 1 && _image[i, j + 1] != _image[i, j])
                            isLast = true;

                        if (isLast)
                        {
                            parametres[_image[i, j]].Perimeter++;
                        }
                    }
                }

            foreach (var parametr in parametres)
            {
                parametr.Value.AverageX /= parametr.Value.Area;
                parametr.Value.AverageY /= parametr.Value.Area;
            }

            ParamsUtility.GetDensity(parametres);
            ParamsUtility.GetElongation(_image,Width,Height,parametres);

            return parametres;
        }
        
    }
}
