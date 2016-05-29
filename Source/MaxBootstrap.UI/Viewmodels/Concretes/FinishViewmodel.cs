using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

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
    }
}
