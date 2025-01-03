using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExpenseTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly ExpenseTrackerContext _context;

        public AuthService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task<bool> SignInAsync(string email, string password, bool rememberMe)
        {
            var user = await _context.Profiles.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user != null;
        }
    }
}
