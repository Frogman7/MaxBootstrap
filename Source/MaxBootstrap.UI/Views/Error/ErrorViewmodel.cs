using MaxBootstrap.Core;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Error
{
    public class ErrorViewmodel : ViewmodelBase, IErrorViewmodel
    {
        public ErrorViewmodel(IBootstrapperController bootstrapperController, IView view)
            : base(bootstrapperController, view)
        {
        }

        public override void OnNavigatedTo()
        {
            this.NotifyPropertyChanged(nameof(ErrorMessageText));
        }

        public string ErrorMessageText
        {
            get { return this.BootstrapperController.Error; }
        }
    }
}