using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gofroychetqq
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _currentUser;
        public MainWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            if (_currentUser != null && _currentUser.Role != null)
            {
                UserInfoText.Text = $"Пользователь: {_currentUser.Surname} {_currentUser.Name} {_currentUser.Patronymic} | Роль: {_currentUser.Role.Name}";
            }
            else if (_currentUser != null)
            {
                UserInfoText.Text = $"Пользователь: {_currentUser.Surname} {_currentUser.Name} {_currentUser.Patronymic}";
            }
            // Загрузка фото
            if (_currentUser != null && !string.IsNullOrEmpty(_currentUser.Photo))
            {
                try
                {
                    var image = new BitmapImage(new Uri(_currentUser.Photo, UriKind.RelativeOrAbsolute));
                    UserPhoto.Source = image;
                }
                catch
                {
                    UserPhoto.Source = null;
                }
            }
            else
            {
                UserPhoto.Source = null;
            }
        }
        public MainWindow() : this(null) { }
    }
}
