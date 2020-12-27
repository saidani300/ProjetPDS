using ProductMicroService.Models;
using System.Collections.Generic;

namespace ProductMicroService.Repository
{
    public interface IProductRepository
    {
        Product GetProductByID(int productId);
        IEnumerable<Product> GetProducts();
        void InsertProduct(Product product);
        void Save();
    }
}