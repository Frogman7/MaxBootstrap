using MaxBootstrap.Core.Enums;
using System;

namespace MaxBootstrap.Core.View
{
    public interface IViewController
    {
        event Action<Sequence> SequenceStarted;

        event Action<IViewmodel> ViewChange;

        ViewCollection ViewCollection { get; }

        ButtonStateManager ButtonStateManager { get; }

        IViewmodel CurrentViewmodel { get; }

        void GoNext();

        void GoBack();

        void StartInstallSequence();

        void StartUninstallSequence();

        void StartUpgradeSequence();

        void StartModifySequence();

        void StartRepairSequence();

        void GoToErrorView();

        void GoToCancelView();

        void InstallStageChange(InstallerStage installStage);
    }
}
