namespace MaxBootstrap.UI.Views
{
    using System.Windows.Controls;
    using Core.View;
    using Viewmodels.Interfaces;

    /// <summary>
    /// Interaction logic for CancelView.xaml
    /// </summary>
    public partial class CancelView : UserControl, IView
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
