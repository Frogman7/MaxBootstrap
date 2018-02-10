﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaxBootstrap.Core.View
{
    public abstract class ViewmodelBase : IViewmodel, INotifyPropertyChanged
    {
        public ViewmodelBase(IBootstrapperController bootstrapperController)
        {
            this.BootstrapperController = bootstrapperController;
        }

        public IView View { get; set; }

        public IBootstrapperController BootstrapperController { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Activate()
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