using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class ErrorViewmodel : ViewmodelBase, IErrorViewmodel
    {
        public ErrorViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
        }

        public string ErrorMessageText
        {
            get { return this.BootstrapperController.Error; }
        }
    }
}
