using MaxBootstrap.Core;
using MaxBootstrap.UI.Viewmodels.Interfaces;
using System;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class FinishViewmodel : ViewmodelBase, IFinishViewmodel
    {
        public string FinishedText { get; protected set; }

        public bool IsRestartRequired
        {
            get { return this.BootstrapperController.RestartRequired; }
        }

        public string RestartRequiredText { get; set; }

        public FinishViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
            this.FinishedText = "Installation Fished Successfully";
        }

        public override void Activate()
        {
            this.BootstrapperController.ViewController.ButtonStateManager.CancelButton.Enabled = false;

            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Finish";
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Visible = true;
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Enabled = true;
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Command = new DelegateCommand(() => { Environment.Exit(0); });
        }
    }
}
