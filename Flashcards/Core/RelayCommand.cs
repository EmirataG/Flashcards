
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Flashcards.Core
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canEcexute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canEcexute = null)
        {
            _execute = execute;
            _canEcexute = canEcexute;
        }

        public bool CanExecute(object parameter)
        {
            return _canEcexute == null || _canEcexute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
