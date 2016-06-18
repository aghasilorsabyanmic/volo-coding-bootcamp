using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void MyDelegate();
    delegate double MyDelegate1(double x);

    class Program
    {

        static void Main(string[] args)
        {
            MyDelegate d1 = new MyDelegate(Program.F1);
            MyDelegate d11 = F1;
            d1 += d11;
            var p = new Program();
            MyDelegate d2 = new MyDelegate(p.F2);
            MyDelegate d22 = p.F2;

            MyDelegate d;
            d = d1 + d2 + d22;
            d -= d2;

            MyDelegate d3 = delegate () { };

            F(delegate (double x) { return x * x; });
            F(delegate (double x) { return 2 * x; });
            F(Math.Sin);
            F(x => x * x * x);

            Action a1 = F1;
            Action<MyDelegate1> a2 = F;

            Action<string, object> a3 = Console.WriteLine;

            Func<double, double> f1 = Math.Sin;
            Func<double, double, double> pow = Math.Pow;

            Action l1 = () => { };
            Action<string> l21 = (string s) => { Console.WriteLine(s.Trim()); };
            Action<string> l22 = (s) => { Console.WriteLine(s.Trim()); };
            Action<string> l23 = s => { Console.WriteLine(s.Trim()); };
            Action<string> l24 = s => Console.WriteLine(s.Trim());

            Func<double> f21 = () => { return -1; };
            Func<double> f22 = () => -1;
            Func<double, double> f23 = x => x * x;

            var squares = Enumerable.Range(1, 100).Select(n => n * n);
            var sin = Enumerable.Range(0, 100).Select(n => n/100.0).Select(Math.Sin);
        }

        static void F(MyDelegate1 d)
        {
            var collection = Enumerable.Range(1, 10);
            foreach (var item in collection)
            {
                Console.WriteLine(d(item));
            }
        }

        static void F1()
        {
        }

        public void F2()
        {

        }

        public void F3()
        {
            MyDelegate d = F2;
        }
    }
}
