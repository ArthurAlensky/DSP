﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR.Image.Core.Plugin.PluginEventArgs
{
    public class ClusteringEventArgs : EventArgs
    {
        public Bitmap Image { get; set; }
    }
}
