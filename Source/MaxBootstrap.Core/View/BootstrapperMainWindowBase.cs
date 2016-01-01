using System;
using System.Windows;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.Core
{
    public abstract class BootstrapperMainWindowBase : Window, IBootstrapperMainWindow
    {
        public IBootstrapperMainWindowViewmodel Viewmodel
        {
            get
            {
                return (IBootstrapperMainWindowViewmodel)this.DataContext;
            }

            protected set
            {
                this.DataContext = value;
            }
        }
    }
}
