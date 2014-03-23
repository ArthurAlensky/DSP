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

        public static void KMeans(Dictionary<int, Params> parameters, int k)
        {
            var rand = new Random();
            var clusters = new Dictionary<int, List<int>>();
            var prevClusters = new Dictionary<int, List<int>>();
            var mediums = new List<Params>();
            var colors = new List<System.Drawing.Color> 
            { 
                System.Drawing.Color.Red, 
                System.Drawing.Color.Black, 
                System.Drawing.Color.ForestGreen, 
                System.Drawing.Color.HotPink,
                System.Drawing.Color.DarkBlue,
                System.Drawing.Color.LightYellow
            };

            var labels = parameters.Keys.ToList();

            for (int i = 0; i < k; i++ )
            {
                var medium = parameters[labels[rand.Next(labels.Count - 1)]];
                medium.ClassID = i;
                medium.Color = colors[i];
                mediums.Add(medium);
                clusters.Add(i, new List<int>());
                prevClusters.Add(i, new List<int>());
            }

            while (true)
            {

                foreach (var param in parameters)
                {
                    var distanceMin = double.MaxValue;

                    foreach (var medium in mediums)
                    {
                        var distance = Math.Sqrt(Math.Pow(param.Value.Area - medium.Area, 2) +
                                            Math.Pow(param.Value.AverageX - medium.AverageX, 2) +
                                            Math.Pow(param.Value.AverageY - medium.AverageY, 2) +
                                            Math.Pow(param.Value.Density - medium.Density, 2) +
                                            Math.Pow(param.Value.Elongation - medium.Elongation, 2) +
                                            Math.Pow(param.Value.Perimeter - medium.Perimeter, 2)
                                            );

                        if (distance < distanceMin)
                        {
                            distanceMin = distance;
                            param.Value.ClassID = medium.ClassID;
                            param.Value.Color = medium.Color;
                        }
                    }
                    clusters[param.Value.ClassID].Add(param.Key);
                }

                bool equal = true;

                for (int i = 0; i < k; i++)
                {
                    if ( !clusters[i].SequenceEqual( prevClusters[i] ) )
                    {
                        equal = false;
                        break;
                    }

                }

                if (equal)
                {
                    break;
                }

                mediums.Clear();

                for (int i = 0; i < k; i++)
                {
                    prevClusters[i].Clear();
                    prevClusters[i].AddRange( clusters[i] );

                    var cluster = clusters[i];

                    var medium = new Params
                    {
                        Color = System.Drawing.Color.Violet,
                        ClassID = i
                    };
                    foreach (var key in cluster)
                    {
                        var obj = parameters[key];

                        medium.Color = obj.Color;
                        medium.Area += obj.Area / cluster.Count;
                        medium.AverageX += obj.AverageX / cluster.Count;
                        medium.AverageY += obj.AverageY / cluster.Count;
                        medium.Density += obj.Density / cluster.Count;
                        medium.Elongation += obj.Elongation / cluster.Count;
                        medium.Perimeter += obj.Perimeter / cluster.Count;
                    }
                    mediums.Add(medium);
                    cluster.Clear();
                }

            }
        }
    }
}

