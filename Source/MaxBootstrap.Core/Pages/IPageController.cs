using MaxBootstrap.Core.Enums;
using MaxBootstrap.Core.Pages;
using System;

namespace MaxBootstrap.Core
{
    public interface IPageController
    {
        event Action<Sequence> SequenceStarted;

        PageCollection PageCollection { get; }

        ButtonStateManager ButtonStateManager { get; }

        IPage CurrentPage { get; }

        void GoNext();

        void GoBack();

        void StartInstallSequence();

        void StartUninstallSequence();

        void StartUpgradeSequence();

        void StartModifySequence();

        void StartRepairSequence();

        void GoToErrorPage();

        void GoToCancelPage();
    }
}
