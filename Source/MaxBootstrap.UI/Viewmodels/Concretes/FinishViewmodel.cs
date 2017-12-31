using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
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
            this.BootstrapperController.PageController.ButtonStateManager.CancelButton.Enabled = false;

            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Text = "Finish";
            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Visible = true;
            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Enabled = true;
            this.BootstrapperController.PageController.ButtonStateManager.NextButton.Command = new DelegateCommand(() => { Environment.Exit(0); });

            this.FinishedText = "Installation Fished Successfully";
        }
    }
}
