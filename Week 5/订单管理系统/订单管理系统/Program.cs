using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderManageSystem.Order;

namespace OrderManageSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService();
            Order CurrentOrder = null;

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
                    default:
                        Console.WriteLine("请输入正确的操作指令。");
                        break;
                }

            }
        }
    }
}
