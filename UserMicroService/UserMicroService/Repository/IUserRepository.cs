using System.Threading.Tasks;
using UserMicroService.Models;

namespace UserMicroService.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByID(string Id);
    }
}