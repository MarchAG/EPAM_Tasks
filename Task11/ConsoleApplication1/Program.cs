using BinaryTree;
using Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<Student> tree = new Tree<Student>();
            List<Test> tests1 = new List<Test>()
                {
                    new Test("1",5),
                    new Test("2",6)
                };
            List<Test> tests2 = new List<Test>()
                {
                    new Test("1",5),
                    new Test("2",2)
                };
            List<Test> tests3 = new List<Test>()
                {
                    new Test("1",5),
                    new Test("2",4)
                };
            List<Test> tests4 = new List<Test>()
            {
                    new Test("1",8),
                    new Test("2",6)
                };
            List<Test> tests5 = new List<Test>()
                {
                    new Test("1",7),
                    new Test("2",6)
                };

            Student stud1 = new Student("Ivanov",tests1);
            Student stud2 = new Student("Petrov", tests2);
            Student stud3 = new Student("Sidorov", tests3);

            Student stud4 = new Student("Stakov", tests4);

            Student stud5 = new Student("Sivcev", tests5);


            tree.Add(stud1);
            tree.Add(stud2);
            tree.Add(stud3);
            tree.Add(stud4);
            tree.Add(stud5);
            tree.Remove(stud1);

            foreach (var node in tree)
            {
                Console.WriteLine((double)node);
            }
        }
    }
}
