using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManageSystem
{
    public class OrderItem
    {
        public string Pname { get; set; }   //商品名
        public int Pnum { get; set; }   //商品数量
        public double PPrice { get; set; }   //单个商品总价

        Goods goods = new Goods();
        public override bool Equals(object obj)
        {
            if (obj is OrderItem o)
            {
                return Pname == o.Pname;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Pname.GetHashCode();
        }

        public override string ToString()
        {
            return $"商品：{Pname} 数量：{Pnum} 价格：{PPrice}";
        }
    }
}
