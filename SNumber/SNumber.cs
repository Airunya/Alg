using System;

namespace SNumber
{
    public class SNumber
    {
        public int n { get; set; }

        void Number(int n)
        {
            int d = 0;
            int i = 2;

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
                Console.WriteLine("Простое");
            }
            else
            {
                Console.WriteLine("Не простое");
            }
        }
    }
}
