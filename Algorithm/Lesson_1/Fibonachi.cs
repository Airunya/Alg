using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Lesson_1
{
    class Fibonachi
    {
        public long Fib(long n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
        public long FibCycle(long n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            int f1 = 0;
            int f2 = 1;
            int sum = 0;
            for (int i = 2; i <= n; i ++)
            {
                sum = f1 + f2;
                f1 = f2;
                f2 = sum;                
            }
            return sum;
        }        
    }
}
