using System.Data.Entity;



namespace OrderDB
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("OrderDB")
        {
            new CreateDatabaseIfNotExists<OrderContext>();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

    }

}
