using System;
using System.Threading.Tasks;
using Harvest.Models;
using Refit;

namespace Harvest.Interfaces
{
    public interface IExpenseCategoriesApi
    {
        [Get("/v2/expense_categories")]
        Task<ExpenseCategoriesContainer> ListAllAsync(
            [AliasAs("is_active")] bool? isActive = null,
            [AliasAs("updated_since")] DateTime? updatedSince = null,
            int? page = null,
            [AliasAs("per_page")] int? perPage = null
        );

        [Get("/v2/expense_categories/{id}")]
        Task<ExpenseCategory> GetAsync(long id);
    }
}