using System.Windows.Input;

namespace MaxBootstrap.Core.Pages
{
    public class ButtonState : ObservableBase
    {
        protected string text;

        protected bool enabled;

        protected bool visible;

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }

            set
            {
                this.enabled = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool Visible
        {
            get
            {
                return this.visible;
            }

            set
            {
                this.visible = value;
                this.NotifyPropertyChanged();
            }
        }

        public ICommand Command { get; set; }

        public ButtonState(string text, bool enabled, bool visible)
        {
            this.text = text;
            this.enabled = enabled;
            this.visible = visible;
        }
    }
}
