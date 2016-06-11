using MaxBootstrap.Core.Pages;

namespace MaxBootstrap.Core
{
    public interface IPageController
    {
        PageCollection PageCollection { get; }

        ButtonStateManager ButtonStateManager { get; }

        IPage CurrentPage { get; }

        void GoNext();

        void GoBack();

        void StartInstallSequence();

        void StartUpgradeSequence();

        void StartModifySequence();

        void StartRepairSequence();

        void GoToErrorPage();

        void GoToCancelPage();
    }
}
