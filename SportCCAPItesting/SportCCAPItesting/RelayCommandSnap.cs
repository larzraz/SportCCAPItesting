using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SportCCAPItesting
{
    public class RelayCommandSnap : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommandSnap(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommandSnap(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;


        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
