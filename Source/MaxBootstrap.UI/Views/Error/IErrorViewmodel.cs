using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Error
{
    public interface IErrorViewmodel : IViewmodel
    {
        string ErrorMessageText { get; }
    }
}
