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
        public ICommand NewPassCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand GetImageCommand { get; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public ImageSource Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Post
        {
            get { return _post; }
            set
            {
                _post = value;
                OnPropertyChanged();
            }
        }

        public string EmployeeNumber
        {
            get { return _employeeNumber; }
            set
            {
                _employeeNumber = value;
                if (_employeeNumber[0] != '№')
                {
                    _employeeNumber = string.Concat("№", _employeeNumber.AsSpan(0,4));
                }

                OnPropertyChanged();
            }
        }

        public string PassNumber
        {
            get { return _passNumber; }
            set
            {
                _passNumber = value;
                if (_passNumber[0] != '№')
                {
                    _passNumber = string.Concat("№", _passNumber.AsSpan(0, 4));
                }

                OnPropertyChanged();
            }
        }

        public PassCreatorViewModel()
        {
            Photo = new BitmapImage(new Uri("/Resources/AvatarTemplate.png", UriKind.Relative));
            NewPassCommand = new NewCommand(this);
            SaveAsCommand = new SaveAsCommand(this);
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
