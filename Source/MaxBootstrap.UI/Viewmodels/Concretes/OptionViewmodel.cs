using MaxBootstrap.Core;
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
