using MaxBootstrap.Core;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class ErrorViewmodel : ViewmodelBase, IErrorViewmodel
    {
        public ErrorViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
        }

        public override void Activate()
        {
            this.NotifyPropertyChanged(nameof(ErrorMessageText));
        }

        public string ErrorMessageText
        {
            get { return this.BootstrapperController.Error; }
        }
    }
}
