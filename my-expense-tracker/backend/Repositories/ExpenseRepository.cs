using System.Collections.Generic;
using System.Linq;
using my_expense_tracker.Models;

namespace my_expense_tracker.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly List<Expense> _expenses;
        private readonly List<ExpenseCategory> _categories;

        public ExpenseRepository()
        {
            _expenses = new List<Expense>();
            _categories = new List<ExpenseCategory>();
        }

        public void AddExpense(Expense expense)
        {
            _expenses.Add(expense);
        }

        public void UpdateExpense(Expense expense)
        {
            var existingExpense = _expenses.FirstOrDefault(e => e.Id == expense.Id);
            if (existingExpense != null)
            {
                existingExpense.Amount = expense.Amount;
                existingExpense.Description = expense.Description;
                existingExpense.CategoryId = expense.CategoryId;
                existingExpense.Date = expense.Date;
                existingExpense.LastModifiedBy = expense.LastModifiedBy;
                existingExpense.LastModifiedAt = expense.LastModifiedAt;
            }
        }

        public void DeleteExpense(int expenseId)
        {
            var expense = _expenses.FirstOrDefault(e => e.Id == expenseId);
            if (expense != null)
            {
                _expenses.Remove(expense);
            }
        }

        public Expense GetExpenseById(int expenseId)
        {
            return _expenses.FirstOrDefault(e => e.Id == expenseId);
        }

        public IEnumerable<Expense> GetExpensesByUserId(int userId)
        {
            return _expenses.Where(e => e.CreatedBy == userId).ToList();
        }

        public IEnumerable<ExpenseCategory> GetExpenseCategories()
        {
            return _categories;
        }
    }
}