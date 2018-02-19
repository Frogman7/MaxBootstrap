using MaxBootstrap.Core;
using MaxBootstrap.UI.Viewmodels;

namespace MaxBootstrap.UI.Views.Options
{
    public class OptionsViewmodel : ViewmodelBase, IOptionsViewmodel
    {
        public OptionsViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
        }
    }
}
