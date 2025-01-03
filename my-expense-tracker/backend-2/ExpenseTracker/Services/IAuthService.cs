using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string email, string password, bool rememberMe);
    }
}