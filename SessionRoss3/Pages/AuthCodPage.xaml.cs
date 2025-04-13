using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SessionRoss3.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthCodPage.xaml
    /// </summary>
    public partial class AuthCodPage : Page
    {
        private int PagePhoneOrMail;
        private string code = "";
        private int count = 0;
        public AuthCodPage(int PhoneOrMail)
        {
            InitializeComponent();
            PagePhoneOrMail = PhoneOrMail;
            GenericCode();
        }

        private void GenericCode()
        {
            string symbols = "1234567890";
            string code = "";

            Random random = new Random();

            for (int i = 0; i < 9; i++)
            {
                int index = random.Next(0, symbols.Length);

                code += symbols[index];
            }

            string time = DateTime.Now.ToUniversalTime().ToString("u");

            string time_date = code + " - " + time;


            File.AppendAllText(System.IO.Path.GetTempPath() + "logs/password.txt", time_date);
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if(count != 3)
            {
                if (CodeTb.Text == code)
                {
                    NavigationService.Navigate(new MenuPage());
                }
                else
                {
                    MessageBox.Show("Неверный код", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    count++;
                }
            }
            else
            {
                NavigationService.Navigate(new AuthPage(1));
            }
        }
    }
}
