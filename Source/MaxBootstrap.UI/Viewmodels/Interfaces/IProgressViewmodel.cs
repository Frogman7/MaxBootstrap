using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Viewmodels.Interfaces
{
    public interface IProgressViewmodel : IViewmodel
    {
        ushort TotalProgress { get; }

        ushort PackageProgress { get; }

        string CurrentPackageName { get; }
    }
}
