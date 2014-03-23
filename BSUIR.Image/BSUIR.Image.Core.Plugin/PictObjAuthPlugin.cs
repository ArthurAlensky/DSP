using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using BSUIR.Image.Core.Plugin.PluginEventArgs;
using BSUIR.Image.Core.Plugin.Utilities;
using BSUIR.Image.Filters;

namespace BSUIR.Image.Core.Plugin
{
    public class PictObjAuthPlugin
    {

        protected static readonly int MinSquare = 300;
            
        protected CommandHelpers.Picture Picture = new CommandHelpers.Picture();

        public event EventHandler<FilteringEventArgs> PictureFiltered;
        public event EventHandler<BinarizingEventArgs> PictureBinarized;
        public event EventHandler<ClusteringEventArgs> PictureClustered;

        public void FilterPicture( Bitmap image, int k )
        {
            for (int i = 0; i < k; i++)
            {
                image = new ErosionFilter().Filter(image);
            }

            OnPicutureFiltered(image);
        }

        public void BinarizePicture(Bitmap image, double treschold)
        {
            image = Picture.ToBinary(image, treschold);

            OnPictureBinarized(image);
        }

        public void Authentificate(int k)
        {
            Picture.Labeling();
            var labels = Picture.Labels;
            var colors = Picture.ColorTable;
            var im = new Bitmap(Picture.Width, Picture.Height);

            var parametres = Picture.GetParams().Where(param => param.Value.Area > MinSquare).ToDictionary(val => val.Key, val => val.Value);
            ParamsUtility.KMeans(parametres, k);

            for (int i = 0; i < im.Width; i++)
            {
                for (int j = 0; j < im.Height; j++)
                {
                    im.SetPixel(i, j, labels[i, j] > 1 && parametres.ContainsKey(labels[i, j]) ? parametres[labels[i, j]].Color : Color.White);
                }
            }

            var class1 = parametres.Where(obj => obj.Value.ClassID == 0).Select(obj => obj.Value);
            var class2 = parametres.Where(obj => obj.Value.ClassID == 1).Select(obj => obj.Value);

            OnPictureClustered(im);
        }

        public void OnPicutureFiltered( Bitmap image )
        {
            var handler = Interlocked.CompareExchange(ref PictureFiltered, null, null);

            if (handler != null)
            {
                handler(this, new FilteringEventArgs{ Image = image} );
            }
        }

        public void OnPictureBinarized(Bitmap image)
        {
            var handler = Interlocked.CompareExchange(ref PictureBinarized, null, null);

            if (handler != null)
            {
                handler(this, new BinarizingEventArgs { Image = image });
            }
        }

        public void OnPictureClustered(Bitmap image)
        {
            var handler = Interlocked.CompareExchange(ref PictureClustered, null, null);

            if (handler != null)
            {
                handler(this, new ClusteringEventArgs(){ Image = image });
            }
        }
    }
}
