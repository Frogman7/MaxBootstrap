using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Finish
{
    public interface IFinishViewmodel : IViewmodel
    {
        string FinishedText { get; }

        string RestartRequiredText { get; }
    }
}
