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

        public double Perimeter { get; set; }

        public double Area { get; set; }

        public double Density { get; set; }

        public double AverageX { get; set; }

        public double AverageY { get; set; }

        public double Elongation    { get; set; }

        public double M20 { get; set; }

        public double M02 { get; set; }

        public double M11 { get; set; }

        public Params() 
        {
            Color = Color.White;
        }

    }
}
