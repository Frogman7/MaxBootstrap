using MaxBootstrap.Core;

namespace MaxBootstrap.UI.Views.Welcome
{
    public class WelcomeViewmodel : ViewmodelBase, IWelcomeViewmodel
    {
        public string LicenseFile { get; private set; }

        public string InstallationDirectory { get; set; }
        public string BrowseButtonText { get; protected set; }
        public string InstallDirectoryLabel { get; protected set; }
        public string LicenseCheckBoxLabel { get; protected set; }

        public bool DisplayInstallDirControl { get; protected set; }

        public bool RequireLicenseAcception { get; protected set; }

        public bool LicenseAccepted { get; set; }

        // The name of the variable that the Wix Burn engine will use to specify the installation directory.
        private string burnInstallationDirectoryVariable;

        public WelcomeViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
        }
    }
}
