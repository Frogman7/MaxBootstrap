using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class CancelViewmodel : ViewmodelBase, ICancelViewmodel
    {
        public CancelViewmodel(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.CancelledText = "Installation was user cancelled";
        }

        public string CancelledText { get; }
    }
}
