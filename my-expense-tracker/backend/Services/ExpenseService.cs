using System;
using System.Collections.Generic;
using System.Linq;
using my_expense_tracker.Models;
using my_expense_tracker.Repositories;

namespace my_expense_tracker.Services
{
    public class ExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public void AddExpense(Expense expense)
        {
            _expenseRepository.AddExpense(expense);
        }

        public IEnumerable<Expense> GetAllExpenses(int userId)
        {
            return _expenseRepository.GetExpensesByUserId(userId);
        }

        public IEnumerable<ExpenseCategory> GetExpenseCategories()
        {
            return _expenseRepository.GetExpenseCategories();
        }

        public Expense GetExpenseById(int expenseId)
        {
            return _expenseRepository.GetExpenseById(expenseId);
        }

        public void UpdateExpense(Expense expense)
        {
            _expenseRepository.UpdateExpense(expense);
        }

        public void DeleteExpense(int expenseId)
        {
            _expenseRepository.DeleteExpense(expenseId);
        }
    }
}