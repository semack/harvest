using System.Collections.Generic;

namespace Harvest.Models
{
    public class ExpensesContainer : ListContainerBase
    {
        public List<Expense> Expenses { get; set; }
    }
}