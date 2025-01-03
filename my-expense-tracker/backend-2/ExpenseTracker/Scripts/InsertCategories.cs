using System;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Scripts
{
    public class InsertCategories
    {
        public static void Run(ExpenseTrackerContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Id = Guid.NewGuid(), Name = "Food" },
                    new Category { Id = Guid.NewGuid(), Name = "Transport" },
                    new Category { Id = Guid.NewGuid(), Name = "Utilities" },
                    new Category { Id = Guid.NewGuid(), Name = "Entertainment" }
                );
                context.SaveChanges();
            }
        }
    }
}
