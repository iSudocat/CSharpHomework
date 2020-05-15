using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderDB
{
    public class Order
    {

        [Required]
        public string Customer { get; set; }
        [Key]
        public string ID { get; set; }
        public double TotalPrice { get; set; }

        public List<Item> Items { get; set; }   //一对多关联
    }

    public class Item
    {

        [Required]
        [Key, Column(Order = 2)]
        public string Pname { get; set; }   //商品名
        [Required]
        public int Pnum { get; set; }   //商品数量
        [Required]
        public double PPrice { get; set; }   //单个商品总价

        [Required]
        [Key, Column(Order = 1)]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public Order Order { get; set; }    //多对一关联
    }

}
