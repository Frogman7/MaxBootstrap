using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Views.Cancel;
using MaxBootstrap.UI.Views.Error;
using MaxBootstrap.UI.Views.Feature;
using MaxBootstrap.UI.Views.Finish;
using MaxBootstrap.UI.Views.Progress;
using MaxBootstrap.UI.Views.Welcome;
using System.Collections.Generic;

namespace MaxBootstrap.UI.Extensions
{
    public static class ViewControllerExtensions
    {
        public static void SetDefaultStartPage(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<WelcomeView>(new WelcomeViewmodel(bootstrapperController), true);

            viewController.ViewCollection.StartPage = "WelcomeView";
        }

        public static void SetDefaultCancelPage(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<CancelView>(new CancelViewmodel(bootstrapperController));

            viewController.ViewCollection.CancelPage = "CancelView";
        }

        public static void SetDefaultErrorPage(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<ErrorView>(new ErrorViewmodel(bootstrapperController));

            viewController.ViewCollection.ErrorPage = nameof(ErrorView);
        }

        public static void SetDefaultInstallSequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<FeatureView>(new FeatureViewmodel(bootstrapperController));
            viewController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            viewController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            viewController.ViewCollection.SetInstallSequence(new List<string>() { nameof(FeatureView), nameof(ProgressView), nameof(FinishView) });
        }

        public static void SetDefaultUninstallSequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            viewController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            viewController.ViewCollection.SetUninstallSequence(new List<string>() { "ProgressView", "FinishView" });
        }

        public static void SetDefaultUpgradeSequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<FeatureView>(new FeatureViewmodel(bootstrapperController));
            viewController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            viewController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            viewController.ViewCollection.SetUpgradeSequence(new List<string>() { "FeatureView", "ProgressView", "FinishView" });
        }

        public static void SetDefaultModifySequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<FeatureView>(new FeatureViewmodel(bootstrapperController));
            viewController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            viewController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            viewController.ViewCollection.SetModifySequence(new List<string>() { "FeatureView", "ProgressView", "FinishView" });
        }

        public static void SetDefaultRepairSequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            viewController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            viewController.ViewCollection.SetRepairSequence(new List<string>() { "ProgressView", "FinishView" });
        }

        public static void SetDefaultSequences(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            SetDefaultStartPage(viewController, bootstrapperController);
            SetDefaultCancelPage(viewController, bootstrapperController);
            SetDefaultErrorPage(viewController, bootstrapperController);

            SetDefaultInstallSequence(viewController, bootstrapperController);
            SetDefaultUninstallSequence(viewController, bootstrapperController);
            SetDefaultUpgradeSequence(viewController, bootstrapperController);
            SetDefaultModifySequence(viewController, bootstrapperController);
            SetDefaultRepairSequence(viewController, bootstrapperController);
        }
    }
}