using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaxBootstrap.UI.Views
{
    public abstract class ViewmodelBase : IViewmodel, INotifyPropertyChanged
    {
        public ViewmodelBase(IBootstrapperController bootstrapperController, IView view)
        {
            this.BootstrapperController = bootstrapperController;

            this.View = view;

            this.View.Viewmodel = this;
        }

        public IView View { get; set; }

        public IBootstrapperController BootstrapperController { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnNavigatedTo()
        {
        }

        public virtual void OnNavigatedFrom()
        {
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
            {
                throw new System.ArgumentNullException(nameof(propertyName));
            }

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}