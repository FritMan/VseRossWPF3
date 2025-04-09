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

namespace SessionRoss3.DataPage
{
    /// <summary>
    /// Логика взаимодействия для CompanyPage.xaml
    /// </summary>
    public partial class CompanyPage : Page
    {
        public CompanyPage()
        {
            InitializeComponent();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ZapCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TurnBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TableImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TileImg.Source = BitmapFrame.Create(new Uri(@"C:\Users\Ансар\source\repos\SessionRoss3\SessionRoss3\Assets\free-icon-tile-875161.png"));
            TableImg.Source = BitmapFrame.Create(new Uri(@"C:\Users\Ансар\source\repos\SessionRoss3\SessionRoss3\Assets\free-icon-table-grid-25617_gol.png"));
        }

        private void TileImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
           TileImg.Source = BitmapFrame.Create(new Uri(@"C:\Users\Ансар\source\repos\SessionRoss3\SessionRoss3\Assets\free-icon-tile-875161_gol.png"));
            TableImg.Source = BitmapFrame.Create(new Uri(@"C:\Users\Ансар\source\repos\SessionRoss3\SessionRoss3\Assets\free-icon-table-grid-25617.png"));
        }
    }
}
