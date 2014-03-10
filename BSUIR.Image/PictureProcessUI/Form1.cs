using System;
using System.Linq;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using BSUIR.Image.Core.Plugin.Utilities;
using BSUIR.Image.Filters;
using BSUIR.Image.Core.Plugin;
using BSUIR.Image.Core.Plugin.CommandHelpers;

namespace PictureProcessUI
{
    public partial class Form1 : Form
    {

        protected Bitmap _image;
        protected Picture _processor;

        public Form1()
        {
            InitializeComponent();

            _processor = new Picture();

            pbSource.SizeMode = PictureBoxSizeMode.Zoom;
            pbTransformed.SizeMode = PictureBoxSizeMode.Zoom;
            pbHelp.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stream sourcePicture = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\COSI\\ЛР1-весна\\hard";
            openFileDialog.Filter = "pictures (*.jpg) | *.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((sourcePicture = openFileDialog.OpenFile()) != null)
                    {
                        using (sourcePicture)
                        {
                            pbSource.Image = new Bitmap(sourcePicture);
                            _image = new Bitmap(sourcePicture);
                        }
                    }
                }
                catch { }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var labels = _processor.Labeling();

            var im = new Bitmap( _image.Width, _image.Height );

            var parametres = _processor.GetParams().Where(param => param.Value.Area > 100).ToDictionary(val => val.Key, val => val.Value);
            var classes = parametres.Select(param => param.Key).ToList();
            ParamsUtility.Clasterisation(classes, parametres);


            for (int i = 0; i < im.Width; i++)
            {
                for (int j = 0; j < im.Height; j++)
                {
                    im.SetPixel(i, j, labels[i, j] > 1 && parametres.ContainsKey(labels[i, j]) && parametres[labels[i, j]].Area < 1500 ? Color.Red : Color.Black);
                }
            }

            pbTransformed.Image = im;


            var class1 = parametres.Where(obj => obj.Value.ClassID == 0).Select(obj=>obj.Value);
            var class2 = parametres.Where(obj => obj.Value.ClassID == 1).Select(obj => obj.Value);

        }

        private void MedianFilterButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                _image = new ErosionFilter().Filter(_image);
                pbTransformed.Image = _image;
            }

        }

        private void BinarizationButton_Click(object sender, EventArgs e)
        {
            _image = _processor.ToBinary(_image, (double)numTreshold.Value / 100);
            pbTransformed.Image = _image;
        }

    }
}
