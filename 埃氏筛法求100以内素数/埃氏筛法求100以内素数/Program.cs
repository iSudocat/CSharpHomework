using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 埃氏筛法求100以内素数
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[99];
            for (int i = 0; i < 99; i++)    //2-100
            {
                a[i] = i + 2;
            }

            int m = 2;   //筛子
            while (m * m < 100)   //筛子最大到开根
            {
                for (int j = 0; j < 99; j++)
                {
                    if (a[j] != 0 && a[j] % m == 0 && a[j] != m)     //是m的倍数且没有被筛去（置0）的置0
                    {
                        a[j] = 0;
                    }
                }
                for (int j = 0; j < 99; j++)
                {
                    if (a[j] != 0 && a[j] > m)     //选择剩余数中的第一个数为筛子
                    {
                        m = a[j];
                        break;
                    }
                }
            }

            for (int j = 0; j < 99; j++)
            {
                if (a[j] != 0)     //输出所有没被筛掉的
                {
                    Console.WriteLine(a[j]);
                }
            }

            Console.ReadLine();
        }
    }
}
