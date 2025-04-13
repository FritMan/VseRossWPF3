using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
using static SessionRoss3.Classes.Helper;

namespace SessionRoss3.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage(int Block = 0)
        {
            InitializeComponent();

            if(Block == 1)
            {
                Blocked();
            }
        }

        public AuthPage()
        {
            InitializeComponent();
        }

        private void Blocked()
        {
            LogTb.IsEnabled = false;
            PwdPb.IsEnabled = false;
            OkBtn.IsEnabled = false;

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(20);

            dispatcherTimer.Tick += DispatcherTimer_Tick;

            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            LogTb.IsEnabled = true;
            PwdPb.IsEnabled = true;
            OkBtn.IsEnabled = true;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            MD5 md5 = MD5.Create();
            var pwd = md5.ComputeHash(Encoding.UTF8.GetBytes(PwdPb.Password));

            Regex PhoneRegex = new Regex(@"\+7\(\d\d\d\)\d\d\d-\d\d-\d\d");

            Regex MailRegex = new Regex(@"[^@]+@[^@]+");
            

            var _user = Db.User.First(el => el.Login == LogTb.Text && el.Password == pwd);

            if (_user != null )
            {
                AuthExp.DataContext = _user;
                AuthExp.Visibility = Visibility;
                NavigationService.Navigate(new MenuPage());
            }
            else if(_user != null && MailRegex.IsMatch(LogTb.Text))
            {
                AuthExp.DataContext = _user;
                AuthExp.Visibility = Visibility;
                NavigationService.Navigate(new MenuPage());
            }
            else
            {
                MessageBox.Show("Неправильный формат или логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void LogTb_GotFocus(object sender, RoutedEventArgs e)
        {
            PopupStack.PlacementTarget = LogTb;
            PopupStack.IsOpen = true;   
        }

        private void LogTb_LostFocus(object sender, RoutedEventArgs e)
        {
            PopupStack.IsOpen = false
                ;
        }
    }
}
