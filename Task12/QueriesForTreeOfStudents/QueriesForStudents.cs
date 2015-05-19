using Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QueriesForTreeOfStudents
{
    public class QueriesForStudents
    {
        public static IQueryable<Student> WhereForTree(IQueryable<Student> stud,string symbol, double constant)
        {
            ParameterExpression pe = System.Linq.Expressions.Expression.Parameter(typeof(Student), "Students");
            System.Linq.Expressions.Expression left = System.Linq.Expressions.Expression.Call(pe, typeof(Student).GetMethod("GetAvMark", System.Type.EmptyTypes));
            System.Linq.Expressions.Expression right = System.Linq.Expressions.Expression.Constant(constant);
            System.Linq.Expressions.Expression e1 = System.Linq.Expressions.Expression.GreaterThanOrEqual(left, right);
            switch (symbol)
            {
                case ">":
                    e1 = System.Linq.Expressions.Expression.GreaterThan(left, right);
                    break;
                case "<=":
                    e1 = System.Linq.Expressions.Expression.LessThanOrEqual(left, right);
                    break;
                case "<":
                    e1 = System.Linq.Expressions.Expression.LessThan(left, right);
                    break;
                default:
                    break;
            }
            MethodCallExpression whereCallExpression = System.Linq.Expressions.Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { stud.ElementType },
                stud.Expression,
                System.Linq.Expressions.Expression.Lambda<Func<Student, bool>>(e1, new ParameterExpression[] { pe }));
            IQueryable<Student> results = stud.Provider.CreateQuery<Student>(whereCallExpression);
            return results;
        }

        public static IQueryable<Student> OrderForTree(IQueryable<Student> stud, bool? desc)
        {
            ParameterExpression pe = System.Linq.Expressions.Expression.Parameter(typeof(Student), "Students");
            string order = "OrderBy";
            if (desc == true)
            {
                order = "OrderByDescending";
            }
            MethodCallExpression orderByCallExpression = System.Linq.Expressions.Expression.Call(
                typeof(Queryable),
                order,
                new Type[] { stud.ElementType, stud.ElementType },
                stud.Expression,
                System.Linq.Expressions.Expression.Lambda<Func<Student, Student>>(pe, new ParameterExpression[] { pe }));
            IQueryable<Student> results = stud.Provider.CreateQuery<Student>(orderByCallExpression);
            return results;
        }

        public static IQueryable<Student> TakeFromTree(IQueryable<Student> stud,int number)
        {
            return stud.Take(number);
        }
    }
}
