using System.Collections.Generic;
using System.Linq;
using MaxBootstrap.Core;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Features
{
    public class FeaturesViewmodel : ViewmodelBase, IFeaturesViewmodel
    {
        public IEnumerable<PackageViewmodel> Packages { get; protected set; }

        public FeaturesViewmodel(IBootstrapperController bootstrapperController, IView view)
            : base(bootstrapperController, view)
        {
            this.Packages = this.BootstrapperController.PackageManager.Packages.Select(
                package => new PackageViewmodel(package));
        }

        public override void OnNavigatedTo()
        {
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Next";
        }
    }
}
