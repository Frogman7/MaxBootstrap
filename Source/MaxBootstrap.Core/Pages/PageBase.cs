namespace MaxBootstrap.Core.Pages
{
    using System.Windows;
    using View;

    public abstract class PageBase : IPage
    {
        protected IBootstrapperController bootstrapperController;

        public abstract FrameworkElement ViewContent { get; }

        public bool CanNavigateTo { get; protected set; }

        public bool ShouldSkip { get; protected set; }

        protected PageBase(IBootstrapperController bootstrapperController)
        {
            this.bootstrapperController = bootstrapperController;

            this.CanNavigateTo = true;
            this.ShouldSkip = false;
        }

        public void OnNavigatedFrom()
        {
        }

        public void OnNavigatedTo()
        {
        }
    }
}
