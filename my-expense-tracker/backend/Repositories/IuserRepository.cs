using System.Threading.Tasks;
using my_expense_tracker.Models;

namespace my_expense_tracker.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}