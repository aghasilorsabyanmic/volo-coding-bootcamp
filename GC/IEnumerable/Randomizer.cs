using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableVolo
{
    public class Randomizer<T> : IEnumerable<T> where T : class
    {
        public Randomizer(int capacity)
        {
            values = new T[capacity];
        }

        private int current = 0;

        private T[] values;

        public void Add(T value)
        {
            if (current == values.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            values[current++] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < values.Length; i++)
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class RandomizerAlt
    {
        public static IEnumerable<T> Randomize<T>(IEnumerable<T> values) where T : B, IEnumerable, IComparable
        {
            return values;
        }
    }

    public class A : IComparable
    {
        public int X { get; set; }

        public int CompareTo(object obj)
        {
            var tmp = obj as A;
            return X - tmp.X;            
        }
    }

    public class B
    {
        public IComparable Max(IComparable x, IComparable y)
        {
            var val = x.CompareTo(y);
            if (val > 1) return x;
            else return y;
        }
    }

    public class Generic<U, V>
    {

    }
}
