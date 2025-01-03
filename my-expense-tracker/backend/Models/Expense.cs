using System;

namespace my_expense_tracker.Models;
public class Expense : BaseEntity
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int CategoryId { get; set; }
}