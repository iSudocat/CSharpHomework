using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace OrderManageSystem
{
    public class Order
    {
        Goods goods = new Goods();
        public string Customer { get; set; }
        public string ID { get; set; }
        public List<OrderItem> Items;
        public double TotalPrice { get; set; }
        
        public Order()
        {

        }

        public Order(string customer)
        {
            Customer = customer;
            ID = GetOrderID(customer);
            Items = new List<OrderItem>();
            TotalPrice = 0;
        }

        public void AddItem(string pname, int pnum)
        {
            if (goods.GoodExists(pname))
            {
                var item = new OrderItem() { Pname = pname, Pnum = pnum, PPrice = goods.GetPrice(pname) * pnum };
                if (Items.Exists(i => i.Equals(item)))
                {
                    throw new ItemExistsException("当前添加的商品已存在。");
                }
                Items.Add(item);
                CalculateTotalPrice();
            }
            else
            {
                throw new GoodNotExistsException("当前添加的商品不存在。");
            }

        }

        public void ModifyItem(string pname, int pnum)
        {
            var item_new = new OrderItem() { Pname = pname, Pnum = pnum, PPrice = goods.GetPrice(pname) * pnum };
            bool flag = false;
            OrderItem item = null;
            foreach (var i in Items)
            {
                if (i.Pname == pname)
                {
                    item = i;
                    flag = true;
                }
            }
            if (flag == false)
            {

                throw new ItemInvalidException("当前修改的商品不存在。");
            }

            if (pnum == 0)
            {
                Items.Remove(item);
            }
            else
            {
                Items[Items.IndexOf(item)] = item_new;
            }
            CalculateTotalPrice();
        }

        public double CalculateTotalPrice()
        {
            TotalPrice = 0;
            foreach (var i in Items)
            {
                TotalPrice += goods.GetPrice(i.Pname) * i.Pnum;
            }
            return TotalPrice;
        }

        public override string ToString()
        {
            string re = $"订单号：{ID}\n客户：{Customer}\n";
            foreach(var i in Items)
            {
                re = re + i.ToString() + "\n";
            }
            return re;
        }

        public bool HasGood(String pname)
        {
            foreach (var i in Items)
            {
                if (i.Pname == pname)
                    return true;
            }
            return false;
        }

        private static string GetOrderID(string customer)
        {
            string source = customer + DateTime.Now.ToString();
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


        public override bool Equals(object obj)
        {
            if (obj is Order o)
            {
                return ID == o.ID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
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
        
    }
}
