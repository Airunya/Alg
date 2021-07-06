using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Lesson_1
{
    class Function
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;  //O(1)
            for (int i = 0; i < inputArray.Length; i++)             //
            {                                                       //                
                for (int j = 0; j < inputArray.Length; j++)         //  O(N^3)
                {                                                   //
                    for (int k = 0; k < inputArray.Length; k++)     //    
                    {
                        int y = 0;  //0(1)

                        if (j != 0) //O(1)
                        {
                            y = k / j; //0(1)
                        }

                        sum += inputArray[i] + i + k + j + y; //O(1)
                    }
                }
            }            
            return sum; //O(1)
        }
        //O(1+N^2*(N+4)+1)

        //O(N^3)
    }
}
