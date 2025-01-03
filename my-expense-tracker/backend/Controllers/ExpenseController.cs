using Microsoft.AspNetCore.Mvc;
using my_expense_tracker.Models;
using my_expense_tracker.Services;
using System.Collections.Generic;

namespace my_expense_tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetExpenses(int userId)
        {
            var expenses = _expenseService.GetAllExpenses(userId);
            return Ok(expenses);
        }

        [HttpGet]
        [Route("categories")]
        public ActionResult<IEnumerable<ExpenseCategory>> GetExpenseCategories()
        {
            var categories = _expenseService.GetExpenseCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Expense> GetExpenseById(int id)
        {
            var expense = _expenseService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public ActionResult AddExpense([FromBody] Expense expense)
        {
            _expenseService.AddExpense(expense);
            return CreatedAtAction(nameof(GetExpenseById), new { id = expense.Id }, expense);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateExpense(int id, [FromBody] Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _expenseService.UpdateExpense(expense);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExpense(int id)
        {
            _expenseService.DeleteExpense(id);
            return NoContent();
        }
    }
}