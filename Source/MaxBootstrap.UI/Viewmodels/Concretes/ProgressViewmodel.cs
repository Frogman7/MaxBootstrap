using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace MaxBootstrap.UI.Viewmodels.Concretes
{
    public class ProgressViewmodel : ViewmodelBase, IProgressViewmodel
    {
        public ushort TotalProgress { get; protected set; }

        public ushort PackageProgress { get; protected set; }

        public string CurrentPackageName { get; protected set; }

        public ProgressViewmodel(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
            this.BootstrapperController.WixBootstrapper.PlanPackageBegin += (sender, args) => this.PlanPackageBegin(args);
            this.BootstrapperController.WixBootstrapper.ExecuteProgress += (sender, args) => this.ExecuteProgress(args);
            this.BootstrapperController.WixBootstrapper.ExecutePackageBegin += (sender, args) => this.ExecutePackageBegin(args);
        }

        private void ExecutePackageBegin(ExecutePackageBeginEventArgs args)
        {
            var package = this.BootstrapperController.PackageManager.FindPackageById(args.PackageId);

            this.CurrentPackageName = package.DisplayName;
        }

        private void ExecuteProgress(ExecuteProgressEventArgs args)
        {
            this.PackageProgress = (ushort)args.ProgressPercentage;

            this.TotalProgress += (ushort)args.OverallPercentage;
        }

        private void PlanPackageBegin(PlanPackageBeginEventArgs args)
        {
            var package = this.BootstrapperController.PackageManager.FindPackageById(args.PackageId);

            if (package == null)
            {
                
            }
        }
    }
}
