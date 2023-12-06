using Microsoft.EntityFrameworkCore;

namespace PayCoreAPI.Models.ORM
{
    public class PayCoreContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-EET2RGT;Database=PayCoreDB; trusted_connection=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Client> Clients { get; set; }





    }
}
