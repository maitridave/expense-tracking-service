using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string email, string password, bool rememberMe);
        Task<bool> SignUpAsync(string name, string email, string password);
    }
}
