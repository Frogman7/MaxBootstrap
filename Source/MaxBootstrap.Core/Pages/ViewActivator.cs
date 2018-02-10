using MaxBootstrap.Core.View;
using System;

namespace MaxBootstrap.Core.Pages
{
    public class ViewActivator
    {
        public Type ConcretePageType { get; protected set; }

        public bool MaintainInstance { get; set; }

        private readonly IViewmodel viewmodel;

        private IView instance;

        public ViewActivator(Type pageType, IViewmodel viewmodel, bool maintainInstance = false)
        {
            this.MaintainInstance = maintainInstance;

            if (pageType.IsInterface)
            {
                // TODO Throw is interface exception
            }
            else if (pageType.IsAbstract)
            {
                // TODO Throw is abstract exception
            }
            else if (!typeof(IView).IsAssignableFrom(pageType))
            {
                // TODO Throw must inherit from IPage
            }
            else
            {
                this.ConcretePageType = pageType;
                this.viewmodel = viewmodel;
            }
        }

        public IView GetInstance()
        {
            if (this.MaintainInstance && this.instance != null)
            {
                return this.instance;
            }
             
            this.instance = Activator.CreateInstance(this.ConcretePageType, this.viewmodel) as IView;

            return this.instance;
        }
    }
}
