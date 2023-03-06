using PassCreatorApp.Commands;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PassCreatorApp
{
    public class PassCreatorViewModel : INotifyPropertyChanged
    {
        private ImageSource _photo;
        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _post;
        private string _employeeNumber;
        private string _passNumber;
        private string _error;
        private bool _isError;
        public ICommand NewPassCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand HelpСommand { get; }
        public ICommand GetImageCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ImageSource Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                IsError = false;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                IsError = false;
                OnPropertyChanged();
            }
        }

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                IsError = false;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                IsError = false;
                OnPropertyChanged();
            }
        }

        public string Post
        {
            get { return _post; }
            set
            {
                _post = value;
                IsError = false;
                OnPropertyChanged();
            }
        }

        public string EmployeeNumber
        {
            get { return _employeeNumber; }
            set
            {
                _employeeNumber = value;
                IsError = false;
                OnPropertyChanged();
            }
        }

        public string PassNumber
        {
            get { return _passNumber; }
            set
            {
                _passNumber = value;
                IsError = false;
                OnPropertyChanged();
            }
        }

        public bool IsError
        {
            get { return _isError; }
            set
            {
                _isError = value;
                OnPropertyChanged();
                if (IsError)
                {
                    OnPropertyChanged(nameof(DisplayMessage));
                }
            }
        }

        public string DisplayMessage
        {
            get { return _error; }
        }

        public PassCreatorViewModel()
        {
            Photo = new BitmapImage(new Uri("/Resources/AvatarTemplate.png", UriKind.Relative));
            NewPassCommand = new NewCommand();
            SaveAsCommand = new SaveAsCommand(this);
            HelpСommand = new HelpCommand();
            GetImageCommand = new GetImageCommand(this);
            EmployeeNumber = "№";
            PassNumber = "№";
        }

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
