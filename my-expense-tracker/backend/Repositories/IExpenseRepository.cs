using System.Collections.Generic;
using my_expense_tracker.Models;

namespace my_expense_tracker.Repositories
{
    public interface IExpenseRepository
    {
        void AddExpense(Expense expense);
        void UpdateExpense(Expense expense);
        void DeleteExpense(int expenseId);
        Expense GetExpenseById(int expenseId);
        IEnumerable<Expense> GetExpensesByUserId(int userId);
        IEnumerable<ExpenseCategory> GetExpenseCategories();
    }
}