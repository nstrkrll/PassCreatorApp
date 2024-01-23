using System.Windows;

namespace PassCreatorApp
{
    public partial class PassCreator : Window
    {
        public PassCreator()
        {
            InitializeComponent();
            DataContext = new PassCreatorViewModel();
        }
    }
}
