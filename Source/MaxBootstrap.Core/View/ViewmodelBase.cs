using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.Core.View
{
    public class ViewmodelBase : IViewmodel
    {
        public ViewmodelBase(IBootstrapperController bootstrapperController)
        {
            this.BootstrapperController = bootstrapperController;
        }

        public IView View { get; set; }

        public IBootstrapperController BootstrapperController { get; private set; }
    }
}
