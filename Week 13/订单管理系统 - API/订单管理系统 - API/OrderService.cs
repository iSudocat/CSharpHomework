using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Security.Cryptography;


namespace OrderDB
{
    public class Item_Form
    {
        public string Pname { get; set; }   //商品名
        public int Pnum { get; set; }   //商品数量
        public double PPrice { get; set; }   //单个商品总价
    }

    public class OrderService
    {
        Goods goods = new Goods();

        public void AddOrder(string customer)
        {
            using (var context = new OrderContext())
            {
                var neworder = new OrderDB.Order { ID = GetOrderID(customer), Customer = customer };
                context.Orders.Add(neworder);
                context.SaveChanges();
            }
        }

        public void DelOrder(String id)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include(o => o.Items).FirstOrDefault(i => i.ID == id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }

        public List<Order> GetAllOrder()
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders;
                return order.ToList();
            }
        }

        public List<Order> SortOrder(string op)
        {
            using (var context = new OrderContext())
            {
                List<Order> re = new List<Order>();
                switch (op)
                {
                    case "ID":
                        var q = from o in context.Orders orderby o.ID select o;
                        return q.ToList();

                    case "Price":
                        q = from o in context.Orders orderby o.TotalPrice descending select o;
                        return q.ToList();
                    case "Customer":
                        q = from o in context.Orders orderby o.Customer select o;
                        return q.ToList();
                    default:
                        throw new InvalidSortException("错误的排序依据。");
                }
            }
        }

        public void AddItem(string id, string pname, int pnum)
        {
            if (goods.GoodExists(pname))
            {
                using (var context = new OrderContext())
                {
                    var item = new Item() { Pname = pname, Pnum = pnum, PPrice = goods.GetPrice(pname) * pnum, ID = id };
                    context.Entry(item).State = EntityState.Added;
                    context.SaveChanges();
                    CalculateTotalPrice(id);
                }
            }
            else
            {
                throw new GoodNotExistsException("当前添加的商品不存在。");
            }
        }

        public List<Item_Form> GetItem(string id)
        {

            using (var context = new OrderContext())
            {
                List<Item_Form> re = new List<Item_Form>();
                var items = from i in context.Items
                            where i.ID == id
                            select new { i.Pname, i.Pnum, i.PPrice };
                foreach (var i in items)
                {
                    re.Add(new Item_Form() { Pname = i.Pname, Pnum = i.Pnum, PPrice = i.PPrice });
                }
                return re;
            }
        }

        public void ModifyOrder(String id, String pname, int pnum)
        {
            using (var context = new OrderContext())
            {
                var item = context.Items.FirstOrDefault(i => id == i.ID && pname == i.Pname);
                if (item != null)
                {
                    if (pnum == 0)
                    {
                        context.Items.Remove(item);
                        context.SaveChanges();
                        CalculateTotalPrice(id);
                    }
                    else
                    {
                        item.Pnum = pnum;
                        item.PPrice = goods.GetPrice(pname) * pnum;
                        context.SaveChanges();
                        CalculateTotalPrice(id);
                    }
                }
            }
        }

        public void CalculateTotalPrice(String id)
        {
            double TotalPrice = 0;
            using (var context = new OrderContext())
            {
                var items = context.Items.Where(i => i.ID == id);
                foreach (var i in items)
                {
                    TotalPrice += goods.GetPrice(i.Pname) * i.Pnum;
                }
                var order = context.Orders.SingleOrDefault(o => o.ID == id);
                if (order != null)
                {
                    order.TotalPrice = TotalPrice;
                    context.SaveChanges();
                }
            }
        }

        public List<Order> Query(String op, String src)
        {
            List<Order> re = new List<Order>();
            using (var context = new OrderContext())
            {
                switch (op)
                {
                    case "ID":
                        var order = context.Orders.Where(o => o.ID == src);
                        foreach (var o in order)
                        {
                            re.Add(o);
                        }
                        return re;
                    case "Product":
                        order = from o in context.Orders
                                join i in context.Items
                                on o.ID equals i.ID
                                where i.Pname == src
                                select o;
                        foreach (var o in order)
                        {
                            re.Add(o);
                        }
                        return re;
                    case "Customer":
                        order = context.Orders.Where(o => o.Customer == src);
                        foreach (var o in order)
                        {
                            re.Add(o);
                        }
                        return re;
                    default:
                        throw new InvalidQueryException("错误的查询依据。");
                }

            }
        }
        private static string GetOrderID(string customer)
        {
            string source = customer + DateTime.Now.ToString();
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, source);
            return hash;
        }
        private static string GetItemID(string id)
        {
            string source = id + DateTime.Now.ToString();
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, source);
            return hash;
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }



    public class ItemExistsException : ApplicationException
    {
        public ItemExistsException(string message) : base(message)
        {
        }
    }

    public class ItemInvalidException : ApplicationException
    {
        public ItemInvalidException(string message) : base(message)
        {
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
