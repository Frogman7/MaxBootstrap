namespace MaxBootstrap.Core.Pages
{
    using System.Windows;
    using View;

    public abstract class ViewBase : IPage
    {
        protected IBootstrapperController bootstrapperController;

        public abstract FrameworkElement ViewContent { get; }

        public bool CanNavigateTo { get; protected set; }

        public bool ShouldSkip { get; protected set; }

        protected ViewBase(IBootstrapperController bootstrapperController)
        {
            this.bootstrapperController = bootstrapperController;

            this.CanNavigateTo = true;
            this.ShouldSkip = false;
        }

        public virtual void OnNavigatedFrom()
        {
        }

        public virtual void OnNavigatedTo()
        {
        }
    }
}
