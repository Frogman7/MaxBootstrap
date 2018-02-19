namespace MaxBootstrap.UI.Views.Cancel
{
    using Core.View;

    /// <summary>
    /// Interaction logic for CancelView.xaml
    /// </summary>
    public partial class CancelView : IView
    {
        public CancelView(ICancelViewmodel viewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = viewmodel;

            this.Viewmodel.Activate();
        }

        public IViewmodel Viewmodel
        {
            get
            {
                return this.DataContext as IViewmodel;
            }

            set { this.DataContext = value; }
        }
    }
}
