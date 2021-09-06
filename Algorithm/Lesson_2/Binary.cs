using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Lesson_2
{
    class Binary
    {
        public class TestCase
        {
            public int N { get; set; }
            public int[] Arr { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void TestValid(TestCase testCase)
        {
            try
            {
                var actual = Search(testCase.Arr, testCase.N);

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
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        static int Search(int[] arr, int x)
        {
            var i = 0;              
            var j = arr.Length;     
            while (i != j)   
            {
                var m = (i + j) / 2;  
                if (x == arr[m])
                    return arr[m];
                if (x < arr[m])
                    j = m;            
                else
                    i = m + 1;        
            }

            return -1;
        }                                   //O(log n)

        static void Main(string[] args)
        {
            var items = new[] { 2, 3, 5, 7, 11, 13, 17 };
            var testCase1 = new TestCase()
            {
                Arr = items,
                N = 6,
                Expected = -1,
                ExpectedException = null                
            };
            var testCase2 = new TestCase()
            {
                Arr = items,
                N = 17,
                Expected = -1,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                Arr = items,
                N = -6,
                Expected = -1,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                Arr = items,
                N = 11,
                Expected = 11,
                ExpectedException = null
            };
            TestValid(testCase1);
            TestValid(testCase2);
            TestValid(testCase3);
            TestValid(testCase4);
        }
    }
}



 

