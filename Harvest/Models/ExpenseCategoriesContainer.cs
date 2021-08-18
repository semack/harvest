using System.Collections.Generic;

namespace Harvest.Models
{
	public class ExpenseCategoriesContainer : ListContainerBase
	{
		public List<ExpenseCategory> ExpenseCategories { get; set; }
	}
}
