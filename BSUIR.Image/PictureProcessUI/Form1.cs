using System;
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
        public Form1()
        {
            InitializeComponent();
            pbSource.SizeMode = PictureBoxSizeMode.Zoom;
            pbTransformed.SizeMode = PictureBoxSizeMode.Zoom;
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
                        }
                    }
                }
                catch { }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var src = (Bitmap) pbSource.Image;
            var afterMedian = new MedianFilter().Filter(src);
            var binarized = Picture.ToBinary(afterMedian, Convert.ToDouble( tbThreshold.Text ));
            pbTransformed.Image = binarized;
            var labels = Picture.Labeling(binarized);
            //dataGridView1.DataSource = labels;
        }

    }
}
