using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Welcome
{
    public interface IWelcomeViewmodel : IViewmodel
    {
        string LicenseFile { get; }

        string InstallationDirectory { get; set; }

        string BrowseButtonText { get; }

        string InstallDirectoryLabel { get; }

        string LicenseCheckBoxLabel { get; }

        bool DisplayInstallDirControl { get; }

        bool RequireLicenseAcception { get; }

        bool LicenseAccepted { get; set; }
    }
}
