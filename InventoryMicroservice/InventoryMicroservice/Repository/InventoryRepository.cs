using Microsoft.EntityFrameworkCore;
using InventoryMicroservice.DBContexts;
using InventoryMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductMicroservice.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryContext _dbContext;

        public InventoryRepository(InventoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Inventory> GetInventories()
        {
            return _dbContext.Inventories.ToList();
        }



        public void InsertInventory(Inventory inventory)
        {
            _dbContext.Add(inventory);
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}