using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

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
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("lalsdhfkjsdslalsdhfkjsdslalsdhfkjsds"); // Replace with your secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "AIWarriors", // Replace with your issuer
                Audience = "AIWarriors", // Replace with your audience
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
