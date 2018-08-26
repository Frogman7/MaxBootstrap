using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Views.Cancel;
using MaxBootstrap.UI.Views.Commit;
using MaxBootstrap.UI.Views.Error;
using MaxBootstrap.UI.Views.Features;
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
            viewController.ViewCollection.RegisterView<WelcomeViewmodel>(new WelcomeViewmodel(bootstrapperController, new WelcomeView()));

            viewController.ViewCollection.StartPage = nameof(WelcomeViewmodel);
        }

        public static void SetDefaultCancelPage(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<CancelViewmodel>(new CancelViewmodel(bootstrapperController, new CancelView()));

            viewController.ViewCollection.CancelPage = nameof(CancelViewmodel);
        }

        public static void SetDefaultErrorPage(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<ErrorViewmodel>(new ErrorViewmodel(bootstrapperController, new ErrorView()));

            viewController.ViewCollection.ErrorPage = nameof(ErrorViewmodel);
        }

        public static void SetDefaultInstallSequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<FeaturesViewmodel>(new FeaturesViewmodel(bootstrapperController, new FeaturesView()));
            viewController.ViewCollection.RegisterView<CommitViewmodel>(new CommitViewmodel(bootstrapperController, new CommitView()));
            viewController.ViewCollection.RegisterView<ProgressViewmodel>(new ProgressViewmodel(bootstrapperController, new ProgressView()));
            viewController.ViewCollection.RegisterView<FinishViewmodel>(new FinishViewmodel(bootstrapperController, new FinishView()));

            viewController.ViewCollection.SetInstallSequence(new List<string>() { nameof(FeaturesViewmodel), nameof(CommitViewmodel), nameof(ProgressViewmodel), nameof(FinishViewmodel) });
        }

        public static void SetDefaultUninstallSequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<CommitViewmodel>(new CommitViewmodel(bootstrapperController, new CommitView()));
            viewController.ViewCollection.RegisterView<ProgressViewmodel>(new ProgressViewmodel(bootstrapperController, new ProgressView()));
            viewController.ViewCollection.RegisterView<FinishViewmodel>(new FinishViewmodel(bootstrapperController, new FinishView()));

            viewController.ViewCollection.SetUninstallSequence(new List<string>() { nameof(ProgressViewmodel), nameof(FinishViewmodel) });
        }

        public static void SetDefaultUpgradeSequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<FeaturesViewmodel>(new FeaturesViewmodel(bootstrapperController, new FeaturesView()));
            viewController.ViewCollection.RegisterView<CommitViewmodel>(new CommitViewmodel(bootstrapperController, new CommitView()));
            viewController.ViewCollection.RegisterView<ProgressViewmodel>(new ProgressViewmodel(bootstrapperController, new ProgressView()));
            viewController.ViewCollection.RegisterView<FinishViewmodel>(new FinishViewmodel(bootstrapperController, new FinishView()));

            viewController.ViewCollection.SetUpgradeSequence(new List<string>() { nameof(FeaturesViewmodel), nameof(CommitViewmodel), nameof(ProgressViewmodel), nameof(FinishViewmodel) });
        }

        public static void SetDefaultModifySequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<FeaturesViewmodel>(new FeaturesViewmodel(bootstrapperController, new FeaturesView()));
            viewController.ViewCollection.RegisterView<CommitViewmodel>(new CommitViewmodel(bootstrapperController, new CommitView()));
            viewController.ViewCollection.RegisterView<ProgressViewmodel>(new ProgressViewmodel(bootstrapperController, new ProgressView()));
            viewController.ViewCollection.RegisterView<FinishViewmodel>(new FinishViewmodel(bootstrapperController, new FinishView()));

            viewController.ViewCollection.SetModifySequence(new List<string>() { nameof(FeaturesViewmodel), nameof(CommitViewmodel), nameof(ProgressViewmodel), nameof(FinishViewmodel) });
        }

        public static void SetDefaultRepairSequence(this IViewController viewController, IBootstrapperController bootstrapperController)
        {
            viewController.ViewCollection.RegisterView<CommitViewmodel>(new CommitViewmodel(bootstrapperController, new CommitView()));
            viewController.ViewCollection.RegisterView<ProgressViewmodel>(new ProgressViewmodel(bootstrapperController, new ProgressView()));
            viewController.ViewCollection.RegisterView<FinishViewmodel>(new FinishViewmodel(bootstrapperController, new FinishView()));

            viewController.ViewCollection.SetRepairSequence(new List<string>() { nameof(ProgressViewmodel), nameof(FinishViewmodel) });
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