﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleMicroService.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public string CashierId { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        public decimal SubTotal { get; set; }

        public decimal Tax { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<SaleDetail> SaleDetails { get; set; }
    }
}
