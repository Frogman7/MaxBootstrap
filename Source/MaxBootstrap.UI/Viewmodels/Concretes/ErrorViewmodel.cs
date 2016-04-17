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
            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Text = "Close";
            this.ErrorMessageText = bootstrapperController.Error;
        }

        public string ErrorMessageText { get; private set; }
    }
}
