using System;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using MaxBootstrap.Core.Enums;
using MaxBootstrap.Core.Packages;

namespace MaxBootstrap.Core
{
    public class BootstrapperController : IBootstrapperController
    {
        public BurnInstallState BurnInstallState { get; protected set; }

        public IPageController PageController { get; protected set; }

        public MaxBootstrapper WixBootstrapper { get; protected set; }

        public int FinalResult { get; protected set; }

        public IPackageManager PackageManager { get; protected set; }

        public BootstrapperController(MaxBootstrapper wixBootstrapper, IPageController pageController, IPackageManager packageManager)
        {
            this.WixBootstrapper = wixBootstrapper;
            this.PageController = pageController;
            this.PackageManager = packageManager;

            WixBootstrapper.Elevate += (sender, eventArgs) => this.elevate(eventArgs);
            WixBootstrapper.Error += (sender, eventArgs) => this.error(eventArgs);
            WixBootstrapper.Shutdown += (sender, eventArgs) => this.shutdown(eventArgs);

            WixBootstrapper.ResolveSource += (sender, eventArgs) => this.resolveSource(eventArgs);
            WixBootstrapper.DetectBegin += (sender, eventArgs) => this.detectBegin(eventArgs);
            WixBootstrapper.DetectRelatedBundle += (sender, eventArgs) => this.detectRelatedBundle(eventArgs);
            WixBootstrapper.DetectCompatiblePackage += (sender, eventArgs) => this.detectCompatiblePackage(eventArgs);
            WixBootstrapper.DetectPriorBundle += (sender, eventArgs) => this.detectPriorBundle(eventArgs);
            WixBootstrapper.DetectPackageBegin += (sender, eventArgs) => this.detectPackageBegin(eventArgs);
            WixBootstrapper.DetectUpdate += (sender, eventArgs) => this.detectUpdate(eventArgs);
            WixBootstrapper.DetectMsiFeature += (sender, eventArgs) => this.detectMsiFeature(eventArgs);
            WixBootstrapper.DetectPackageComplete += (sender, eventArgs) => this.detectPackageComplete(eventArgs);

            WixBootstrapper.ExecuteMsiMessage += (sender, eventArgs) => this.executeMsiMessage(eventArgs);
            WixBootstrapper.RestartRequired += (sender, eventArgs) => this.restartRequired(eventArgs);

            WixBootstrapper.ApplyBegin += (sender, eventArgs) => this.applyBegin(eventArgs);
            WixBootstrapper.ExecuteFilesInUse += (sender, eventArgs) => this.executeFilesInUse(eventArgs);
            WixBootstrapper.ExecutePackageBegin += (sender, eventArgs) => this.executePacakgeBegin(eventArgs);
            WixBootstrapper.ExecutePackageComplete += (sender, eventArgs) => this.executePackageComplete(eventArgs);
            WixBootstrapper.ApplyComplete += (sender, eventArgs) => this.applyComplete(eventArgs);
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
            // Handle restart and possible errors
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
            var package = this.PackageManager.AddPackage(eventArgs.PackageId);
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