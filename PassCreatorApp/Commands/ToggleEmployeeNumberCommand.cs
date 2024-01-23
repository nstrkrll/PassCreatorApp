using System;
using System.Windows.Input;

namespace PassCreatorApp.Commands
{
    public class ToggleEmployeeNumberCommand : ICommand
    {
        private PassCreatorViewModel _vm;

        public ToggleEmployeeNumberCommand(PassCreatorViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object? parameter)
        {
            _vm.IsEmployeeNumberSwitchedOn = !_vm.IsEmployeeNumberSwitchedOn;
        }
    }
}
