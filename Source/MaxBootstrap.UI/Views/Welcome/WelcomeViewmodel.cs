using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using System.IO;
using System.Reflection;

namespace MaxBootstrap.UI.Views.Welcome
{
    public class WelcomeViewmodel : ViewmodelBase, IWelcomeViewmodel
    {
        private const string DefaultLicenseFilename = "License.rtf";

        public string LicenseFile { get; private set; }

        public string InstallationDirectory { get; set; }
        public string BrowseButtonText { get; protected set; }
        public string InstallDirectoryLabel { get; protected set; }
        public string LicenseCheckBoxLabel { get; protected set; }

        public bool DisplayInstallDirControl { get; protected set; }

        public bool RequireLicenseAcception { get; protected set; }

        public bool LicenseAccepted { get; set; }

        public WelcomeViewmodel(IBootstrapperController bootstrapperController, IView view)
            : base(bootstrapperController, view)
        {
            var runningDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            this.LicenseFile = Path.Combine(runningDirectory, DefaultLicenseFilename);
        }

        public override void OnNavigatedTo()
        {
            this.BootstrapperController.ViewController.ButtonStateManager.BackButton.Visible = false;
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Visible = false;

            if (this.BootstrapperController.BurnInstallState == Core.Enums.BurnInstallState.Present)
            {
                this.BootstrapperController.ViewController.ButtonStateManager.UninstallButton.Visible = true;
                this.BootstrapperController.ViewController.ButtonStateManager.RepairButton.Visible = true;
                this.BootstrapperController.ViewController.ButtonStateManager.ModifyButton.Visible = true;
            }
            else
            {
                this.BootstrapperController.ViewController.ButtonStateManager.InstallButton.Visible = true;
            }
        }
    }
}