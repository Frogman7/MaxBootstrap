using MaxBootstrap.Core.View;
using System.Windows;

namespace MaxBootstrap.Core
{
    public interface IPage
    {
        FrameworkElement ViewContent { get; }

        bool CanNavigateTo { get; }

        bool ShouldSkip { get; }

        void OnNavigatedTo();

        void OnNavigatedFrom();
    }
}
