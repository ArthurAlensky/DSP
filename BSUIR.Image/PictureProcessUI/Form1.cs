using System;
using System.Linq;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using BSUIR.Image.Core.Plugin.PluginEventArgs;
using BSUIR.Image.Core.Plugin.Utilities;
using BSUIR.Image.Filters;
using BSUIR.Image.Core.Plugin;
using BSUIR.Image.Core.Plugin.CommandHelpers;

namespace PictureProcessUI
{
    public partial class Form1 : Form
    {

        protected Picture _processor;

        protected PictObjAuthPlugin Plugin { get; set; }

        public Form1()
        {
            InitializeComponent();

            Plugin = new PictObjAuthPlugin();
            Plugin.PictureFiltered += PluginOnPictureFiltered;
            Plugin.PictureBinarized += PluginOnPictureBinarized;
            Plugin.PictureClustered += PluginOnPictureClustered;

            pbSource.SizeMode = PictureBoxSizeMode.Zoom;
            pbTransformed.SizeMode = PictureBoxSizeMode.Zoom;
            pbHelp.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void PluginOnPictureClustered(object sender, ClusteringEventArgs clusteringEventArgs)
        {
            pbTransformed.Image = clusteringEventArgs.Image;
        }

        private void PluginOnPictureBinarized(object sender, BinarizingEventArgs binarizingEventArgs)
        {
            pbTransformed.Image = binarizingEventArgs.Image;
        }

        private void PluginOnPictureFiltered(object sender, FilteringEventArgs filteringEventArgs)
        {
            pbTransformed.Image = filteringEventArgs.Image;
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
                            pbTransformed.Image = new Bitmap(sourcePicture);
                        }
                    }
                }
                catch { }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Plugin.Authentificate((int)ClusterNumber.Value);
        }

        private void MedianFilterButton_Click(object sender, EventArgs e)
        {
            Plugin.FilterPicture((Bitmap) pbTransformed.Image, 1);
        }

        private void BinarizationButton_Click(object sender, EventArgs e)
        {
            Plugin.BinarizePicture((Bitmap)pbTransformed.Image, (double)numTreshold.Value / 100);
        }

    }
}
