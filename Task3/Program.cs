using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Program
    {
        public static void Main()
        {
            CollectionCreating colCreating = new CollectionCreating();
            colCreating.CreateCollection();
        }
    }

    public class CollectionCreating
    {
        public void CreateCollection()
        {
            MyCollection col = new MyCollection();

            Console.WriteLine("Enter the element of collection (numbers only), then press 'Enter'");
            Console.WriteLine("When you finish - press 'Y' button");
            Console.WriteLine(" ");

            int item = 0;
            do
            {
                string element = Console.ReadLine();
                if (element.ToLowerInvariant() == "y")
                {
                    break;
                }
                try
                {
                    item = Convert.ToInt32(element);
                    col.Add(item);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("{0} The '{1}' is not an integer number", e.Message, element);
                }
            } while (true);

            Console.WriteLine(" ");

            Console.WriteLine("Collection itemes till negative number:");

            foreach (int i in col)
            {
                Console.Write(i + " ");
            }

            Console.ReadLine();
        }

    }

    public class MyCollection: IEnumerable
    {
        public int[] items;

        public MyCollection()
        {
            items = new int[0] { };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public MyEnumerator GetEnumerator()
        {
            return new MyEnumerator(items);
        }

        public void Add(int newItem)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = newItem;
        }
        
        public class MyEnumerator: IEnumerator
        {
            int nIndex;
            int[] collection;

            public MyEnumerator(int[] coll)
            {
                collection = coll;
                nIndex = -1;
            }

            public bool MoveNext()
            {
                nIndex++;
                return (nIndex < collection.Length && collection[nIndex]>=0);
            }

            public void Reset()
            {
                nIndex = -1;
            }

            public int Current
            {
                get
                {
                    return (collection[nIndex]);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return (Current);
                }
            }
        }
    }
}

