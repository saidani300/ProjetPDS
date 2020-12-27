using SaleMicroService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleMicroService.Repository
{
    public interface ISaleRepository
    {
        Task AddSale(Sale sale);
        Task<Sale> GetSaleByID(int SaleId);
        Task<IEnumerable<Sale>> GetSales();
    }
}