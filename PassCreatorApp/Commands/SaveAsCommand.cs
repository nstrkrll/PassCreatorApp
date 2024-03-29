﻿using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows;
using System.Windows.Input;
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
            try
            {
                if (!_vm.Photo.ToString().Contains("file:///"))
                {
                    throw new ArgumentException("Необходимо выбрать фотографию работника");
                }

                var passBaseImage = new BitmapImage(new Uri("pack://application:,,,/Resources/PassBase.png"));
                Bitmap passBase;
                using (MemoryStream outStream = new MemoryStream())
                {
                    var enc = new BmpBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create(passBaseImage));
                    enc.Save(outStream);
                    var bitmap = new Bitmap(outStream);
                    passBase = new Bitmap(bitmap);
                }

                var ResultBitmap = new Bitmap(passBase.Width, passBase.Height);
                var photo = new Bitmap(Bitmap.FromFile((_vm.Photo as BitmapImage).UriSource.LocalPath), 1181, 1575);
                var resizedPhoto = new Bitmap(1181, 1575);
                var graphics = Graphics.FromImage(resizedPhoto);
                graphics.InterpolationMode = InterpolationMode.High;
                graphics.CompositingMode = CompositingMode.SourceOver;
                var textFont = new Font("OpenSansBold", 110F, System.Drawing.FontStyle.Bold);
                var drawBrush = new SolidBrush(Color.Black);
                graphics.DrawImage(photo, 0, 0, 1181, 1575);
                graphics = Graphics.FromImage(ResultBitmap);
                graphics.DrawImage(passBase, 0, 0);
                graphics.DrawImage(resizedPhoto, 186, 197);
                graphics.DrawRectangle(new Pen(drawBrush), 185, 196, 1182, 1576);
                graphics.DrawString(_vm.LastName, textFont, drawBrush, 1420, 312);
                graphics.DrawString(_vm.FirstName, textFont, drawBrush, 1420, 484);
                graphics.DrawString(_vm.SecondName, textFont, drawBrush, 1420, 657);
                graphics.DrawString(_vm.Post, textFont, drawBrush, 1420, 966);
                textFont = new Font("OpenSansRegular", 85F, System.Drawing.FontStyle.Regular);
                if (_vm.IsEmployeeNumberSwitchedOn)
                {
                    graphics.DrawString("Таб.", textFont, drawBrush, 1420, 1478);
                    graphics.DrawString(_vm.EmployeeNumber, textFont, drawBrush, 1840, 1478);
                }

                graphics.DrawString("Проп.", textFont, drawBrush, 1420, 1603);
                graphics.DrawString(_vm.PassNumber, textFont, drawBrush, 1840, 1603);
                var sfd = new SaveFileDialog
                {
                    Filter = "Изображение|*.png"
                };
                if (sfd.ShowDialog() == true)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    ResultBitmap.Save(sfd.FileName);
                    MessageBox.Show("Пропуск сохранен!");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}