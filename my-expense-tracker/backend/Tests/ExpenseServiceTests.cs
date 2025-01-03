//using System;
//using System.Collections.Generic;
//using Xunit;
//using my_expense_tracker.Services;
//using my_expense_tracker.Models;

//namespace my_expense_tracker.Tests
//{
//    public class ExpenseServiceTests
//    {
//        private readonly ExpenseService _expenseService;

//        public ExpenseServiceTests()
//        {
//            _expenseService = new ExpenseService(new MockExpenseRepository());
//        }

//        [Fact]
//        public void AddExpense_ShouldAddExpense()
//        {
//            var expense = new Expense
//            {
//                Id = 1,
//                Amount = 100,
//                Description = "Test Expense",
//                Date = DateTime.Now,
//                CategoryId = 1
//            };

//            _expenseService.AddExpense(expense);
//            var expenses = _expenseService.GetAllExpenses();

//            Assert.Contains(expense, expenses);
//        }

//        [Fact]
//        public void GetAllExpenses_ShouldReturnAllExpenses()
//        {
//            var expenses = _expenseService.GetAllExpenses();

//            Assert.NotNull(expenses);
//            Assert.IsType<List<Expense>>(expenses);
//        }

//        // Mock repository for testing
//        private class MockExpenseRepository : IExpenseRepository
//        {
//            private readonly List<Expense> _expenses = new List<Expense>();

//            public void AddExpense(Expense expense)
//            {
//                _expenses.Add(expense);
//            }

//            public List<Expense> GetExpensesByUserId(int userId)
//            {
//                return _expenses; // Simplified for testing
//            }
//        }
//    }
//}