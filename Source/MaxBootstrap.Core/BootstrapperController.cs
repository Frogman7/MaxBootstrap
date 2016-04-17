using System;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using MaxBootstrap.Core.Enums;
using MaxBootstrap.Core.Packages;
using MaxBootstrap.Core.Pages;

namespace MaxBootstrap.Core
{
    public class BootstrapperController : IBootstrapperController
    {
        public BurnInstallState BurnInstallState { get; protected set; }

        public IPageController PageController { get; protected set; }

        public ButtonStateManager ButtonStateManager { get; protected set; }

        public bool RestartRequired { get; protected set; }
        public MaxBootstrapper WixBootstrapper { get; protected set; }

        public int FinalResult { get; protected set; }

        public string Error { get; protected set;  }

        public bool Cancelled { get; protected set; }

        public InstallationResult InstallationResult { get; protected set; }

        public IPackageManager PackageManager { get; protected set; }

        public BootstrapperController(MaxBootstrapper wixBootstrapper, IPageController pageController, IPackageManager packageManager)
        {
            this.WixBootstrapper = wixBootstrapper;
            this.PageController = pageController;
            this.PackageManager = packageManager;

            this.WixBootstrapper.Elevate += (sender, eventArgs) => this.elevate(eventArgs);
            this.WixBootstrapper.Error += (sender, eventArgs) => this.error(eventArgs);
            this.WixBootstrapper.Shutdown += (sender, eventArgs) => this.shutdown(eventArgs);

            this.WixBootstrapper.ResolveSource += (sender, eventArgs) => this.resolveSource(eventArgs);
            this.WixBootstrapper.DetectBegin += (sender, eventArgs) => this.detectBegin(eventArgs);
            this.WixBootstrapper.DetectRelatedBundle += (sender, eventArgs) => this.detectRelatedBundle(eventArgs);
            this.WixBootstrapper.DetectCompatiblePackage += (sender, eventArgs) => this.detectCompatiblePackage(eventArgs);
            this.WixBootstrapper.DetectPriorBundle += (sender, eventArgs) => this.detectPriorBundle(eventArgs);
            this.WixBootstrapper.DetectPackageBegin += (sender, eventArgs) => this.detectPackageBegin(eventArgs);
            this.WixBootstrapper.DetectUpdate += (sender, eventArgs) => this.detectUpdate(eventArgs);
            this.WixBootstrapper.DetectMsiFeature += (sender, eventArgs) => this.detectMsiFeature(eventArgs);
            this.WixBootstrapper.DetectPackageComplete += (sender, eventArgs) => this.detectPackageComplete(eventArgs);

            this.WixBootstrapper.ExecuteMsiMessage += (sender, eventArgs) => this.executeMsiMessage(eventArgs);
            this.WixBootstrapper.RestartRequired += (sender, eventArgs) => this.restartRequired(eventArgs);

            this.WixBootstrapper.ApplyBegin += (sender, eventArgs) => this.applyBegin(eventArgs);
            this.WixBootstrapper.ExecuteFilesInUse += (sender, eventArgs) => this.executeFilesInUse(eventArgs);
            this.WixBootstrapper.ExecutePackageBegin += (sender, eventArgs) => this.executePacakgeBegin(eventArgs);
            this.WixBootstrapper.ExecutePackageComplete += (sender, eventArgs) => this.executePackageComplete(eventArgs);
            this.WixBootstrapper.ApplyComplete += (sender, eventArgs) => this.applyComplete(eventArgs);
        }

        private void detectUpdate(DetectUpdateEventArgs eventArgs)
        {
            // IDK
        }

        private void elevate(ElevateEventArgs eventArgs)
        {
            // IDK
        }

        private void restartRequired(RestartRequiredEventArgs eventArgs)
        {
            // IDK
        }

        private void executePackageComplete(ExecutePackageCompleteEventArgs eventArgs)
        {
            // IDK
        }

        private void executePacakgeBegin(ExecutePackageBeginEventArgs eventArgs)
        {
            // IDK
        }

        private void executeFilesInUse(ExecuteFilesInUseEventArgs eventArgs)
        {
            // Handle files in use messages?
        }

        private void executeMsiMessage(ExecuteMsiMessageEventArgs eventArgs)
        {
            // IDK handle messages from MSI files
        }

        private void detectPriorBundle(DetectPriorBundleEventArgs eventArgs)
        {
            // IDK
        }

        private void applyComplete(ApplyCompleteEventArgs eventArgs)
        {
            this.RestartRequired = eventArgs.Restart == ApplyRestart.RestartRequired;

            this.FinalResult = eventArgs.Status;

            // TODO Handle Unknown state somehow?
            if (this.InstallationResult == InstallationResult.Error ||
                this.InstallationResult == InstallationResult.Cancelled)
            {
                this.WixBootstrapper.BootstrapperDispatcher.BeginInvoke(new Action(() => this.PageController.GoToErrorPage()));
            }
            else
            {
                if (eventArgs.Restart == ApplyRestart.RestartRequired)
                {
                    this.RestartRequired = true;
                }

                this.WixBootstrapper.BootstrapperDispatcher.BeginInvoke(new Action(() => this.PageController.GoNext()));
            }
        }

        private void applyBegin(ApplyBeginEventArgs eventArgs)
        {
            // IDK
        }

        private void error(ErrorEventArgs eventArgs)
        {
            // Handle error condition
        }

        private void shutdown(ShutdownEventArgs eventArgs)
        {
            // Handle shutdown
        }

        private void resolveSource(ResolveSourceEventArgs eventArgs)
        {
            // Handle download logic?
        }

        private void detectMsiFeature(DetectMsiFeatureEventArgs eventArgs)
        {
            // IDK
        }

        private void detectPackageComplete(DetectPackageCompleteEventArgs eventArgs)
        {
            // IDK
        }

        private void detectCompatiblePackage(DetectCompatiblePackageEventArgs eventArgs)
        {
            // IDK
        }

        private void detectRelatedBundle(DetectRelatedBundleEventArgs eventArgs)
        {
            // IDK
        }

        /// <summary>
        /// Called when detecting a package in the burn bundle.
        /// </summary>
        /// <param name="eventArgs">
        /// The DetectPackageBeginEventArgs contains the ID of the package being detected and the result
        /// of starting the detection.
        /// </param>
        private void detectPackageBegin(DetectPackageBeginEventArgs eventArgs)
        {
        }

        public event Action<string> OnCriticalError;

        /// <summary>
        /// Called when package detection has started.
        /// </summary>
        /// <param name="eventArgs">
        /// The DetectBeginEventArgs contains information on whether the burn bundle is already installed,
        /// number of packages to detect, and the result of starting detection.
        /// </param>
        private void detectBegin(DetectBeginEventArgs eventArgs)
        {
            this.BurnInstallState = eventArgs.Installed ? BurnInstallState.Present : BurnInstallState.NotPresent;
        }
    }
}