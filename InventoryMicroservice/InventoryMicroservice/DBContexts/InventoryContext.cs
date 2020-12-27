using Microsoft.EntityFrameworkCore;
using InventoryMicroservice.Models;

namespace InventoryMicroservice.DBContexts
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }
        public DbSet<Inventory> Inventories { get; set; }

        
    }
}