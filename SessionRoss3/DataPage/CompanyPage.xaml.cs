using Newtonsoft.Json;
using SessionRoss3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для CompanyPage.xaml
    /// </summary>
    public partial class CompanyPage : Page
    {
        private int PageCount = 1;
        private int PageZap;
        private int count = 0;

        public CompanyPage()
        {
            InitializeComponent();
            ZapCbLoad();
        }

        private void ZapCbLoad()
        {
            ZapCb.Items.Add(1);
            ZapCb.Items.Add(5);
            ZapCb.Items.Add(10);
            ZapCb.Items.Add("Все");

            ZapCb.SelectedIndex = 0;
        }

        private void LoadData()
        {
            
            if(ZapCb.SelectedIndex == 3)
            {
                if (string.IsNullOrEmpty(SearchTb.Text))
                {
                    companyDataGrid.ItemsSource = Db.Company.ToList();
                    companyListView.ItemsSource = Db.Company.ToList();

                    count = Db.Company.Count();
                }
                else
                {
                    companyDataGrid.ItemsSource = Db.Company.ToList().Where(el => el.Name.Contains(SearchTb.Text));
                    companyListView.ItemsSource = Db.Company.ToList().Where(el => el.Name.Contains(SearchTb.Text));
                    count = Db.Company.Where(el => el.Name.Contains(SearchTb.Text)).Count();
                }

                CountLabel.Content = $"Записи с {count - (count - 1)} до {count} из {count}";
            }
            else
            {
                if (string.IsNullOrEmpty(SearchTb.Text))
                {
                    companyDataGrid.ItemsSource = Db.Company.ToList().Skip((PageCount - 1) * PageZap).Take(PageZap);
                    companyListView.ItemsSource = Db.Company.ToList().Skip((PageCount - 1) * PageZap).Take(PageZap);

                    count = Db.Company.Count();
                }
                else
                {
                    companyDataGrid.ItemsSource = Db.Company.ToList().Where(el => el.Name.Contains(SearchTb.Text)).Skip((PageCount - 1) * PageZap).Take(PageZap);
                    companyListView.ItemsSource = Db.Company.ToList().Where(el => el.Name.Contains(SearchTb.Text)).Skip((PageCount - 1) * PageZap).Take(PageZap);
                    count = Db.Company.Where(el => el.Name.Contains(SearchTb.Text)).Count();
                }

                CountLabel.Content = $"Записи с {((PageCount - 1) * PageZap) + 1} до {Math.Min(count, PageZap * PageCount)} из {count}";
            }

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            PageCount = 1;
            LoadData();
        }

        private void ZapCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ZapCb.SelectedIndex != 3)
            {
                PageZap = (int)ZapCb.SelectedValue;
            }
            PageCount = 1;
            LoadData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(new EditCompanyPage(-1));
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            List<NewCompany> items = new List<NewCompany>();

            if (string.IsNullOrEmpty(SearchTb.Text))
            {
                foreach (var item in Db.Company.ToList())
                {
                    var el = new NewCompany();
                    el.Name = item.Name;
                    if (item.Company2 != null)
                    {
                        el.CompanyName = item.Company2.Name;
                    }
                    el.Address = item.Adress;
                    el.Contacts = item.Contacts;
                    el.Date = item.DateCreate.ToString("d");

                    items.Add(el);
                }
            }
            else
            {
                foreach (var item in Db.Company.Where(el => el.Name.Contains(SearchTb.Text)).ToList())
                {
                    var el = new NewCompany();
                    el.Name = item.Name;
                    if (item.Company2 != null)
                    {
                        el.CompanyName = item.Company2.Name;
                    }
                    el.Address = item.Adress;
                    el.Contacts = item.Contacts;
                    el.Date = item.DateCreate.ToString("d");

                    items.Add(el);
                }
            }
         

            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document";
            dialog.DefaultExt = ".json";
            dialog.Filter = "JSON Documents (.json) | *.json";


            var result = dialog.ShowDialog();

            if (result == true)
            {
                var filename = dialog.FileName;
                string stringitems = JsonConvert.SerializeObject(items, Formatting.Indented);
                File.WriteAllText(filename, stringitems);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(PageCount > 1)
            {
                PageCount--;
                LoadData();
            }
        }

        private void TurnBtn_Click(object sender, RoutedEventArgs e)
        {
            if(PageCount * PageZap < count)
            {
                PageCount++;
                LoadData();
            }
        }

        private void TableImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TileImg.Source = BitmapFrame.Create(new Uri(@"C:\Users\Ансар\source\repos\SessionRoss3\SessionRoss3\Assets\free-icon-tile-875161.png"));
            TableImg.Source = BitmapFrame.Create(new Uri(@"C:\Users\Ансар\source\repos\SessionRoss3\SessionRoss3\Assets\free-icon-table-grid-25617_gol.png"));
            companyListView.Visibility = Visibility.Collapsed;
            companyDataGrid.Visibility = Visibility.Visible;
        }

        private void TileImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
           TileImg.Source = BitmapFrame.Create(new Uri(@"C:\Users\Ансар\source\repos\SessionRoss3\SessionRoss3\Assets\free-icon-tile-875161_gol.png"));
            TableImg.Source = BitmapFrame.Create(new Uri(@"C:\Users\Ансар\source\repos\SessionRoss3\SessionRoss3\Assets\free-icon-table-grid-25617.png"));
            companyListView.Visibility = Visibility.Visible;
            companyDataGrid.Visibility = Visibility.Collapsed;
        }

        private void EditImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(companyListView.Visibility == Visibility.Visible)
            {
                NavigationService.Navigate(new EditCompanyPage((companyListView.SelectedItem as Company).Id));
            }
            else
            {
                NavigationService.Navigate(new EditCompanyPage((companyDataGrid.SelectedItem as Company).Id));
            }
        }

        private void DeleteImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (companyListView.Visibility == Visibility.Visible)
            {
                Db.Company.Remove(companyListView.SelectedItem as Company);
            }
            else
            {
                Db.Company.Remove(companyDataGrid.SelectedItem as Company);
            }
            Db.SaveChanges();
            LoadData();
        }
    }
    public class NewCompany
    {
        public string Name;
        public string Address;
        public string CompanyName;
        public string Date;
        public string Contacts;
    }
}
