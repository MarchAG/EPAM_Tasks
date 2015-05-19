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
using NODClassLibrary;
using System.Windows.Controls.DataVisualization.Charting;
namespace WpfApplicationTask3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
//          showColumnChart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<KeyValuePair<string, double>> valueList = new List<KeyValuePair<string, double>>();
            double runtime;
            NOD.Euclidean(Convert.ToInt32(Number1.Text), Convert.ToInt32(Number2.Text), out runtime);
            valueList.Add(new KeyValuePair<string, double>("Euclidean", runtime));
            NOD.Stain(Convert.ToInt32(Number1.Text), Convert.ToInt32(Number2.Text), out runtime);
            valueList.Add(new KeyValuePair<string, double>("Stain", runtime));
            showColumnChart(valueList);
        }
        private void showColumnChart(List<KeyValuePair<string, double>> list, Orient orient = Orient.vertical)
        {
            ColumnChart.DataContext = null;
            BarChart.DataContext = null;
            if (orient != Orient.vertical)
            {
                BarChart.Visibility = Visibility.Visible;
                BarChart.DataContext = list;
                BarChart.Style.Resources.Add(SystemColors.GradientActiveCaptionColor, new SolidColorBrush(Colors.Red));
                ColumnChart.Visibility = Visibility.Hidden;
            }
            else
            {
                ColumnChart.DataContext = list;
                Style columnStyleRed = new Style();
                columnStyleRed.BasedOn = this.Resources["CustomStyle"] as Style ;
                Setter setBackgroundRed = new Setter(ColumnSeries.HorizontalAlignmentProperty, new SolidColorBrush(Colors.Red));
                columnStyleRed.Setters.Add(setBackgroundRed);
                ColumnChart.PlotAreaStyle = columnStyleRed;
            }
        }
        private void Number2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Number1.Text != "" && Number2.Text != "")
                Ok.IsEnabled = true;
            else
                Ok.IsEnabled = false;
        }
        private void Number1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Number1.Text != "" && Number2.Text != "")
                Ok.IsEnabled = true;
            else
                Ok.IsEnabled = false;
        }
    }
}
