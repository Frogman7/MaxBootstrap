using MaxBootstrap.Core.Packages;
using System;
using MaxBootstrap.Core.Enums;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.Core
{
    public interface IBootstrapperController
    {
        event Action<string> OnCriticalError;

        IntPtr WindowHandle { get; set;  }

        int FinalResult { get; }

        string Error { get; }

        bool Cancelled { get; }

        bool Installed { get; }

        bool UpgradeDetected { get; }

        LaunchAction LaunchAction { get; }

        InstallationResult InstallationResult { get; }

        bool RestartRequired { get; }

        MaxBootstrapper WixBootstrapper { get; }

        IViewController ViewController { get; }

        IPackageManager PackageManager { get; }
    }
}
