using LiveCharts;
using LiveCharts.Wpf;
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
using static SessionRoss3.Classes.Helper;

namespace SessionRoss3.DataPage
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var series = new SeriesCollection()
            {
                new PieSeries { Values = new ChartValues<int> {Db.Vending.Where(el => el.StatusId == 2).Count()}, Fill = Brushes.Red, Title = "Не работают" },
                new PieSeries { Values = new ChartValues<int> {Db.Vending.Where(el => el.StatusId == 1).Count()}, Fill = Brushes.Blue, Title = "Работают" },
                new PieSeries { Values = new ChartValues<int> {Db.Vending.Where(el => el.StatusId == 3).Count()}, Fill = Brushes.Green, Title = "Обслуживаются" }
            };

            StateGraph.Series = series;
            var procent = ((double)Db.Vending.Where(el => el.StatusId == 1).Count() / (double)Db.Vending.Count()) * 100;
            NetworkGraph.Value = procent;

            EffLab.Content = $"Работающих автоматов - {Math.Ceiling(procent)}%";
            NewsList.ItemsSource = Db.News.ToList();
            
        }
    }
}
