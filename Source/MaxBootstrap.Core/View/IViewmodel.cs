using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.Core.View
{
    public interface IViewmodel
    {
        IView View { get; set; }

        IBootstrapperController BootstrapperController { get; }
    }
}
