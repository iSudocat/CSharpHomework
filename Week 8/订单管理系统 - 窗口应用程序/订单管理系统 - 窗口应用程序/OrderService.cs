using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace OrderManageSystem
{
    public class OrderService
    {
        public List<Order> OrderList = new List<Order>();

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
            //注意，不能在foreach中对集合进行修改 可使用For循环进行
            for(var i=0;i<OrderList.Count;i++)
            {
                if(OrderList[i].ID==id)
                {
                    OrderList.Remove(OrderList[i]);
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
                    OrderList.Sort((o1, o2) => o1.ID.CompareTo(o2.ID));
                    break;
                case "Price":
                    OrderList.Sort((o1, o2) => o1.TotalPrice.CompareTo(o2.TotalPrice));
                    break;
                case "Customer":
                    OrderList.Sort((o1, o2) => o1.Customer.CompareTo(o2.Customer));
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

        public List<Order> Query(String op, String src)
        {
            List<Order> re = new List<Order>();
            switch (op)
            {
                case "ID":
                    var olist = from o in OrderList
                                where o.ID == src
                                select o;
                    foreach (var o in olist)
                    {
                        re.Add(o);
                    }
                    return re;
                case "Product":
                    var olist1 = from o in OrderList
                                 where o.HasGood(src)
                                 select o;
                    foreach (var o in olist1)
                    {
                        re.Add(o);
                    }
                    return re;
                case "Customer":
                    var olist2 = from o in OrderList
                                 where o.Customer == src
                                 select o;
                    foreach (var o in olist2)
                    {
                        re.Add(o);
                    }
                    return re;
                default:
                    throw new InvalidQueryException("错误的查询依据。");
            }
        }

        public void Export()
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("OrderList.xml", FileMode.Create))
            {
                xmlserializer.Serialize(fs, OrderList);
            }
        }

        public void Import()
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("OrderList.xml", FileMode.Open))
            {
                OrderList = (List<Order>)xmlserializer.Deserialize(fs);
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
