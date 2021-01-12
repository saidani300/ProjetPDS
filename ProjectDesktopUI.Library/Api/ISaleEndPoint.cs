using DemoProjectDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace DemoProjectDesktopUI.Library.Api
{
    public interface ISaleEndPoint
    {
        Task PostSale(SaleModel sale);
    }
}