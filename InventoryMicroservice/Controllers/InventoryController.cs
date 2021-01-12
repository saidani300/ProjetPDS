using Microsoft.AspNetCore.Mvc;
using InventoryMicroservice.Models;
using System.Transactions;
using ProductMicroservice.Repository;
using System.Collections.Generic;

namespace InventoryMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public IEnumerable<Inventory> Get()
        {
            return _inventoryRepository.GetInventories();
        }
        [HttpPost]
        public void Post([FromBody] Inventory inventory)
        {

            _inventoryRepository.InsertInventory(inventory);

        }
    }
}