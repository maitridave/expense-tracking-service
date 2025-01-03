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

        public async Task<(bool, Profile, string)> SignInAsync(string email, string password, bool rememberMe)
        {
            var user = await _context.Profiles.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                var token = GenerateToken(user);
                return (true, user, token);
            }
            return (false, null, null);
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            if (await _context.Profiles.AnyAsync(u => u.Email == email))
            {
                return false; // User already exists
            }

            var user = new Profile
            {
                Email = email,
                Password = password
            };

            _context.Profiles.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignUpAsync(string name, string email, string password)
        {
            if (await _context.Profiles.AnyAsync(u => u.Email == email))
            {
                return false; // User already exists
            }

            var user = new Profile
            {
                Email = email,
                Password = password,
                Name = name
            };

            _context.Profiles.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        private string GenerateToken(Profile user)
        {
            // Token generation logic here
            return "generated_token";
        }
    }
}
