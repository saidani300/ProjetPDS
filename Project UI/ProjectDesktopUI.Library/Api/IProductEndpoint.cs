using DemoProjectDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoProjectDesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}