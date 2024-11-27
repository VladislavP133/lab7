using System;

namespace Example1
{
    class Program
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void Main(string[] args)
        {
            // Завдання 1: Універсальні методи
            //int
            int a = 1;
            int b = 2;
            Swap<int>(ref a, ref b);
            Console.WriteLine($"int: a={a}, b={b}");

            //double
            double x = 1.5;
            double y = 2.5;
            Swap<double>(ref x, ref y);
            Console.WriteLine($"double: x={x}, y={y}");

            //string
            string str1 = "Hello";
            string str2 = "World";
            Swap<string>(ref str1, ref str2);
            Console.WriteLine($"string: str1={str1}, str2={str2}");

            // Завдання 2: Універсальні методи з обмеженнями типу
            int[] intArray = { 3, 1, 4, 1, 5, 9 };
            double[] doubleArray = { 2.7, 3.1, 4.1, 5.9 };

            Console.WriteLine($"int array: Min={FindMin(intArray)}, Max={FindMax(intArray)}");
            Console.WriteLine($"double array: Min={FindMin(doubleArray)}, Max={FindMax(doubleArray)}");

            // Завдання 3: Універсальні класи з одним параметром
            GenericClass<int> intComparer = new GenericClass<int>();
            Console.WriteLine($"Less of 10 and 20: {intComparer.Less(10, 20)}");

            GenericClass<double> doubleComparer = new GenericClass<double>();
            Console.WriteLine($"Less of 10.5 and 20.5: {doubleComparer.Less(10.5, 20.5)}");

            Console.ReadKey();
        }

        //мінімальний елемент
        static T FindMin<T>(T[] array) where T : IComparable<T>
        {
            T min = array[0];
            foreach (T item in array)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }
            return min;
        }

        //макс елемент
        static T FindMax<T>(T[] array) where T : IComparable<T>
        {
            T max = array[0];
            foreach (T item in array)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }
            return max;
        }
    }

    //універсальний клас одним параметром
    public class GenericClass<T> where T : IComparable<T>
    {
        public T Less(T first, T second)
        {
            return first.CompareTo(second) < 0 ? first : second;
        }
    }
}
