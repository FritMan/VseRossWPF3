using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            LoadStolbGraph();
            
        }

        private void LoadStolbGraph()
        {
            if(StolbGraph.Visibility == Visibility.Visible)
            {
                var today = DateTime.Today;

                var start = today.AddDays(-9);

                List<double> sales = new List<double>();



                var sales_db = Db.Sales.ToList();

                for (int i = 0; i < 10; i++)
                {
                    var date = start.AddDays(i);

                    double cost = 0;

                    foreach (var s in sales_db)
                    {
                        if (s.SaleDate.Date == date.Date)
                        {
                            cost += int.Parse(s.Quantity) * int.Parse(s.Product.Cost);
                        }
                    }

                    sales.Add(cost);

                }

                var series = new SeriesCollection()
            {
                new ColumnSeries {Values=new ChartValues<double> {} }
            };

                StolbGraph.Series = series;

                foreach (var el in sales)
                {
                    series[0].Values.Add(el);
                }

                List<string> labels = new List<string>();
                var culture = new CultureInfo("RU-ru");

                for (int i = 0; i < 10; i++)
                {
                    var date = start.AddDays(i);
                    string day = culture.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek);

                    day += "\n" + date.ToString("dd.MM");

                    labels.Add(day);
                }

                StolbGraph.AxisX.Add(new Axis { Labels = labels, Separator = new LiveCharts.Wpf.Separator { Step = 1 } });
            }
            else
            {
                var today = DateTime.Today;

                var start = today.AddDays(-9);
                
                List<double> sales = new List<double>();



                var sales_db = Db.Sales.ToList();

                for (int i = 0; i < 10; i++)
                {
                    var date = start.AddDays(i);

                    int colvo = 0;

                    foreach (var s in sales_db)
                    {
                        if (s.SaleDate.Date == date.Date)
                        {
                            colvo += int.Parse(s.Quantity);
                        }
                    }

                    sales.Add(colvo);

                }

                var series = new SeriesCollection()
                {
                    new ColumnSeries {Values=new ChartValues<double> {} }
                };

                QuatnSotlbGraph.Series = series;

                foreach (var el in sales)
                {
                    series[0].Values.Add(el);
                }

                List<string> labels = new List<string>();
                var culture = new CultureInfo("RU-ru");

                for (int i = 0; i < 10; i++)
                {
                    var date = start.AddDays(i);
                    string day = culture.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek);

                    day += "\n" + date.ToString("dd.MM");

                    labels.Add(day);
                }

                QuatnSotlbGraph.AxisX.Add(new Axis { Labels = labels, Separator = new LiveCharts.Wpf.Separator { Step = 1 } });
            }
            
        }

        private void CostBtn_Click(object sender, RoutedEventArgs e)
        {
            StolbGraph.Visibility = Visibility.Visible;
            QuatnSotlbGraph.Visibility = Visibility.Collapsed;
        }

        private void ColfoBtn_Click(object sender, RoutedEventArgs e)
        {
            StolbGraph.Visibility = Visibility.Collapsed;
            QuatnSotlbGraph.Visibility= Visibility.Visible;
        }
    }
}
