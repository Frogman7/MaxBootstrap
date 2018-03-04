using MaxBootstrap.Core;

namespace MaxBootstrap.UI.Views.Cancel
{
    public class CancelViewmodel : ViewmodelBase, ICancelViewmodel
    {
        public CancelViewmodel(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.CancelledText = "Installation was cancelled by the user";
        }

        public string CancelledText { get; }

        public override void Activate()
        {
            this.BootstrapperController.ViewController.ButtonStateManager.CancelButton.Visible = false;
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Finish";
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Visible = true;
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Enabled = true;

            // TODO Reconsider exit strategy and/or exit code?
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Command = new DelegateCommand(() => System.Environment.Exit(0));
        }
    }
}
