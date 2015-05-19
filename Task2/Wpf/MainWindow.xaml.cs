using MathCalculation;
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

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.TextBlock1.Text = Convert.ToString(MathCalculator.Root(Convert.ToDouble(this.TextBox1.Text), Convert.ToInt32(this.TextBox2.Text)));

            this.TextBlock2.Text = MathCalculator.ConvertToBin(Convert.ToUInt32(this.TextBox3.Text));
        }
    }
}
