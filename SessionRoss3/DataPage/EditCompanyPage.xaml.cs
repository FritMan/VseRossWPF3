using SessionRoss3.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using static SessionRoss3.Classes.Helper;
namespace SessionRoss3.DataPage
{
    /// <summary>
    /// Логика взаимодействия для EditCompanyPage.xaml
    /// </summary>
    public partial class EditCompanyPage : Page
    {
        private int _Id;
        public EditCompanyPage(int Id)
        {
            InitializeComponent();
            _Id = Id;
            Db.Company.Load();
            CompanyCb.ItemsSource = Db.Company.ToList();

            if (_Id == -1)
            {
                var com = new Data.Company();
                com.CompanyId = 1;
                com.DateCreate = DateTime.Now.Date;
                com.Company2 = Db.Company.First(el => el.Id == com.CompanyId);

                CompanyGrid.DataContext = com;
            }
            else
            {
                CompanyGrid.DataContext = Db.Company.First(el => el.Id == _Id);
            }
        }

        private void AddCompanyBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_Id == -1)
                {
                    Db.Company.Add(CompanyGrid.DataContext as Company);
                }
                Db.SaveChanges();
                NavigationService.Navigate(new CompanyPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompanyPage());
        }
    }
}
