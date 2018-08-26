using System;

namespace MaxBootstrap.Core.View
{
    public class ViewActivator
    {
        public Type ConcretePageType { get; protected set; }

        public bool MaintainInstance { get; set; }

        private IViewmodel viewmodelInstance;

        private IView view;

        private IBootstrapperController bootstrapperController;

        public ViewActivator(Type pageType, IView view, IBootstrapperController bootstrapperController, bool maintainInstance = false)
        {
            this.MaintainInstance = maintainInstance;

            if (pageType == null)
            {
                throw new ArgumentNullException(nameof(pageType));
            }
            else if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }
            else if (bootstrapperController == null)
            {
                throw new ArgumentNullException(nameof(bootstrapperController));
            }
            else if (pageType.IsInterface || pageType.IsAbstract)
            {
                throw new ArgumentException("Must be a concrete implementation", nameof(pageType));
            }
            else if (!typeof(IViewmodel).IsAssignableFrom(pageType))
            {
                throw new ArgumentException("Must implement " + nameof(IViewmodel), nameof(pageType));
            }
            else
            {
                this.ConcretePageType = pageType;
                this.view = view;
            }
        }

        public IViewmodel GetInstance()
        {
            if (this.MaintainInstance && this.viewmodelInstance != null)
            {
                return this.viewmodelInstance;
            }
             
            this.viewmodelInstance = Activator.CreateInstance(this.ConcretePageType, this.bootstrapperController, this.view) as IViewmodel;

            return this.viewmodelInstance;
        }
    }
}
