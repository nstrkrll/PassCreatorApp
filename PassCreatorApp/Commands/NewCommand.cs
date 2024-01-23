using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PassCreatorApp.Commands
{
    public class NewCommand : ICommand
    {
        private PassCreatorViewModel _vm;

        public NewCommand(PassCreatorViewModel vm)
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
            if (MessageBox.Show("Вы уверены, что хотите создать новый пропуск?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _vm.Photo = new BitmapImage(new Uri("/Resources/AvatarTemplate.png", UriKind.Relative));
                _vm.FirstName = "";
                _vm.SecondName = "";
                _vm.LastName = "";
                _vm.Post = "";
                _vm.EmployeeNumber = "№";
                _vm.PassNumber = "№";
            }
        }
    }
}
