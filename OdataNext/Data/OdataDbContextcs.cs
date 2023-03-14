using Microsoft.EntityFrameworkCore;
using OdataNext.Models;

namespace OdataNext.Data
{
    public class OdataDbContextcs : DbContext
    {


        public OdataDbContextcs(DbContextOptions<OdataDbContextcs> options) : base(options)
        { 
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get;set; }

                
    }
}
