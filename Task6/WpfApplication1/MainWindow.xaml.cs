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
using MyFIleReader;
using Microsoft.Win32;

namespace FileReadWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Reader reader;
        public MainWindow()
        {
            InitializeComponent();
            sliderPort.TickFrequency = 1;
            sliderPort.IsSnapToTickEnabled = true;
            scroll.IsEnabled = false;
            confirm.IsEnabled = false;
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void conf_Click(object sender, RoutedEventArgs e)
        {
        }
        private bool scrolledToTop = false;
        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (scrolledToTop == true)
            {
                scrolledToTop = false;
                return;
            }
            else if (e.OldValue < e.NewValue)
            {
                if ((int)e.NewValue - (int)e.OldValue  >= 1)
                {
                    for (int i = 0; i < (int)e.NewValue - (int)e.OldValue ; i++)
                    {
                        textFromFile.Text += reader.ReadNextPortion((int)sliderPort.Value);
                        if (100 - (int)sliderPort.Value*((int)scroll.Value - 1) < (int)sliderPort.Value)
                            percents.Text = "100%";
                        else
                            percents.Text = ((int)sliderPort.Value * (int)scroll.Value).ToString() + "%";
                    }
                    textFromFile.ScrollToEnd();
                }

            }      
            else
            {
                scrolledToTop = true;
                scroll.Value = e.OldValue;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            scroll.Maximum = (int)(100 / sliderPort.Value);
            if ((int)(100 / sliderPort.Value) != (double)(100 / sliderPort.Value))
                scroll.Maximum += 1;
            sliderPort.IsEnabled = false;
            scroll.IsEnabled = true;
        }

        private void sliderPort_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            valueOfPortions.Text = sliderPort.Value.ToString();
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                switch (ofd.FileName)
                {
                    case @"D:\Text1.txt":
                        reader = new Reader(ofd.FileName, "1234");
                        break;
                    case @"D:\Text2.txt":
                        reader = new Reader(ofd.FileName, "0000");
                        break;
                    case @"D:\text06.txt":
                        reader = new Reader(ofd.FileName, "0000");
                        break;
                    case @"D:\Text3.txt":
                        reader = new Reader(ofd.FileName, "7453");
                        break;
                    default:
                        MessageBox.Show("Выберите другой файл");
                        break;
                }
            }
        }

        private void checkPass_Click(object sender, RoutedEventArgs e)
        {
            if (reader != null)
                if (reader.IsCorrectPassword(passTextBox.Text))
                    confirm.IsEnabled = true;
                else
                {
                    MessageBox.Show("Пороль не подошел");
                    passTextBox.Text = "";
                }
        }

        private void pass_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
