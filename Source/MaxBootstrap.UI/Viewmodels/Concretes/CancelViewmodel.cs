using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class CancelViewmodel : ViewmodelBase, ICancelViewmodel
    {
        public CancelViewmodel(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.CancelledText = "Installation was cancelled by the user";

            this.BootstrapperController.PageController.ButtonStateManager.CancelButton.Visible = false;
            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Text = "Finish";
            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Visible = true;
            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Enabled = true;

            // TODO Reconsider exit strategy and/or exit code?
            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Command = new DelegateCommand(() => System.Environment.Exit(0));
        }

        public string CancelledText { get; }
    }
}
