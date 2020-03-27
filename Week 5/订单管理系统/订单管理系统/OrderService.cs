using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManageSystem
{
    class OrderService
    {
        private List<Order> OrderList = new List<Order>();

        public void AddOrder(Order order)
        {
            if (OrderList.Exists(o => o.Equals(order)))
            {
                throw new OrderExistsException("当前添加的订单已存在。");
            }
            OrderList.Add(order);
        }

        public void DelOrder(String id)
        {
            bool flag = false;
            foreach (var o in OrderList)
            {
                if (o.ID == id)
                {
                    OrderList.Remove(o);
                    flag = true;
                }
            }

            if (flag == false)
            {
                throw new OrderInvalidException("欲删除的订单不存在。");
            }
        }

        public void SortOrder(string op)
        {
            switch (op)
            {
                case "ID":
                    OrderList.OrderBy(o => o.ID);
                    break;
                case "Price":
                    OrderList.OrderBy(o => o.TotalPrice);
                    break;
                case "Customer":
                    OrderList.OrderBy(o => o.Customer);
                    break;
                default:
                    throw new InvalidSortException("错误的排序依据。");
            }

        }

        public void ModifyOrder(String id, String pname, int pnum)
        {
            bool flag = false;
            Order order = null;
            foreach (var o in OrderList)
            {
                if (o.ID == id)
                {
                    order = o;
                    flag = true;
                }
            }
            if (flag == true)
            {
                order.ModifyItem(pname, pnum);
            }
            else
            {
                throw new OrderInvalidException("欲修改的订单不存在。");
            }

        }

        public String Query(String op, String src)
        {
            String re = "";
            switch (op)
            {
                case "ID":
                    var olist = from o in OrderList
                                where o.ID == src
                                select o;
                    
                    foreach (var o in olist)
                    {
                        re = re + o.ToString() + "\n";
                        return re;
                    }
                    return "";
                case "Product":
                    var olist1 = from o in OrderList
                                 where o.HasGood(src)
                                 select o;
                    foreach (var o in olist1)
                    {
                        re = re + o.ToString() + "\n";
                        return re;
                    }
                    return "";
                case "Customer":
                    var olist2 = from o in OrderList
                                 where o.Customer == src
                                 select o;
                    foreach (var o in olist2)
                    {
                        re = re + o.ToString() + "\n";
                        return re;
                    }
                    return "";
                default:
                    throw new InvalidQueryException("错误的查询依据。");
            }
        }
    }



    public class OrderExistsException : ApplicationException
    {
        public OrderExistsException(string message) : base(message)
        {
        }
    }

    public class OrderInvalidException : ApplicationException
    {
        public OrderInvalidException(string message) : base(message)
        {
        }
    }
    public class InvalidSortException : ApplicationException
    {
        public InvalidSortException(string message) : base(message)
        {
        }
    }

    public class InvalidQueryException : ApplicationException
    {
        public InvalidQueryException(string message) : base(message)
        {
        }
    }
}
