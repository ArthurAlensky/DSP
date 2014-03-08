using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BSUIR.Image.Core.Plugin.CommandHelpers
{
    public class Params
    {
        public Color Color  { get; set; }

        public int ClassID  { get; set; }

        public int Perimeter    { get; set; }

        public int Area { get; set; }

        public int Density  { get; set; }

        public int AverageX { get; set; }

        public int AverageY { get; set; }

        public double Elongation    { get; set; }

        public int M20  { get; set; }

        public int M02  { get; set; }

        public int M11  { get; set; }

        public Params() 
        {
            Color = Color.White;
        }

    }
}
