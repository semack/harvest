using System;

namespace Harvest.Models
{
    public class Expense
    {
        public long Id { get; set; }
        public string Notes { get; set; }
        public double TotalCost { get; set; }
        public double Units { get; set; }
        public bool IsClosed { get; set; }
        public bool IsLocked { get; set; }
        public bool IsBilled { get; set; }
        public string LockedReason { get; set; }
        public string SpentDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Billable { get; set; }
        public Receipt Receipt { get; set; }
        public User User { get; set; }
        public UserAssignment UserAssignment { get; set; }
        public Project Project { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public Client Client { get; set; }
        public Invoice Invoice { get; set; }
    }

    // https://help.getharvest.com/api-v2/expenses-api/expenses/expenses/
    public class CreateExpense
    {
        public long? UserId { get; set; }
        public long ProjectId { get; set; }
        public long ExpenseCategoryId { get; set; }
        public DateTime SpentDate { get; set; }
        public double? TotalCost { get; set; }
        public double? Units { get; set; }
        public string Notes { get; set; }
        public bool? Billable { get; set; }
        public string Receipt { get; set; }
        // TODO: receipt	file	optional	A receipt file to attach to the expense. If including a receipt, you must submit a multipart/form-data request.
    }
}