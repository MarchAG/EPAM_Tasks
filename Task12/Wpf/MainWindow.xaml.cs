using BinaryTree;
using QueriesForTreeOfStudents;
using Students;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Xml.Serialization;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Tree<Student> stds = new Tree<Student>();
        public MainWindow()
        {
            InitializeComponent();

            MoreLess.Items.Add(">=");
            MoreLess.Items.Add(">");
            MoreLess.Items.Add("<=");
            MoreLess.Items.Add("<");
            MoreLess.SelectedIndex = 0;

            //List<Test> tests1 = new List<Test>()
            //    {
            //        new Test("test1",5),
            //        new Test("test2",6)
            //    };
            //List<Test> tests2 = new List<Test>()
            //    {
            //        new Test("test1",5),
            //        new Test("test2",2)
            //    };
            //List<Test> tests3 = new List<Test>()
            //    {
            //        new Test("test1",5),
            //        new Test("test2",4)
            //    };
            //List<Test> tests4 = new List<Test>()
            //{
            //        new Test("test1",8),
            //        new Test("test2",6)
            //    };
            //List<Test> tests5 = new List<Test>()
            //    {
            //        new Test("test1",7),
            //        new Test("test2",6)
            //    };

            //Student stud1 = new Student("Ivanov", tests1);
            //Student stud2 = new Student("Petrov", tests2);
            //Student stud3 = new Student("Sidorov", tests3);
            //Student stud4 = new Student("Stakov", tests4);
            //Student stud5 = new Student("Sivcev", tests5);

            //stds.Add(stud1);
            //stds.Add(stud2);
            //stds.Add(stud3);
            //stds.Add(stud4);
            //stds.Add(stud5);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(@"d:\serial.txt", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, stds);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            //Apply.IsEnabled = true;
            using (FileStream fs = new FileStream(@"d:\serial.txt", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                stds = (Tree<Student>)formatter.Deserialize(fs);
            }

        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            //IEnumerable<Student> linqStud = stds.OrderBy(student => student);
            IQueryable<Student> queryStud = stds.AsQueryable<Student>().Select(Students => Students);
            if(CheckWhere.IsChecked == true)
                queryStud = QueriesForStudents.WhereForTree(queryStud, MoreLess.SelectedItem.ToString(), Convert.ToDouble(Condition.Text));
            if (CheckOrder.IsChecked == true)
                queryStud = QueriesForStudents.OrderForTree(queryStud, Desc.IsChecked);
            if (CheckTake.IsChecked == true)
                queryStud = QueriesForStudents.TakeFromTree(queryStud, Convert.ToInt32(Numb.Text));
            foreach (Student student in queryStud)
                MessageBox.Show(((double)student).ToString());
        }

        private void CheckTake_Click(object sender, RoutedEventArgs e)
        {
            if (CheckTake.IsChecked == true)
                Numb.IsEnabled = true;
            else
                Numb.IsEnabled = false;
        }

        private void CheckOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CheckOrder.IsChecked == true)
            {
                Desc.IsEnabled = true;
            }
            else
                Desc.IsEnabled = false;
        }

        private void CheckWhere_Click(object sender, RoutedEventArgs e)
        {
            if (CheckWhere.IsChecked == true)
            {
                Condition.IsEnabled = true;
                MoreLess.IsEnabled = true;
            }
            else
            {
                Condition.IsEnabled = false;
                MoreLess.IsEnabled = false;
            }
        }
    }
}
