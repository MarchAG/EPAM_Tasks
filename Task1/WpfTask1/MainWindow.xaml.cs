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
using FormatForString;
using System.IO;
using Microsoft.Win32;

namespace WpfTask1
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

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            string[] str = Coordinates.Text.Split('\n');
            foreach (string elem in str)
                Result.Text += Formatting.Format(elem) + '\n';
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                Result.Text = Formatting.Format(File.Open(ofd.FileName, FileMode.Open));
            }
        }

        private void Coordinates_TextChanged(object sender, TextChangedEventArgs e)
        {
            Result.Text = "";
        }
    }
}
