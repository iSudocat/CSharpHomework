using System;

/*******************************题目***********************************
1、为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。
通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。
**********************************************************************/

namespace 泛型链表
{
    public class Node<T>    // 链表节点
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }
    public class GenericList<T>    //泛型链表类
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> node = this.head;
            while (node != null)
            {
                action(node.Data);
                node = node.Next;
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }

            intlist.ForEach(m => Console.WriteLine(m));

            int max = int.MinValue;
            intlist.ForEach(m => { if (m > max) max = m; });
            Console.WriteLine("最大值：" + max);

            int min = int.MaxValue;
            intlist.ForEach(m => { if (m < min) min = m; });
            Console.WriteLine("最小值：" + min);

            int sum = 0;
            intlist.ForEach(m =>  sum += m);
            Console.WriteLine("和：" + sum);
        }
    }
}
