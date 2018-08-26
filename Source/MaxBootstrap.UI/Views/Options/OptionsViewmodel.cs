using MaxBootstrap.Core;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Options
{
    public class OptionsViewmodel : ViewmodelBase, IOptionsViewmodel
    {
        public OptionsViewmodel(IBootstrapperController bootstrapperController, IView view)
            : base(bootstrapperController, view)
        {
        }

        public override void OnNavigatedTo()
        {
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Next";
        }
    }
}
