using Clock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ShowTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer t = new Timer();
        public MainWindow()
        {
            InitializeComponent();
            
            t.Tick += (object sender, ProgressEventArgs e) =>
                {
                    showTimer.Text = e.Current.ToString();
                };
            t.Complete += delegate(object sender, OnCompletEventArgs e)
                {
                    if (e.Condition == true)
                        MessageBox.Show("Error");
                    else
                        MessageBox.Show("Done");
                };
        }

        private void seconds_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void run_Click(object sender, RoutedEventArgs e)
        {
            t.Start(Convert.ToInt32(seconds.Text));
        }

        private void stopTimer_Click(object sender, RoutedEventArgs e)
        {
            t.Stop();
        }
    }
}
