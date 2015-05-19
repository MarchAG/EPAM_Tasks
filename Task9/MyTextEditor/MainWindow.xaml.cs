using Microsoft.Win32;
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
using OptimizationStream;

namespace MyTextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyOptimization myOpt;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        OpenFileDialog ofd;
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                try
                {
                    myOpt = new MyOptimization(ofd.FileName);
                    textFile.Text = myOpt.MyReadAllFile();
                    textFile.ScrollToEnd();
                    textFile.TextChanged += textFile_TextChanged;
                }
                catch
                {
                    exceptionInfo.Text = "Ошибка открытия файла";
                }
            }
        }


        private void textFile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ofd != null)
            {
                using (myOpt = new MyOptimization(ofd.FileName))
                {
                    myOpt.Rewrite(e.Changes.First().Offset,
                        textFile.Text.Substring(e.Changes.First().Offset));
                }
            }
        }
    }
}
