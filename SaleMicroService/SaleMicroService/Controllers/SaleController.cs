using Microsoft.AspNetCore.Mvc;
using SaleMicroService.Models;
using SaleMicroService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaleMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Sale>> Get()
        {
            return  await _saleRepository.GetSales();
        }

        [HttpGet("{id}")]
        public async Task<Sale> Get(int id)
        {
            return await _saleRepository.GetSaleByID(id);
        }

        [HttpPost]
        public async Task Post( Sale sale)
        {
           await _saleRepository.AddSale(sale);
        }

    }
}
