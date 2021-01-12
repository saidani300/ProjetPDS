using Microsoft.EntityFrameworkCore;
using SaleMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleMicroService.DBContexts
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

                
            base.OnModelCreating(modelBuilder);
        }
    }
}
