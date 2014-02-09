using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR.Image.PluginContracts
{
    public interface IPlugin
    {
        void Execute(IPluginContext context);
    }
}
