using System;

/*
题目：
1. 编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口/抽象类、属性来实现。
2. 随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。
*/

namespace AllShape
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] DefShape = new string[3] { "Square", "Rectangle", "Triangle" };
            Shape s;
            int LeagleNum = 0;
            double TotalArea = 0;
            for (int i = 0; i < 10; i++)
            {
                Random r1 = new Random(Guid.NewGuid().GetHashCode());
                Random r2 = new Random(Guid.NewGuid().GetHashCode());
                int t = r1.Next(0, 3);  //下标
                s = Factory.CreateShape(DefShape[t], r2.Next(0, 10), r2.Next(0, 10), r2.Next(0, 10));

                if (s.IsLegal())
                {
                    Console.WriteLine("生成了一个" + DefShape[t]+ " 面积为" + s.GetArea());
                    LeagleNum++;
                    TotalArea += s.GetArea();
                }
                else
                {
                    Console.WriteLine("生成了一个错误的" + DefShape[t]);
                }
            }
            Console.WriteLine("共生成了" + LeagleNum + "个合法的形状，总面积为" + TotalArea);
        }
    }

    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract bool IsLegal();
    }

    class Square : Shape
    {
        public double side { get; set; }
        public override bool IsLegal() => side > 0;
        public override double GetArea() => side * side;
    }

    class Rectangle : Shape
    {
        public double length { get; set; }
        public double width { get; set; }
        public override bool IsLegal() => length > 0 && width > 0;
        public override double GetArea() => length * width;
    }

    class Triangle : Shape
    {
        public double side1 { get; set; }
        public double side2 { get; set; }
        public double side3 { get; set; }
        public override bool IsLegal() => (side1 > 0) && (side2 > 0) && (side3 > 0) && (side1 + side2 > side3)
            && (side2 + side3 > side1) && (side1 + side3 > side2);
        public override double GetArea()
        {
            double p = 0.5 * (side1 + side2 + side3);
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
    }

    public class Factory
    {
        public static Shape CreateShape(String type, params double[] side)
        {
            switch (type)
            {
                case "Square":
                    return new Square() { side = side[0] };
                case "Rectangle":
                    return new Rectangle() { length = side[0], width = side[1] };
                case "Triangle":
                    return new Triangle() { side1 = side[0], side2 = side[1], side3 = side[2] };
                default:
                    return null;
            }
        }
    }
}
