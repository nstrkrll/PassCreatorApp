using System;
using System.Drawing;
using System.IO;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PassCreatorApp.Commands
{
    public class SaveAsCommand : ICommand
    {
        private PassCreatorViewModel _vm;

        public SaveAsCommand(PassCreatorViewModel vm)
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
            var passBase = new Bitmap(Bitmap.FromFile(@"..\..\..\Resources\PassBase.png"));
            var photo = new Bitmap(Bitmap.FromFile((_vm.Photo as BitmapImage).UriSource.LocalPath));
            var resizedPhoto = new Bitmap(1182, 1577);
            var graphics = Graphics.FromImage(resizedPhoto);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            graphics.DrawImage(photo, 0, 0, 1182, 1577);
            var ResultBitmap = new Bitmap(passBase.Width, passBase.Height);
            graphics = Graphics.FromImage(ResultBitmap);
            graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            graphics.DrawImage(passBase, 0, 0);
            graphics.DrawImage(resizedPhoto, 120, 197);
            var textFont = new Font("Open Sans", 10);
            var drawBrush = new SolidBrush(System.Drawing.Color.Black);
            graphics.DrawString(_vm.LastName, textFont, drawBrush, 1420, 312);
            graphics.DrawString(_vm.FirstName, textFont, drawBrush, 1420, 484);
            graphics.DrawString(_vm.SecondName, textFont, drawBrush, 1420, 657);
            graphics.DrawString(_vm.Post, textFont, drawBrush, 1420, 966);
            graphics.DrawString(_vm.EmployeeNumber, textFont, drawBrush, 1840, 1478);
            graphics.DrawString(_vm.PassNumber, textFont, drawBrush, 1840, 1603);
            ResultBitmap.Save("img.png");
        }
    }
}