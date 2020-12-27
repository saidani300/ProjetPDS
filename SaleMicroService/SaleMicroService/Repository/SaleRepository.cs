using Microsoft.EntityFrameworkCore;
using SaleMicroService.DBContexts;
using SaleMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleMicroService.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SaleContext _dbContext;

        public SaleRepository(SaleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Sale>> GetSales()
        {
            return await _dbContext.Sales.ToListAsync();
        }

        public async Task<Sale> GetSaleByID(int SaleId)
        {
            return await _dbContext.Sales.FirstOrDefaultAsync((e) => e.Id == SaleId);
        }

        public async Task AddSale(Sale sale)
        {
            await _dbContext.AddAsync(sale);
            await _dbContext.SaveChangesAsync();
        }


    }
}
