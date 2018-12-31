using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaxBootstrap.UI.Views.Progress
{
    public class ProgressViewmodel : ViewmodelBase, IProgressViewmodel, INotifyPropertyChanged
    {
        public ushort TotalProgress { get; protected set; }

        public ushort PackageProgress { get; protected set; }

        public string CurrentPackageName { get; protected set; }

        public ProgressViewmodel(IBootstrapperController bootstrapperController, IView view)
            : base(bootstrapperController, view)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void OnNavigatedTo()
        {
            this.BootstrapperController.WixBootstrapper.CacheAcquireProgress += this.CacheAcquireProgress;
            this.BootstrapperController.WixBootstrapper.ExecuteProgress += this.ExecuteProgress;
            this.BootstrapperController.WixBootstrapper.ExecutePackageBegin += this.ExecutePackageBegin;
            this.BootstrapperController.WixBootstrapper.PlanComplete += this.PlanComplete;

            this.BootstrapperController.ViewController.ButtonStateManager.BackButton.Visible = false;
            this.BootstrapperController.ViewController.ButtonStateManager.CancelButton.Visible = true;
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Enabled = false;

            this.BootstrapperController.WixBootstrapper.Engine.Plan(this.BootstrapperController.LaunchAction);
        }

        public override void OnNavigatedFrom()
        {
            this.BootstrapperController.WixBootstrapper.CacheAcquireProgress -= this.CacheAcquireProgress;
            this.BootstrapperController.WixBootstrapper.ExecuteProgress -= this.ExecuteProgress;
            this.BootstrapperController.WixBootstrapper.ExecutePackageBegin -= this.ExecutePackageBegin;
            this.BootstrapperController.WixBootstrapper.PlanComplete -= this.PlanComplete;
        }

        private void CacheAcquireProgress(object sender, CacheAcquireProgressEventArgs args)
        {

        }

        private void ExecutePackageBegin(object sender, ExecutePackageBeginEventArgs args)
        {
            var package = this.BootstrapperController.PackageManager.FindPackageById(args.PackageId);

            this.CurrentPackageName = package.DisplayName;
            this.PackageProgress = 0;
            this.NotifyPropertyChanged(nameof(this.CurrentPackageName));
            this.NotifyPropertyChanged(nameof(this.PackageProgress));
        }

        private void ExecuteProgress(object sender, ExecuteProgressEventArgs args)
        {
            this.PackageProgress = (ushort)args.ProgressPercentage;

            this.NotifyPropertyChanged(nameof(this.PackageProgress));

            this.TotalProgress += (ushort)args.OverallPercentage;

            this.NotifyPropertyChanged(nameof(this.TotalProgress));
        }

        private void PlanComplete(object sender, PlanCompleteEventArgs args)
        {
            if (args.Status >= 0)
            {
                this.BootstrapperController.WixBootstrapper.Engine.Apply(System.IntPtr.Zero);
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null && this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}