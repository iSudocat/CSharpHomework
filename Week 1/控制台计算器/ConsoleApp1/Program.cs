using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Calculate
    {
        static void Add(double a, double b)
        {
            double result = a + b;
            Console.WriteLine("计算结果：{0}", result);
        }
        static void Minus(double a, double b)
        {
            double result = a - b;
            Console.WriteLine("计算结果：{0}", result);
        }
        static void Multiply(double a, double b)
        {
            double result = a * b;
            Console.WriteLine("计算结果：{0}", result);
        }
        static void Divide(double a, double b)
        {
            double result = a / b;
            Console.WriteLine("计算结果：{0}", result);
        }
        static void Main()
        {
            double n1 = 0, n2 = 0;
            try
            {
                Console.WriteLine("请输入数字1：");
                n1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入数字2：");
                n2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("请输入运算符：");
                switch (Console.ReadLine())
                {
                    case "+":
                        Add(n1, n2);
                        break;
                    case "-":
                        Minus(n1, n2);
                        break;
                    case "*":
                        Multiply(n1, n2);
                        break;
                    case "/":
                        Divide(n1, n2);
                        break;
                    default:
                        Console.WriteLine("错误的运算符");
                        return;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("错误的数字");
                return;
            }
            catch (DivideByZeroException)   //double除0不会产生此异常，故其实不需要
            {
                Console.WriteLine("不能除以0");
            }
            catch (OverflowException)
            {
                Console.WriteLine("数据溢出");
            }
        }
    }
}
