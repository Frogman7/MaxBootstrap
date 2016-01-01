using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaxBootstrap.Core.Pages
{
    public abstract class PageBase : IPage
    {
        protected IBootstrapperController bootstrapperController;

        public  FrameworkElement ViewContent { get; private set; }

        public bool CanNavigateTo { get; protected set; }

        public bool ShouldSkip { get; protected set; }

        protected PageBase(FrameworkElement viewContent, IBootstrapperController bootstrapperController)
        {
            this.ViewContent = viewContent;
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
