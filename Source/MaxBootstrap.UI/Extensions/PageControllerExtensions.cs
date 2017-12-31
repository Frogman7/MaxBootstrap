using MaxBootstrap.Core;
using MaxBootstrap.UI.Pages;
using System.Collections.Generic;

namespace MaxBootstrap.UI.Extensions
{
    public static class PageControllerExtensions
    {
        public static void SetDefaultStartPage(this IPageController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.PageCollection.RegisterPage<WelcomePage>(true, bootstrapperController);

            pageController.PageCollection.StartPage = "WelcomePage";
        }

        public static void SetDefaultCancelPage(this IPageController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.PageCollection.RegisterPage<CancelPage>(false, bootstrapperController);

            pageController.PageCollection.CancelPage = "CancelPage";
        }

        public static void SetDefaultErrorPage(this IPageController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.PageCollection.RegisterPage<ErrorPage>(false, bootstrapperController);

            pageController.PageCollection.ErrorPage = "ErrorPage";
        }

        public static void SetDefaultInstallSequence(this IPageController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.PageCollection.RegisterPage<FeaturePage>(false, bootstrapperController);
            pageController.PageCollection.RegisterPage<ProgressPage>(false, bootstrapperController);
            pageController.PageCollection.RegisterPage<FinishPage>(false, bootstrapperController);

            pageController.PageCollection.SetInstallSequence(new List<string>() { "FeaturePage", "ProgressPage", "FinishPage" });
        }

        public static void SetDefaultUninstallSequence(this IPageController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.PageCollection.RegisterPage<ProgressPage>(false, bootstrapperController);
            pageController.PageCollection.RegisterPage<FinishPage>(false, bootstrapperController);

            pageController.PageCollection.SetUninstallSequence(new List<string>() { "ProgressPage", "FinishPage" });
        }

        public static void SetDefaultUpgradeSequence(this IPageController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.PageCollection.RegisterPage<FeaturePage>(false, bootstrapperController);
            pageController.PageCollection.RegisterPage<ProgressPage>(false, bootstrapperController);
            pageController.PageCollection.RegisterPage<FinishPage>(false, bootstrapperController);

            pageController.PageCollection.SetUpgradeSequence(new List<string>() { "FeaturePage", "ProgressPage", "FinishPage" });
        }

        public static void SetDefaultModifySequence(this IPageController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.PageCollection.RegisterPage<FeaturePage>(false, bootstrapperController);
            pageController.PageCollection.RegisterPage<ProgressPage>(false, bootstrapperController);
            pageController.PageCollection.RegisterPage<FinishPage>(false, bootstrapperController);

            pageController.PageCollection.SetModifySequence(new List<string>() { "FeaturePage", "ProgressPage", "FinishPage" });
        }

        public static void SetDefaultRepairSequence(this IPageController pageController, IBootstrapperController bootstrapperController)
        {
            pageController.PageCollection.RegisterPage<ProgressPage>(false, bootstrapperController);
            pageController.PageCollection.RegisterPage<FinishPage>(false, bootstrapperController);

            pageController.PageCollection.SetRepairSequence(new List<string>() { "ProgressPage", "FinishPage" });
        }

        public static void SetDefaultSequences(this IPageController pageController, IBootstrapperController bootstrapperController)
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
