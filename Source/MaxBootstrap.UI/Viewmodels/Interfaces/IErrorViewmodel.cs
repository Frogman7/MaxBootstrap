using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Viewmodels.Interfaces
{
    public interface IErrorViewmodel : IViewmodel
    {
        string ErrorMessageText { get; }
    }
}
