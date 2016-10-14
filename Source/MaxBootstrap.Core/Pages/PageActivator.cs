using System;

namespace MaxBootstrap.Core.Pages
{
    public class PageActivator
    {
        public Type ConcretePageType { get; protected set; }

        public bool MaintainInstance { get; set; }

        private readonly object[] parameters;

        private IPage instance;

        public PageActivator(Type pageType, params object[] parameters) : this(pageType, false, parameters)
        {
        }

        public PageActivator(Type pageType, bool maintainInstance = false, params object[] parameters)
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
            else if (!typeof(IPage).IsAssignableFrom(pageType))
            {
                // TODO Throw must inherit from IPage
            }
            else
            {
                this.ConcretePageType = pageType;
                this.parameters = parameters;
            }
        }

        public IPage GetInstance()
        {
            if (this.MaintainInstance && this.instance != null)
            {
                return this.instance;
            }
             
            this.instance = Activator.CreateInstance(this.ConcretePageType, this.parameters) as IPage;

            return this.instance;
        }
    }
}
