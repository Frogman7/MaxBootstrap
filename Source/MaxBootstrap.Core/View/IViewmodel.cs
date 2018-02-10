namespace MaxBootstrap.Core.View
{
    public interface IViewmodel
    {
        IView View { get; set; }

        IBootstrapperController BootstrapperController { get; }

        void Activate();
    }
}
