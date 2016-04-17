using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Viewmodels.Interfaces
{
    public interface IFinishViewmodel : IViewmodel
    {
        string FinishedText { get; }

        string RestartRequiredText { get; }
    }
}
