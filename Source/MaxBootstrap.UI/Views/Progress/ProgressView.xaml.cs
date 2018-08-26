using MaxBootstrap.Core.View;
using System.Windows.Controls;

namespace MaxBootstrap.UI.Views.Progress
{
    /// <summary>
    /// Interaction logic for ProgressView.xaml
    /// </summary>
    public partial class ProgressView : UserControl, IView
    {
        public ProgressView()
        {
            this.InitializeComponent();
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
