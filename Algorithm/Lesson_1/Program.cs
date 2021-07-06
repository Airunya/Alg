using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Lesson_1
{
    class Program
    {
        public class TestCase
        {
            public int N { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void TestValidNumber(TestCase testCase)
        {
            try
            {
                var actual = Number(testCase.N);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        static bool Number(int n)
        {
            int d = 0;
            int i = 2;

            if (n < 1)
            {
                throw new ArgumentException("n<1");                
            }
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            if (d == 0)
            {
                Console.WriteLine("простое");
                return true;
            }
            else
            {
                Console.WriteLine("сложное");
                return false;
            }
        }

        static void Main(string[] args)
        {
            //тесты функции
            var testCase1 = new TestCase()
            {
                N = 7,
                Expected = true,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                N = 6,
                Expected = false,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                N = 0,
                Expected = true,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                N = -5,
                Expected = false,
                ExpectedException = null
            };
            TestValidNumber(testCase1);
            TestValidNumber(testCase2);
            TestValidNumber(testCase3);
            TestValidNumber(testCase4);




            // фибоначи
            Fibonachi fibonachi = new Fibonachi();
            Console.WriteLine("фибоначчи:");
            Console.WriteLine("Ввести число n");
            long n = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("рекурсия");
            Console.WriteLine(fibonachi.Fib(n));
            Console.WriteLine("цикл");
            Console.WriteLine(fibonachi.FibCycle(n));
        }
    }
}
