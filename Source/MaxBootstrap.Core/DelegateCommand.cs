using System;
using System.Windows.Input;

namespace MaxBootstrap.UI
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action execute;

        public void Execute(object parameter)
        {
            this.execute();
        }

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute)
                       : this(execute, null)
        {
        }

        public DelegateCommand(Action execute,
                       Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }

            return canExecute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
