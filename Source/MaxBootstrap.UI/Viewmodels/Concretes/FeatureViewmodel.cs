using System.Collections.Generic;
using MaxBootstrap.Core;
using MaxBootstrap.Core.Packages;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class FeatureViewmodel : ViewmodelBase, IFeatureViewmodel
    {
        public IEnumerable<IPackage> Packages
        {
            get
            {
                // ReSharper disable once ConvertPropertyToExpressionBody
                return this.BootstrapperController.PackageManager.Packages;
            }
        } 

        public FeatureViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
        }

        public override void Activate()
        {
        }
    }
}
