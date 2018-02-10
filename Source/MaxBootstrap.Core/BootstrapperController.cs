using System;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using MaxBootstrap.Core.Enums;
using MaxBootstrap.Core.Packages;
using MaxBootstrap.Core.Pages;
using System.ComponentModel;

namespace MaxBootstrap.Core
{
    public class BootstrapperController : IBootstrapperController
    {
        /// <summary>
        /// Fired when a critical error has been thrown with a message regarding what happened.
        /// </summary>
        public event Action<string> OnCriticalError;

        public IntPtr WindowHandle { get; set; }

        public BurnInstallState BurnInstallState { get; protected set; }

        public IViewController ViewController { get; protected set; }

        public bool RestartRequired { get; protected set; }

        public MaxBootstrapper WixBootstrapper { get; protected set; }

        public int FinalResult { get; protected set; }

        public string Error { get; protected set;  }

        public bool Cancelled { get; protected set; }

        public bool UpgradeDetected { get; protected set; }

        public bool PreviouslyInstalled { get; protected set; }

        public InstallationResult InstallationResult { get; protected set; }

        public IPackageManager PackageManager { get; protected set; }

        public LaunchAction LaunchAction { get; protected set; }

        public BootstrapperController(MaxBootstrapper wixBootstrapper, IViewController pageController, IPackageManager packageManager)
        {
            this.WixBootstrapper = wixBootstrapper;
            this.ViewController = pageController;
            this.PackageManager = packageManager;

            this.ViewController.SequenceStarted += this.SetLaunchAction;

            this.WixBootstrapper.Elevate += (sender, eventArgs) => this.Elevate(eventArgs);
            this.WixBootstrapper.Error += (sender, eventArgs) => this.ErrorEcountered(eventArgs);
            this.WixBootstrapper.Shutdown += (sender, eventArgs) => this.Shutdown(eventArgs);

            this.WixBootstrapper.ResolveSource += (sender, eventArgs) => this.ResolveSource(eventArgs);
            this.WixBootstrapper.DetectBegin += (sender, eventArgs) => this.DetectBegin(eventArgs);
            this.WixBootstrapper.DetectRelatedBundle += (sender, eventArgs) => this.DetectRelatedBundle(eventArgs);
            this.WixBootstrapper.DetectCompatiblePackage += (sender, eventArgs) => this.DetectCompatiblePackage(eventArgs);
            this.WixBootstrapper.DetectPriorBundle += (sender, eventArgs) => this.DetectPriorBundle(eventArgs);
            this.WixBootstrapper.DetectPackageBegin += (sender, eventArgs) => this.DetectPackageBegin(eventArgs);
            this.WixBootstrapper.DetectUpdate += (sender, eventArgs) => this.DetectUpdate(eventArgs);
            this.WixBootstrapper.DetectMsiFeature += (sender, eventArgs) => this.DetectMsiFeature(eventArgs);
            this.WixBootstrapper.DetectPackageComplete += (sender, eventArgs) => this.DetectPackageComplete(eventArgs);

            this.WixBootstrapper.PlanPackageBegin += (sender, eventArgs) => this.PlanPackageBegin(eventArgs);
            this.WixBootstrapper.PlanPackageComplete += (sender, eventArgs) => this.PlanPackageComplete(eventArgs);
            this.WixBootstrapper.PlanMsiFeature += (sender, eventArgs) => this.PlanMsiFeature(eventArgs);
            this.WixBootstrapper.PlanBegin += (sender, eventArgs) => this.PlanBegin(eventArgs);
            this.WixBootstrapper.PlanComplete += (sender, eventArgs) => this.PlanComplete(eventArgs);

            this.WixBootstrapper.ExecuteMsiMessage += (sender, eventArgs) => this.ExecuteMsiMessage(eventArgs);
            this.WixBootstrapper.RestartRequired += (sender, eventArgs) => this.RestartRequiredEncountered(eventArgs);

            this.WixBootstrapper.ApplyBegin += (sender, eventArgs) => this.ApplyBegin(eventArgs);
            this.WixBootstrapper.ExecuteFilesInUse += (sender, eventArgs) => this.ExecuteFilesInUse(eventArgs);
            this.WixBootstrapper.ExecutePackageBegin += (sender, eventArgs) => this.ExecutePackageBegin(eventArgs);
            this.WixBootstrapper.ExecutePackageComplete += (sender, eventArgs) => this.ExecutePackageComplete(eventArgs);
            this.WixBootstrapper.ApplyComplete += (sender, eventArgs) => this.ApplyComplete(eventArgs);

            this.LaunchAction = LaunchAction.Unknown;
        }

        private void PlanPackageComplete(PlanPackageCompleteEventArgs eventArgs)
        {
            IPackage package = this.PackageManager.FindPackageById(eventArgs.PackageId);

            if (package != null)
            {
                package.RequestedState = eventArgs.Requested;
            }
        }

        private void SetLaunchAction(Sequence sequence)
        {
            switch (sequence)
            {
                case Sequence.Install:
                    {
                        this.LaunchAction = LaunchAction.Install;
                        break;
                    }
                case Sequence.Uninstall:
                    {
                        this.LaunchAction = LaunchAction.Uninstall;
                        break;
                    }
                case Sequence.Modify:
                    {
                        this.LaunchAction = LaunchAction.Modify;
                        break;
                    }
                case Sequence.Upgrade:
                    {
                        // TODO Verify this is correct
                        this.LaunchAction = LaunchAction.UpdateReplace;
                        break;
                    }
                case Sequence.Repair:
                    {
                        this.LaunchAction = LaunchAction.Repair;
                        break;
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException(nameof(sequence), (int)sequence, typeof(Sequence));
                    }
            }
        }

        private void PlanPackageBegin(PlanPackageBeginEventArgs eventArgs)
        {
            // Allows changing how the package plan
        }

        private void PlanMsiFeature(PlanMsiFeatureEventArgs eventArgs)
        {
            // IDK
        }

        private void PlanBegin(PlanBeginEventArgs eventArgs)
        {
            // IDK
        }

        private void PlanComplete(PlanCompleteEventArgs eventArgs)
        {
            // IDK
        }

        private void DetectUpdate(DetectUpdateEventArgs eventArgs)
        {
            // IDK
        }

        private void Elevate(ElevateEventArgs eventArgs)
        {
            // IDK
        }

        private void RestartRequiredEncountered(RestartRequiredEventArgs eventArgs)
        {
            // IDK
        }

        private void ExecutePackageComplete(ExecutePackageCompleteEventArgs eventArgs)
        {
            // IDK
        }

        private void ExecutePackageBegin(ExecutePackageBeginEventArgs eventArgs)
        {
            // IDK
        }

        private void ExecuteFilesInUse(ExecuteFilesInUseEventArgs eventArgs)
        {
            // Handle files in use messages?
        }

        private void ExecuteMsiMessage(ExecuteMsiMessageEventArgs eventArgs)
        {
            // IDK handle messages from MSI files
        }

        private void DetectPriorBundle(DetectPriorBundleEventArgs eventArgs)
        {
            // IDK
        }

        private void ApplyComplete(ApplyCompleteEventArgs eventArgs)
        {
            this.RestartRequired = eventArgs.Restart == ApplyRestart.RestartRequired;

            this.FinalResult = eventArgs.Status;

            // TODO Handle Unknown state somehow?
            if (this.InstallationResult == InstallationResult.Error ||
                this.InstallationResult == InstallationResult.Cancelled)
            {
                this.WixBootstrapper.BootstrapperDispatcher.BeginInvoke(new Action(() => this.ViewController.GoToErrorView()));
            }
            else
            {
                if (eventArgs.Restart == ApplyRestart.RestartRequired)
                {
                    this.RestartRequired = true;
                }

                this.WixBootstrapper.BootstrapperDispatcher.BeginInvoke(new Action(() => this.ViewController.GoNext()));
            }
        }

        private void ApplyBegin(ApplyBeginEventArgs eventArgs)
        {
            // IDK
        }

        private void ErrorEcountered(ErrorEventArgs eventArgs)
        {
            // Handle error condition
        }

        private void Shutdown(ShutdownEventArgs eventArgs)
        {
            // Handle shutdown
        }

        private void ResolveSource(ResolveSourceEventArgs eventArgs)
        {
            // Handle download logic?
        }

        private void DetectMsiFeature(DetectMsiFeatureEventArgs eventArgs)
        {
            // IDK
        }

        private void DetectPackageComplete(DetectPackageCompleteEventArgs eventArgs)
        {
            IPackage package = this.PackageManager.FindPackageById(eventArgs.PackageId);

            if (package != null)
            {
                package.PackageState = eventArgs.State;
            }
        }

        private void DetectCompatiblePackage(DetectCompatiblePackageEventArgs eventArgs)
        {
            // IDK
        }

        private void DetectRelatedBundle(DetectRelatedBundleEventArgs eventArgs)
        {
            if (eventArgs.Operation == RelatedOperation.MajorUpgrade || eventArgs.Operation == RelatedOperation.MinorUpdate)
            {
                this.ViewController.ButtonStateManager.UpgradeButton.Visible = true;
            }
        }

        /// <summary>
        /// Called when detecting a package in the burn bundle.
        /// </summary>
        /// <param name="eventArgs">
        /// The DetectPackageBeginEventArgs contains the ID of the package being detected and the result
        /// of starting the detection.
        /// </param>
        private void DetectPackageBegin(DetectPackageBeginEventArgs eventArgs)
        {
        }

        /// <summary>
        /// Called when package detection has started.
        /// </summary>
        /// <param name="eventArgs">
        /// The DetectBeginEventArgs contains information on whether the burn bundle is already installed,
        /// number of packages to detect, and the result of starting detection.
        /// </param>
        private void DetectBegin(DetectBeginEventArgs eventArgs)
        {
            if (eventArgs.Installed)
            {
                this.BurnInstallState = BurnInstallState.Present;

                // TODO Have a way for a user to easily enable/disable these buttons
                this.ViewController.ButtonStateManager.UninstallButton.Visible = true;
                this.ViewController.ButtonStateManager.RepairButton.Visible = true;
                this.ViewController.ButtonStateManager.ModifyButton.Visible = true;
            }
            else
            {
                this.BurnInstallState = BurnInstallState.NotPresent;

                this.ViewController.ButtonStateManager.InstallButton.Visible = true;
            }
        }
    }
}