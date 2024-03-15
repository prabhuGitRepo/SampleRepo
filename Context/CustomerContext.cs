using EFCoreWithSwagger.Models;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace EFCoreWithSwagger.Context
{
   public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) 
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Order { get; set; }

    }
}
