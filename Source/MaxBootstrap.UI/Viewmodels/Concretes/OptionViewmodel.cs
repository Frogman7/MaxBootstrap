using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class OptionViewmodel : ViewmodelBase, IOptionViewmodel
    {
        public OptionViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
        }
    }
}
