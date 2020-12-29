using DemoProjectDesktopUI.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoProjectDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> AuthenticateAsync(string username, string password);
        Task GetLoggedInUserInfo(string token);
        HttpClient ApiClient { get; }
        void LogOffUser();
    }
}