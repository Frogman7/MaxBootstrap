﻿namespace MaxBootstrap.UI.Views.Feature
{
    using System.Windows.Controls;

    using MaxBootstrap.Core.View;

    /// <summary>
    /// Interaction logic for FeatureView.xaml
    /// </summary>
    public partial class FeatureView : UserControl, IView
    {
        public FeatureView(IFeatureViewmodel featureViewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = featureViewmodel;

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