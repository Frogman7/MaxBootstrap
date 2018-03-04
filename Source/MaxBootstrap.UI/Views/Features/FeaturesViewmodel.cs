using System.Collections.Generic;
using System.Linq;
using MaxBootstrap.Core;

namespace MaxBootstrap.UI.Views.Features
{
    public class FeaturesViewmodel : ViewmodelBase, IFeaturesViewmodel
    {
        public IEnumerable<PackageViewmodel> Packages { get; protected set; }

        public FeaturesViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
            this.Packages = this.BootstrapperController.PackageManager.Packages.Select(
                package => new PackageViewmodel(package));
        }

        public override void Activate()
        {
        }
    }
}
