using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

using BSUIR.Image.Filters;
using BSUIR.Image.Core.Plugin;
using BSUIR.Image.Core.Plugin.CommandHelpers;

namespace PictureProcessUI
{
    public partial class Form1 : Form
    {

        protected Bitmap _image;

        public Form1()
        {
            InitializeComponent();
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
            var labelizer = new Picture() { Image = _image };

            var thread = new Thread(labelizer.Labeling, 10000000);
            thread.Start();
        }

        private void MedianFilterButton_Click(object sender, EventArgs e)
        {
            _image = new MedianFilter().Filter(_image);
            pbTransformed.Image = _image;
            
        }

        private void BinarizationButton_Click(object sender, EventArgs e)
        {
            _image = Picture.ToBinary(_image, (double)numTreshold.Value / 100);
            pbTransformed.Image = _image;
        }

    }
}
