using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static SessionRoss3.Classes.Helper;

namespace SessionRoss3.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            MD5 md5 = MD5.Create();
            var pwd = md5.ComputeHash(Encoding.UTF8.GetBytes(PwdPb.Password));

            var _user = Db.User.First(el => el.Login == LogTb.Text && el.Password == pwd);

            if (_user != null)
            {
                AuthExp.DataContext = _user;
                AuthExp.Visibility = Visibility;
                NavigationService.Navigate(new MenuPage());
            }
        }
    }
}
