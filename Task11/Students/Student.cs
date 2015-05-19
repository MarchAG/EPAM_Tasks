using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    [Serializable]
    public class Student : IComparable, ICloneable
    {
        public string Name{ get; set; }
        List<Test> tests;

        public Student()
        {
        }

        public Student(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            Name = name;
        }

        public Student(string name, List<Test> tests)
        {
            if (name == null)
                throw new ArgumentNullException();
            if (tests == null)
                throw new ArgumentNullException();
            Name = name;
            this.tests = tests;
        }
        public void AddTest(Test test)
        {
            if (test == null)
                throw new ArgumentNullException();
            tests.Add(test); 
        }

        public int CompareTo(object obj)
        {
            Student stud = obj as Student;
            if (stud == null)
                throw new ArgumentException();
            double inAverage = stud.tests.Average(x => x.Mark);
            double thisAverage = this.tests.Average(x => x.Mark);
            if (thisAverage < inAverage)
                return -1;
            else if (thisAverage > inAverage)
                return 1;
            else
                return 0;
        }
        public double GetAvMark()
        {
            return tests.Average(x => x.Mark);
        }
        public static explicit operator double(Student stud)
        {
            return stud.tests.Average(x => x.Mark);
        }

        public object Clone()
        {
            List<Test> cloneTests = tests.Select(item => (Test)item.Clone()).ToList();
            return new Student(this.Name, cloneTests);
        }
    }
}
