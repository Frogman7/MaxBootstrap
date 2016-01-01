using MaxBootstrap.Core.Packages;
using System;

namespace MaxBootstrap.Core
{
    public interface IBootstrapperController
    {
        event Action<string> OnCriticalError;

        int FinalResult { get; }

        MaxBootstrapper WixBootstrapper { get; }

        IPageController PageController { get; }

        IPackageManager PackageManager { get; }
    }
}
