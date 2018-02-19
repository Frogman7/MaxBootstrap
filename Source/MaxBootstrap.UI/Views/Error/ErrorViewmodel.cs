using MaxBootstrap.Core;
using MaxBootstrap.UI.Viewmodels;

namespace MaxBootstrap.UI.Views.Error
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
