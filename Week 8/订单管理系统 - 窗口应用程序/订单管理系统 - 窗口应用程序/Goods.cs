using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManageSystem
{
    class Good
    {
        public string name { get; set; }
        public double price { get; set; }
    }

    class Goods
    {
        public List<Good> GoodsList = new List<Good>();

        public Goods()
        {
            InitializeGoods();
        }

        public void InitializeGoods()
        {
            GoodsList.Add(new Good() { name = "水杯", price = 19.9 });
            GoodsList.Add(new Good() { name = "中性笔", price = 1.5 });
            GoodsList.Add(new Good() { name = "手表", price = 288 });
            GoodsList.Add(new Good() { name = "手机", price = 4699 });
            GoodsList.Add(new Good() { name = "电脑", price = 8999 });
        }

        public bool GoodExists(string goodname)
        {
            foreach (var g in GoodsList)
            {
                if (g.name == goodname)
                {
                    return true;
                }
            }
            return false;
        }

        public double GetPrice(string goodname)
        {
            foreach (var g in GoodsList)
            {
                if (g.name == goodname)
                {
                    return g.price;
                }
            }
            return 0;
        }
    }

    public class GoodNotExistsException : ApplicationException
    {
        public GoodNotExistsException(string message) : base(message)
        {
        }
    }
}
