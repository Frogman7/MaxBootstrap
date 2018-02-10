using System.Windows.Controls;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Views
{
    /// <summary>
    /// Interaction logic for ProgressView.xaml
    /// </summary>
    public partial class ProgressView : IView
    {
        public ProgressView(IProgressViewmodel progressViewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = progressViewmodel;

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
