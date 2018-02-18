using System.Windows.Input;

namespace MaxBootstrap.Core.View
{
    public class ButtonState : ObservableBase
    {
        protected string text;

        protected bool enabled;

        protected bool visible;

        protected ICommand command;

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

        public ICommand Command
        {
            get
            {
                return this.command;
            }

            set
            {
                this.command = value;
                this.NotifyPropertyChanged();
            }
        }

        public ButtonState(string text, bool enabled, bool visible)
        {
            this.text = text;
            this.enabled = enabled;
            this.visible = visible;
        }
    }
}
