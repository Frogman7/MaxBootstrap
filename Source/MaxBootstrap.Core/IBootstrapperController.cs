using MaxBootstrap.Core.Packages;
using System;
using MaxBootstrap.Core.Enums;
using MaxBootstrap.Core.Pages;

namespace MaxBootstrap.Core
{
    public interface IBootstrapperController
    {
        event Action<string> OnCriticalError;

        int FinalResult { get; }

        string Error { get; }

        bool Cancelled { get; }

        InstallationResult InstallationResult { get; }

        bool RestartRequired { get; }

        MaxBootstrapper WixBootstrapper { get; }

        IPageController PageController { get; }

        IPackageManager PackageManager { get; }
    }
}
