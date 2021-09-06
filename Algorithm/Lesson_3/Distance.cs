using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Lesson_3
{
    class Distance
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Distance).Assembly).Run(args);
        }
    }
    public class BechmarkClass
    {

        public class PointClass
        {
            public int X;
            public int Y;
        }
        public struct PointStruct
        {
            public double X;
            public double Y;
        }
        public struct PointStructFloat
        {
            public float X;
            public float Y;
        }

        public double PointDistance1(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            double result = Math.Sqrt((x * x) + (y * y));
            return result;
        }

        public static float PointDistance2(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float PointDistance3(PointClass pointOne, PointClass pointTwo)
        {
            int x = pointOne.X - pointTwo.X;
            int y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistance4(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return Sqrt((x * x) + (y * y));
        }
        public static float Sqrt(float x)
        {
            float s = ((x / 2) + x / (x / 2));
            for (int i = 0; i < 4; i++)
            {
                s = (s + x / s) / 2;
            }
            return s;
        }


        [Benchmark]
        public void TestStructDouble()     //Структура дабл
        {
            var pointOne = new PointStruct { X = 6, Y = 8 };
            var pointTwo = new PointStruct { X = 3, Y = 12 };
            PointDistance1(pointOne, pointTwo);
        }
        [Benchmark]
        public void TestStructFloat()       //Структура флоат
        {
            var pointOne = new PointStructFloat { X = 6, Y = 8 };
            var pointTwo = new PointStructFloat { X = 3, Y = 12 };
            PointDistance2(pointOne, pointTwo);
        }
        [Benchmark]
        public void TestStructFloatSqrt()        //Структура флоат без корня
        {
            var pointOne = new PointStructFloat { X = 6, Y = 8 };
            var pointTwo = new PointStructFloat { X = 3, Y = 12 };
            PointDistance4(pointOne, pointTwo);
        }
        [Benchmark]
        public void TestClassInt()      //Класс инт
        {
            var pointOne = new PointClass { X = 6, Y = 8 };
            var pointTwo = new PointClass { X = 3, Y = 12 };
            PointDistance3(pointOne, pointTwo);
        }

    }
}
// Класс работает медленнее тк находится в управляемой куче, и при создании обьекта класса ему требуется найти место в куче,
// разместить данные и получить ссылку + требуется время на отработку "сборщика мусора". (конкретно тут)
// Структура работает быстрее тк находится в стэке и работает без ссылок.


