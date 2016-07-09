using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Base
    {
        public void F() { Console.WriteLine("Base"); }
    }

    class Derived : Base
    {
        public void F() { Console.WriteLine("Derived"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(0, 100);
            //var myRange = Range(0, 100);

            var doubles = range.Select(x => 2 * x); //LINQ
            var myDoubles = Select(range, x => 2 * x); //OLD STYLE
            var mySelected = range.MySelect(x => x * 2); //OUR LINQ
            var myDoublesAlt = Double(range); //VERY OLD STYLE

            dynamic obj = new Base();
            obj.F();

            obj = new Derived();
        }

        static dynamic DynF()
        {
            dynamic dyn = new { X = 5 };
            dyn.Y = 4;

            return dyn;
        }

        static IEnumerable<int> Range(int start, int count)
        {
            var value = start;
            for (int i = 0; i < count; i++)
            {
                yield return value++;
            }
        }

        static IEnumerable<int> Double(IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                yield return 2 * value;
            }
        }

        static IEnumerable<V> Select<U, V>(IEnumerable<U> values, Func<U, V> selector)
        {
            foreach (var value in values)
            {
                yield return selector(value);
            }
        }
    }

    static class MyExtensions
    {
        public static IEnumerable<TResult> MySelect<T, TResult>(this IEnumerable<T> values, Func<T, TResult> selector)
        {
            foreach (var value in values)
            {
                yield return selector(value);
            }
        }

        public static void Experiment(this object obj)
        {

        }
    }
}
