using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderDB;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController(OrderContext context)
        {
            _context = context;
        }


        // POST: api/Order/new    添加订单
        [HttpPost("new")]
        public ActionResult<Order> AddOrder(string Customer)
        {
            try
            {
                var neworder = new Order { ID = GetOrderID(Customer), Customer = Customer };
                _context.Orders.Add(neworder);
                _context.SaveChanges();
                return neworder;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        // GET: api/Order/{id}    查询订单
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        // DELETE: api/Order/{id}     删除订单
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.ID == id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        // POST: api/Order/newitem    新增item
        [HttpPost("newitem")]
        public ActionResult<Item> AddItem(Item item)
        {
            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        // GET: api/Order/item/{id}    查询item
        [HttpGet("item/{id}")]
        public ActionResult<Item> GetItem(string id)
        {
            var item = _context.Items.FirstOrDefault(i => i.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/Order/delitem    修改item
        [HttpPost("修改item")]
        public ActionResult<Item> ModifyItem(Item item)
        {
            try
            {
                var olditem = _context.Items.FirstOrDefault(i => item.ID == i.ID);
                if (olditem != null)
                {
                    olditem = item;
                    return item;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
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
    }
}
