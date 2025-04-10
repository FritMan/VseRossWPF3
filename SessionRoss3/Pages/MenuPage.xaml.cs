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

namespace SessionRoss3.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            TopLabel.Content = "Главная";
            MenuFrame.Content = new DataPage.MainPage();
        }

        private void CompanyLab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TopLabel.Content = "Администрирование / Компании";
            MenuFrame.Content = new DataPage.CompanyPage();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TopLabel.Content = "Главная";
            MenuFrame.Content = new DataPage.MainPage();
        }
    }
}
