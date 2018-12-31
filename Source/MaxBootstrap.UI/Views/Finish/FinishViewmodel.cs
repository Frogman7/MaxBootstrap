using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;

namespace MaxBootstrap.UI.Views.Finish
{
    public class FinishViewmodel : ViewmodelBase, IFinishViewmodel
    {
        public string FinishedText { get; protected set; }

        public bool IsRestartRequired
        {
            get { return this.BootstrapperController.RestartRequired; }
        }

        public string RestartRequiredText { get; set; }

        public FinishViewmodel(IBootstrapperController bootstrapperController, IView view)
            : base(bootstrapperController, view)
        {
        }

        public override void OnNavigatedTo()
        {
            this.FinishedText = this.BootstrapperController.LaunchAction.ToString() + " finished successfully";
            this.NotifyPropertyChanged(nameof(this.FinishedText));
        }
    }
}
