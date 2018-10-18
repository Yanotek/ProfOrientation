using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProfTests.Other
{
    public class SimpleCommand : ICommand
    {
        public SimpleCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _ExecuteEvent += execute;
            _CanExecuteEvent += canExecute ?? ((obj) => true);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecuteEvent.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _ExecuteEvent.Invoke(parameter);
        }

        event Action<object> _ExecuteEvent;
        event Func<object, bool> _CanExecuteEvent;
    }
}
