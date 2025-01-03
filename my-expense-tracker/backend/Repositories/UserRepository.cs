using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_expense_tracker.Models;

namespace my_expense_tracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == userId));
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Username == username));
        }

        public Task AddUserAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }
    }
}