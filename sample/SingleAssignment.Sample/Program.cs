using System;
using SignleAssignment;
using SignleAssignment.Extensions;

namespace SingleAssignment.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Case1();
            Case2();
            RunTest();
        }

        /// <summary>
        /// Case1. Initialization with a specified value.
        /// </summary>
        static void Case1()
        {
            Console.WriteLine("*** Case1 ***");

            var once = Once.Create("Hello");
            Console.WriteLine($"{once.Value}");

            // Explicit and implicit casts.
            Console.WriteLine($"{(string)once}");
            string greeting = once;
            Console.WriteLine($"{greeting}");

            // Overwrite protection.
            OverwiteTest(once, "Goodby");

            Console.WriteLine("");
        }

        /// <summary>
        /// Case1. Initialization with empty.
        /// </summary>
        static void Case2()
        {
            Console.WriteLine("*** Case2 ***");

            var greeting = Once.Create<string>();
            greeting.Value = "Hello";
            Console.WriteLine($"{(string)greeting}");
            OverwiteTest(greeting, "Goodby");

            var no = Once.Create<int>();
            no.TrySet(10);
            Console.WriteLine($"{no.Value}");
            OverwiteTest(no, 5);

            Console.WriteLine("");
        }

        /// <summary>
        /// Tests that you cannot overwrite.
        /// </summary>
        static void OverwiteTest<T>(Once<T> once, T newValue)
        {
            if (!once.TrySet(newValue))
            {
                Console.WriteLine($"Cannot overwrite : {(T)once}");
            }

            try
            {
                once.Value = newValue;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException occurred.");
            }
            finally
            {
                Console.WriteLine($"Cannot overwrite : {(T)once}");
            }
        }

        static void RunTest()
        {
            Console.WriteLine("*** Run method ***");

            var once = Once.Create(10);
            once.Run(
                value => Console.WriteLine($"value = {value}"),
                () => Console.WriteLine($"value is empty."));

            var empty = Once.Create<int>();
            empty.Run(
                value => Console.WriteLine($"value = {value}"),
                () => Console.WriteLine($"value is empty."));

            Console.WriteLine("");
        }
    }
}
