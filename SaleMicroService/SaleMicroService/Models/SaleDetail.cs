using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleMicroService.Models
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Tax { get; set; }
        public Sale Sale { get; set; }
    }
}
