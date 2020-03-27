using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderManageSystem.Order;
using System.IO;

/******************************************************2020.3.20******************************************************
写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。
在Program里面可以调用OrderService的方法完成各种订单操作。
要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
******************************************************2020.3.27******************************************************
1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；添加一个Import方法可以从XML文件中载入订单。
2、对订单程序中OrderService的各个Public方法添加测试用例。
*********************************************************************************************************************/

namespace OrderManageSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService();
            Order CurrentOrder = null;
            
            try
            {
                service.Import();
                Console.WriteLine("成功读取了存档数据。");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("未找到存档数据。");
            }
            while (true)
            {
                string op = Console.ReadLine();
                if (op.Length == 0)
                {
                    continue;
                }

                switch (op[0])
                {
                    case 'c':
                        if (op.Length <= 1)
                        {
                            Console.WriteLine("请输入客户名。");
                        }
                        else
                        {
                            var o = new Order(op.Substring(2));
                            service.AddOrder(o);
                            CurrentOrder = o;
                            Console.WriteLine("系统已成功为你创建了新订单。订单号：{0}\n通过a操作添加订单明细吧。", o.ID);
                        }
                        break;

                    case 'a':
                        if (CurrentOrder == null)
                        {
                            Console.WriteLine("错误！请先通过c操作创建订单后再尝试添加订单明细。");
                        }
                        try 
                        {
                            var t = op.Split(' ');
                            string pname = t[1];
                            int pnum = Convert.ToInt32(t[2]);
                            try
                            {
                                CurrentOrder.AddItem(pname, pnum);
                                Console.WriteLine("成功为当前订单添加了{0}个{1}。重复c操作可以继续添加哦。", pnum, pname);
                            }
                            catch (ItemExistsException) 
                            {
                                Console.WriteLine("添加商品失败，当前商品已存在。如需修改请使用m操作进行。");
                            }
                            catch(GoodNotExistsException)
                            {
                                Console.WriteLine("添加商品失败，尝试添加的商品不存在。");
                            }
                            
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Console.WriteLine("命令格式错误，请检查后再试");
                        }
                        break;

                    case 'd':
                        if (op.Length <= 1)
                        {
                            Console.WriteLine("请输入要删除的订单号。");
                        }
                        else
                        {
                            try
                            {
                                service.DelOrder(op.Substring(2));
                            }
                            catch(OrderInvalidException)
                            {
                                Console.WriteLine("删除订单失败，请检查订单号是否正确。");
                            }
                        }
                        break;

                    case 'm':
                        try
                        {
                            var t = op.Split(' ');
                            string id = t[1];
                            string pname1 = t[2];
                            int pnum1 = Convert.ToInt32(t[3]);
                            try
                            {
                                service.ModifyOrder(id, pname1, pnum1);
                                Console.WriteLine("修改成功。");
                            }
                            catch (OrderInvalidException)
                            {
                                Console.WriteLine("修改订单失败，请检查订单号是否正确。");
                            }
                            catch (ItemInvalidException)
                            {
                                Console.WriteLine("修改订单失败，请检查商品名称是否正确。");
                            }
                        }
                        catch(IndexOutOfRangeException)
                        {
                            Console.WriteLine("命令格式错误，请检查后再试");
                        }
                        break;

                    case 's':
                        if (op.Length <= 1)
                        {
                            service.SortOrder("ID");
                            Console.WriteLine("订单排序完成。");
                        }
                        else
                        {
                            var orderby = op.Substring(2);
                            try
                            {
                                service.SortOrder(orderby);
                                Console.WriteLine("订单排序完成。");
                            }
                            catch(InvalidSortException)
                            {
                                Console.WriteLine("请输入正确的排序依据。");
                            }
                        }
                        break;

                    case 'q':
                        try
                        {
                            var t = op.Split(' ');
                            string queryop = t[1];
                            string querysrc = t[2];
                            try
                            {
                                String re = service.Query(queryop, querysrc);
                                Console.WriteLine(re);
                            }
                            catch (InvalidQueryException)
                            {
                                Console.WriteLine("错误，请检查查询依据是否正确。");
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("命令格式错误，请检查后再试");
                        }
                        break;

                    case 'e':
                        service.Export();
                        return;
                        
                    default:
                        Console.WriteLine("请输入正确的操作指令。");
                        break;
                }

            }
        }
    }
}
