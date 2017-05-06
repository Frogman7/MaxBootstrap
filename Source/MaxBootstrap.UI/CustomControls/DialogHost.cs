namespace MaxBootstrap.UI.CustomControls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    /// <summary>
    /// The dialog host.
    /// </summary>
    public class DialogHost : ContentControl
    {
        /// <summary>
        /// Contains the content of the dialog.
        /// </summary>
        protected ContentControl DialogContentControl;

        /// <summary>
        /// Contains the content of the host or main control.
        /// </summary>
        protected ContentControl HostContentControl;

        /// <summary>
        /// Gets or sets the host content.
        /// </summary>
        public UIElement HostContent
        {
            get { return (UIElement)this.GetValue(HostContentProperty); }
            set { this.SetValue(HostContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HostContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HostContentProperty =
            DependencyProperty.Register("HostContent", typeof(UIElement), typeof(DialogHost), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the dialog content.
        /// </summary>
        public UIElement DialogContent
        {
            get { return (UIElement)this.GetValue(DialogContentProperty); }
            set { this.SetValue(DialogContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DialogContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogContentProperty =
            DependencyProperty.Register("DialogContent", typeof(UIElement), typeof(DialogHost), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets a value indicating whether the dialog is showing.
        /// </summary>
        public bool DialogShowing
        {
            get { return (bool)this.GetValue(DialogShowingProperty); }
            set { this.SetValue(DialogShowingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DialogShowing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogShowingProperty =
            DependencyProperty.Register("DialogShowing", typeof(bool), typeof(DialogHost), new PropertyMetadata(false));

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogHost"/> class.
        /// </summary>
        public DialogHost()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The initialize component.
        /// </summary>
        private void InitializeComponent()
        {
            this.DialogContentControl = new ContentControl();
            this.HostContentControl = new ContentControl();

            // Setup Host Content Bindings
            var hostContentBinding = new Binding { Source = this, Path = new PropertyPath(nameof(this.HostContent)), Mode = BindingMode.OneWay };
            this.HostContentControl.SetBinding(ContentControl.ContentProperty, hostContentBinding);

            // Setup Dialog Content Bindings
            var dialogContentBinding = new Binding { Source = this, Path = new PropertyPath(nameof(this.DialogContent)), Mode = BindingMode.OneWay };
            this.DialogContentControl.SetBinding(ContentControl.ContentProperty, dialogContentBinding);

            // Dialog Visible Bindings
            var dialogVisibilityBinding = new Binding { Source = this, Path = new PropertyPath(nameof(this.DialogShowing)), Converter = new BooleanToVisibilityConverter(), Mode = BindingMode.OneWay };
            this.DialogContentControl.SetBinding(ContentControl.VisibilityProperty, dialogVisibilityBinding);

            var grid = new Grid();
            grid.Children.Add(this.HostContentControl);
            grid.Children.Add(this.DialogContentControl);
            this.Content = grid;
        }
    }
}

