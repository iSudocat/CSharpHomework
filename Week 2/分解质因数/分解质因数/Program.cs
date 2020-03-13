using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 分解质因数
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                for (int i = 2; i < num; i++)
                {
                    while (num != i)
                    {
                        if (num % i == 0)
                        {
                            Console.Write(i + " ");
                            num /= i;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine(num);
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("请正确输入。");
            }
                
        }
    }
}
