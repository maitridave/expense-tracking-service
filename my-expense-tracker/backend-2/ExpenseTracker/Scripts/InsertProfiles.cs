using System;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Scripts
{
    public class InsertProfiles
    {
        public static void Run(ExpenseTrackerContext context)
        {
            if (!context.Profiles.Any())
            {
                context.Profiles.AddRange(
                    new Profile { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com", Password = "password123" },
                    new Profile { Id = Guid.NewGuid(), Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password123" }
                );
                context.SaveChanges();
            }
        }
    }
}
