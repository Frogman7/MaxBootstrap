using MaxBootstrap.Core.Enums;
using MaxBootstrap.Core.Pages;
using MaxBootstrap.Core.View;
using System;

namespace MaxBootstrap.Core
{
    public interface IViewController
    {
        event Action<Sequence> SequenceStarted;

        event Action<IView> ViewChange;

        ViewCollection ViewCollection { get; }

        ButtonStateManager ButtonStateManager { get; }

        IView CurrentView { get; }

        void GoNext();

        void GoBack();

        void StartInstallSequence();

        void StartUninstallSequence();

        void StartUpgradeSequence();

        void StartModifySequence();

        void StartRepairSequence();

        void GoToErrorView();

        void GoToCancelView();
    }
}
