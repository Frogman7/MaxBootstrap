using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MaxBootstrap.Core;
using MaxBootstrap.Core.Pages;
using MaxBootstrap.UI.Viewmodels.Concretes;
using MaxBootstrap.UI.Views;

namespace MaxBootstrap.UI.Pages
{
    public class ErrorPage : PageBase
    {
        protected ErrorView ErrorView;

        public ErrorPage(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.ErrorView = new ErrorView(new ErrorViewmodel(bootstrapperController));
        }

        public override FrameworkElement ViewContent
        {
            get { return this.ErrorView; }
        }
    }
}
