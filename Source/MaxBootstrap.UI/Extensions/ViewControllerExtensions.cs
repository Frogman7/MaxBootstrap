using MaxBootstrap.Core;
using MaxBootstrap.UI.Viewmodels.Concretes;
using MaxBootstrap.UI.Views;
using System.Collections.Generic;

namespace MaxBootstrap.UI.Extensions
{
    public static class ViewControllerExtensions
    {
        public static void SetDefaultStartPage(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.ViewCollection.RegisterView<WelcomeView>(new WelcomeViewmodel(bootstrapperController), true);

            pageController.ViewCollection.StartPage = "WelcomeView";
        }

        public static void SetDefaultCancelPage(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.ViewCollection.RegisterView<CancelView>(new CancelViewmodel(bootstrapperController));

            pageController.ViewCollection.CancelPage = "CancelView";
        }

        public static void SetDefaultErrorPage(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.ViewCollection.RegisterView<ErrorView>(new ErrorViewmodel(bootstrapperController));

            pageController.ViewCollection.ErrorPage = nameof(ErrorView);
        }

        public static void SetDefaultInstallSequence(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.ViewCollection.RegisterView<FeatureView>(new FeatureViewmodel(bootstrapperController));
            pageController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            pageController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            pageController.ViewCollection.SetInstallSequence(new List<string>() { nameof(FeatureView), nameof(ProgressView), nameof(FinishView) });
        }

        public static void SetDefaultUninstallSequence(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            pageController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            pageController.ViewCollection.SetUninstallSequence(new List<string>() { "ProgressView", "FinishView" });
        }

        public static void SetDefaultUpgradeSequence(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.ViewCollection.RegisterView<FeatureView>(new FeatureViewmodel(bootstrapperController));
            pageController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            pageController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            pageController.ViewCollection.SetUpgradeSequence(new List<string>() { "FeatureView", "ProgressView", "FinishView" });
        }

        public static void SetDefaultModifySequence(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.ViewCollection.RegisterView<FeatureView>(new FeatureViewmodel(bootstrapperController));
            pageController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            pageController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            pageController.ViewCollection.SetModifySequence(new List<string>() { "FeatureView", "ProgressView", "FinishView" });
        }

        public static void SetDefaultRepairSequence(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.ViewCollection.RegisterView<ProgressView>(new ProgressViewmodel(bootstrapperController));
            pageController.ViewCollection.RegisterView<FinishView>(new FinishViewmodel(bootstrapperController));

            pageController.ViewCollection.SetRepairSequence(new List<string>() { "ProgressView", "FinishView" });
        }

        public static void SetDefaultSequences(this IViewController pageController, IBootstrapperController bootstrapperController)
        {
            SetDefaultStartPage(pageController, bootstrapperController);
            SetDefaultCancelPage(pageController, bootstrapperController);
            SetDefaultErrorPage(pageController, bootstrapperController);

            SetDefaultInstallSequence(pageController, bootstrapperController);
            SetDefaultUninstallSequence(pageController, bootstrapperController);
            SetDefaultUpgradeSequence(pageController, bootstrapperController);
            SetDefaultModifySequence(pageController, bootstrapperController);
            SetDefaultRepairSequence(pageController, bootstrapperController);
        }
    }
}
