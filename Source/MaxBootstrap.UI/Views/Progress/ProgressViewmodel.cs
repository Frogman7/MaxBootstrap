using MaxBootstrap.Core;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaxBootstrap.UI.Views.Progress
{
    public class ProgressViewmodel : ViewmodelBase, IProgressViewmodel, INotifyPropertyChanged
    {
        public ushort TotalProgress { get; protected set; }

        public ushort PackageProgress { get; protected set; }

        public string CurrentPackageName { get; protected set; }

        public ProgressViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void Activate()
        {
            this.BootstrapperController.WixBootstrapper.CacheAcquireProgress += (sender, args) => this.CacheAcquireProgress(args);
            this.BootstrapperController.WixBootstrapper.ExecuteProgress += (sender, args) => this.ExecuteProgress(args);
            this.BootstrapperController.WixBootstrapper.ExecutePackageBegin += (sender, args) => this.ExecutePackageBegin(args);
            this.BootstrapperController.WixBootstrapper.PlanComplete += (sender, args) => this.PlanComplete(args);

            this.BootstrapperController.ViewController.ButtonStateManager.BackButton.Visible = false;
            this.BootstrapperController.ViewController.ButtonStateManager.CancelButton.Visible = true;
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Enabled = false;

            this.BootstrapperController.WixBootstrapper.Engine.Plan(this.BootstrapperController.LaunchAction);
        }

        private void CacheAcquireProgress(CacheAcquireProgressEventArgs args)
        {

        }

        private void ExecutePackageBegin(ExecutePackageBeginEventArgs args)
        {
            var package = this.BootstrapperController.PackageManager.FindPackageById(args.PackageId);

            this.CurrentPackageName = package.DisplayName;
            this.PackageProgress = 0;
            this.NotifyPropertyChanged(nameof(this.CurrentPackageName));
            this.NotifyPropertyChanged(nameof(this.PackageProgress));
        }

        private void ExecuteProgress(ExecuteProgressEventArgs args)
        {
            this.PackageProgress = (ushort)args.ProgressPercentage;

            this.NotifyPropertyChanged(nameof(this.PackageProgress));

            this.TotalProgress += (ushort)args.OverallPercentage;

            this.NotifyPropertyChanged(nameof(this.TotalProgress));
        }

        private void PlanComplete(PlanCompleteEventArgs args)
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
