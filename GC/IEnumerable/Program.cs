using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableVolo
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = GetCollection();

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }

            DaysOfTheWeek days = new DaysOfTheWeek();

            foreach (string day in days)
            {
                Console.Write(day + " ");
            }
            // Output: Sun Mon Tue Wed Thu Fri Sat

            var r = new Randomizer<int>(3);
            r.Add(1);
            r.Add(2);
            r.Add(3);

            Console.WriteLine();

            foreach (var item in r)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        public static void DoWork()
        {
            var range = Enumerable.Range(1, 10);
            RandomizerAlt.Randomize(range);
        }

        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                if (result == 128) yield break;
                result = result * number;
                yield return result;
            }
        }

        public static IEnumerable<int> GetCollection()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield break;
        }

        
    }

    public class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < days.Length; index++)
            {
                // Yield each day of the week.
                yield return days[index];
            }
        }
    }

    
}
