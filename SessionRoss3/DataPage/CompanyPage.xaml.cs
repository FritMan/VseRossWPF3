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

            ZapCb.SelectedIndex = 0;
        }

        private void LoadData()
        {
            int count;
            if (string.IsNullOrEmpty(SearchTb.Text))
            {
                companyDataGrid.ItemsSource = Db.Company.ToList().Skip(PageZap * (PageCount - 1)).Take(PageZap);
                companyListView.ItemsSource = Db.Company.ToList().Skip(PageZap * (PageCount - 1)).Take(PageZap);
                count = Db.Company.Count();
            }
            else
            {
                companyDataGrid.ItemsSource = Db.Company.ToList().Where(el => el.Name.Contains(SearchTb.Text)).Skip(PageZap * (PageCount - 1)).Take(PageZap);
                companyListView.ItemsSource = Db.Company.ToList().Where(el => el.Name.Contains(SearchTb.Text)).Skip(PageZap * (PageCount - 1)).Take(PageZap);
                count = Db.Company.Where(el => el.Name.Contains(SearchTb.Text)).Count();
            }

            CountLabel.Content = $"Записи с {(PageZap * (PageCount - 1)) + 1} до {Math.Min(count, PageZap * PageCount)} из {count}";
            TopCountLabel.Content = $"Всего найдено {count} шт";
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            PageCount = 1;
            LoadData();
        }

        private void ZapCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PageZap = (int)ZapCb.SelectedValue;
            PageCount = 1;
            LoadData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            var data = "Названние;Вышестоящая;Адрес;Контакты;В работе с" + "\n";

            foreach(var el in Db.Company.ToList())
            {
                var com = el.Company2;

                if(com == null)
                {
                    data += el.Name + ";" + "Отсутсвует" + ";" + el.Adress + ";" + el.Contacts + ";" + el.DateCreate + "\n";
                }
                else
                {
                    data += el.Name + ";" + el.Company2.Name + ";" + el.Adress + ";" + el.Contacts + ";" + el.DateCreate + "\n";
                }
            }

            var dialog = new Microsoft.Win32.SaveFileDialog();

            dialog.FileName = "Document";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "CSV Doucuments(.csv) | *.csv";

            var result = dialog.ShowDialog();

            if (result == true)
            {
                var filename = dialog.FileName;
                File.WriteAllText(filename, data);
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
            if(PageCount * PageZap < Db.Company.Count())
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

        }

        private void DeleteImg_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
