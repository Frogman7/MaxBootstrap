namespace MaxBootstrap.UI.Views.Error
{
    using System.Windows.Controls;
    using Core.View;

    /// <summary>
    /// Interaction logic for ErrorView.xaml
    /// </summary>
    public partial class ErrorView : UserControl, IView
    {
        public ErrorView(IErrorViewmodel errorViewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = errorViewmodel;

            this.Viewmodel.Activate();
        }

        public IViewmodel Viewmodel
        {
            get
            {
                return (IViewmodel)this.DataContext;
            }

            set
            {
                this.DataContext = value;
            }
        }
    }
}
