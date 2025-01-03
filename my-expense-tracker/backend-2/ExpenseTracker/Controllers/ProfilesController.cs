using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly ExpenseTrackerContext _context;

        public ProfilesController(ExpenseTrackerContext context)
        {
            _context = context;
        }

        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<Profile>> GetProfile()
        {
            var userId = new Guid(User.Identity.Name);
            var profile = await _context.Profiles.FindAsync(userId);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // PUT: api/Profiles
        [HttpPut]
        public async Task<IActionResult> PutProfile(Profile profile)
        {
            var userId = new Guid(User.Identity.Name);
            if (userId != profile.Id)
            {
                return BadRequest();
            }

            profile.UpdatedAt = DateTime.UtcNow;
            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ProfileExists(Guid id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
