using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PassCreatorApp.Commands
{
    public class GetImageCommand : ICommand
    {
        private PassCreatorViewModel _vm;

        public GetImageCommand(PassCreatorViewModel vm)
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
            var fileDialog = new OpenFileDialog
            {
                Title = "Выберите фото",
                Filter = "Фото 3х4|*.png"
            };
            if (fileDialog.ShowDialog() == true)
            {
                _vm.Photo = new BitmapImage(new Uri(fileDialog.FileName));
                //MessageBox.Show(@"..\..\..\Resources\PassBase.png");
            }
        }
    }
}
