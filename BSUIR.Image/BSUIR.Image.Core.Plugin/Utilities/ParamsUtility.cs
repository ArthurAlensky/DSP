using BSUIR.Image.Core.Plugin.CommandHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR.Image.Core.Plugin.Utilities
{
    public static class ParamsUtility
    {
        public static void GetDensity(Dictionary<int, Params> parametres)
        {
            foreach (var s in parametres)
            {
                s.Value.Density = (int)Math.Pow(s.Value.Perimeter, 2) / s.Value.Area;
            }
        }

        public static void GetElongation(int[,] image, int width, int height, Dictionary<int, Params> oP)
        {
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if (image[i, j] > 1)
                    {
                        oP[image[i, j]].M20 = (int)Math.Pow(i - oP[image[i, j]].AverageX, 2);
                        oP[image[i, j]].M02 = (int)Math.Pow(j - oP[image[i, j]].AverageY, 2);
                        oP[image[i, j]].M11 = (i - oP[image[i, j]].AverageX) * (j - oP[image[i, j]].AverageY);
                    }
                }

            foreach (var s in oP)
            {
                s.Value.Elongation = (s.Value.M20 + s.Value.M02 + Math.Sqrt(Math.Pow(s.Value.M20 - s.Value.M02, 2) + 4 * Math.Pow(s.Value.M11, 2)))
                                        / (s.Value.M20 - s.Value.M02 + Math.Sqrt(Math.Pow(s.Value.M20 - s.Value.M02, 2) + 4 * Math.Pow(s.Value.M11, 2)));
            }
        }

        public static List<int> Clasterisation(List<int> classes, Dictionary<int, Params> parameters)
        {
            double far, far1, far2;
            double maxFar = 0;
            int cl1 = 0, cl2 = 0;

            foreach (var s in classes)
            {
                foreach (var s1 in classes)
                {
                    far = Math.Sqrt(Math.Pow(parameters[s].Area - parameters[s1].Area, 2) +
                                        Math.Pow(parameters[s].AverageX - parameters[s1].AverageX, 2) +
                                        Math.Pow(parameters[s].AverageY - parameters[s1].AverageY, 2) +
                                        Math.Pow(parameters[s].Density - parameters[s1].Density, 2) +
                                        Math.Pow(parameters[s].Elongation - parameters[s1].Elongation, 2) +
                                        Math.Pow(parameters[s].Perimeter - parameters[s1].Perimeter, 2)
                                        );

                    if (far > maxFar)
                    {
                        maxFar = far;
                        cl1 = s;
                        cl2 = s1;
                    }
                }
            }

            if (maxFar > 50)
            {
                var classes1 = new List<int>();
                var classes2 = new List<int>();

                classes1.Add(cl1);
                classes.Remove(cl1);
                parameters[cl1].ClassID = 0;

                classes2.Add(cl2);
                classes.Remove(cl2);
                parameters[cl2].ClassID = 1;

                foreach (var s in classes)
                {
                    far1 = Math.Sqrt(Math.Pow(parameters[s].Area - parameters[cl1].Area, 2) +
                                        Math.Pow(parameters[s].AverageX - parameters[cl1].AverageX, 2) +
                                        Math.Pow(parameters[s].AverageY - parameters[cl1].AverageY, 2) +
                                        Math.Pow(parameters[s].Density - parameters[cl1].Density, 2) +
                                        Math.Pow(parameters[s].Elongation - parameters[cl1].Elongation, 2) +
                                        Math.Pow(parameters[s].Perimeter - parameters[cl1].Perimeter, 2)
                                        );

                    far2 = Math.Sqrt(Math.Pow(parameters[s].Area - parameters[cl2].Area, 2) +
                                        Math.Pow(parameters[s].AverageX - parameters[cl2].AverageX, 2) +
                                        Math.Pow(parameters[s].AverageY - parameters[cl2].AverageY, 2) +
                                        Math.Pow(parameters[s].Density - parameters[cl2].Density, 2) +
                                        Math.Pow(parameters[s].Elongation - parameters[cl2].Elongation, 2) +
                                        Math.Pow(parameters[s].Perimeter - parameters[cl2].Perimeter, 2)
                                        );
                    if (far1 <= far2)
                    {
                        classes1.Add(s);
                        parameters[s].ClassID = 0;
                    }
                    else
                    {
                        classes2.Add(s);
                        parameters[s].ClassID = 1;
                    }
                }

                classes.Clear();
                classes.AddRange(Clasterisation(classes1, parameters));
                classes.AddRange(Clasterisation(classes2, parameters));
            }
            return classes;
        }

    }
}
