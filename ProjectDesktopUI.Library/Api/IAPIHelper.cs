using DemoProjectDesktopUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoProjectDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }

        Task<AuthenticatedUser> AuthenticateAsync(string username, string password);
        Task GetLoggedInUserInfo(string userId, string token);
        Task<IDModel> LoggedInUserId(string token);
        void LogOffUser();
    }
}