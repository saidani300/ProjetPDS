using InventoryMicroservice.Models;
using System.Collections.Generic;

namespace ProductMicroservice.Repository
{
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> GetInventories();
        void InsertInventory(Inventory inventory);
        void Save();
    }
}