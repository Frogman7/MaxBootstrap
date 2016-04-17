using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class ConfigurationViewmodel : ViewmodelBase, IConfigurationViewmodel
    {
        public ConfigurationViewmodel(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
        }
    }
}
