using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 整数数组
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 7, 24, 9, 6, 2, 8, 13, 7, 19 };
            Max(a);
            Min(a);
            Sum(a);
            Average(a);
            Console.ReadLine();
        }
        private static void Max(int[] a)
        {
            int max = a[0];
            foreach(int x in a )
            {
                if(x > max)
                {
                    max = x;
                }
            }
            Console.WriteLine("最大值" + max);
        }
        private static void Min(int[] a)
        {
            int min = a[0];
            foreach (int x in a)
            {
                if (x < min)
                {
                    min = x;
                }
            }
            Console.WriteLine("最小值" + min);
        }
        private static void Sum(int[] a)
        {
            int sum = 0;
            foreach (int x in a)
            {
                sum += x;
            }
            Console.WriteLine("和" + sum);
        }
        private static void Average(int[] a)
        {
            double sum = 0;
            foreach (int x in a)
            {
                sum += x;
            }
            double average = sum / a.Length;
            Console.WriteLine("平均值" + average);
        }
    }
}
