using System;
using System.Collections.Generic;
using System.Drawing;

namespace BSUIR.Image.Core.Plugin.CommandHelpers
{
    public class Picture
    {
        private static readonly int _iterationsMax = 1000;

        private int _width;
        private int _height;

        private int[,] _labels;
        private int[,] _image;

        private int _l;

        private bool _stackOverFlow;

        private Point _correction;

        public Bitmap ToBinary(Bitmap image, double b)
        {
            var result = new Bitmap(_width = image.Width, _height = image.Height);
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


        public void  Labeling()
        {
            int grad = 2;
            Random rand = new Random();

            Dictionary<int, Color> colors = new Dictionary<int, Color>();

            _labels = new int[_width, _height];

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++, grad++)
                {
                    _correction.X = i;
                    _correction.Y = j;
                    do
                    {
                        Fill(_correction.X, _correction.Y, grad, 0);
                    } while (_stackOverFlow);
                }
            }
        }

        

        public void Fill(int x, int y, int grad, int iteration)
        {

            _stackOverFlow = iteration++ == _iterationsMax;

            _correction.X = x;
            _correction.Y = y;

            if (_labels[x,y] == 0 && _image[x,y] == 1 && !_stackOverFlow)
            {
                if (x > 0 && !_stackOverFlow)
                    Fill(x - 1, y, grad, iteration);

                if (x < _width - 1 && !_stackOverFlow)
                    Fill(x + 1, y, grad, iteration);

                if (y > 0 && !_stackOverFlow)
                    Fill(x, y - 1, grad, iteration);

                if (y < _height - 1 && !_stackOverFlow)
                    Fill(x, y + 1, grad, iteration);
            }
        }

        //public Dictionary<int, Color> Labeling()
        //{
        //    int grad = 2;
        //    Random rand = new Random();

        //    Dictionary<int, Color> colors = new Dictionary<int, Color>();

        //    for (int i = 0; i < _width; i++)
        //    {
        //        for (int j = 0; j < _height; j++)
        //        {
        //            if (_labels[i, j] == 1)
        //            {
        //                colors[grad] = Color.FromArgb((byte)rand.Next(DateTime.Now.Millisecond) % 256,
        //                    (byte)rand.Next(DateTime.Now.Millisecond) % 256, (byte)rand.Next(DateTime.Now.Millisecond) % 256);

        //                Fill(i, j, grad, 0);
        //                grad++;
        //                _executeList.Clear();
        //            }
        //        }
        //    }
        //    return colors;
        //}

        //public void Fill(int x, int y, int grad, int countIterations)
        //{
        //    if (_labels[x, y] == 1 && countIterations < _maxIteration)
        //    {
        //        try
        //        {
        //            if (countIterations == 0)
        //            {
        //                if (x > 0 && _labels[x - 1, y] > 1)
        //                    grad = _labels[x - 1, y];

        //                if (x < _width - 1 && _labels[x + 1, y] > 1)
        //                    grad = _labels[x + 1, y];

        //                if (y > 0 && _labels[x, y - 1] > 1)
        //                    grad = _labels[x, y - 1];

        //                if (y < _height - 1 && _labels[x, y + 1] > 1)
        //                    grad = _labels[x, y + 1];
        //            }

        //            _labels[x, y] = grad;
        //            countIterations++;
        //            if (countIterations == _maxIteration)
        //            {
        //                _executeList.Add(new Point(x, y));
        //            }
        //        }

        //        catch (Exception)
        //        {
        //        }

        //        ExecuteNextFill(x, y, grad, countIterations);

        //        if (countIterations == 1)
        //        {
        //            for (int i = 0; i < _executeList.Count; i++)
        //                ExecuteNextFill( _executeList[i].X, _executeList[i].Y, grad, 0);
        //        }
        //    }

        //}

        //public void ExecuteNextFill(int x, int y, int grad, int countIterations)
        //{
        //    if (x > 0)
        //        Fill( x - 1, y, grad, countIterations);

        //    if (x < _width - 1)
        //        Fill(x + 1, y, grad, countIterations);

        //    if (y > 0)
        //        Fill(x, y - 1, grad, countIterations);

        //    if (y < _height - 1)
        //        Fill(x, y + 1, grad, countIterations);
        //}

        public Dictionary<int, Params> GetParams()
        {
            var parametres = new Dictionary<int, Params>();
            for (int i = 0; i < _width; i++)
                for (int j = 0; j < _height; j++)
                {
                    if (_labels[i, j] > 1)
                    {
                        parametres[_labels[i, j]].Area++;

                        parametres[_labels[i, j]].AverageX += i;
                        parametres[_labels[i, j]].AverageY += j;

                        bool isLast = false;

                        if (i > 0 && _labels[i - 1, j] != _labels[i, j])
                            isLast = true;

                        if (i < _width - 1 && _labels[i + 1, j] != _labels[i, j])
                            isLast = true;

                        if (j > 0 && _labels[i, j - 1] != _labels[i, j])
                            isLast = true;

                        if (j < _height - 1 && _labels[i, j + 1] != _labels[i, j])
                            isLast = true;

                        if (isLast)
                        {
                            parametres[_labels[i, j]].Perimeter++;
                        }
                    }
                }

            foreach (var parametr in parametres)
            {
                parametr.Value.AverageX /= parametr.Value.Area;
                parametr.Value.AverageY /= parametr.Value.Area;
            }

            return parametres;
        }
        
    }
}
