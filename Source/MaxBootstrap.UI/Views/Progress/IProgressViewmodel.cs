using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Progress
{
    public interface IProgressViewmodel : IViewmodel
    {
        ushort TotalProgress { get; }

        ushort PackageProgress { get; }

        string CurrentPackageName { get; }
    }
}
