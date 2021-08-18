using System;
using System.Threading.Tasks;
using Harvest.Models;
using Refit;

namespace Harvest.Interfaces
{
    public interface IExpensesApi
    {
        [Get("/v2/expenses")]
        Task<ExpensesContainer> ListAllAsync(
            [AliasAs("user_id")] int? userId = null,
            [AliasAs("client_id")] int? clientId = null,
            [AliasAs("project_id")] int? projectId = null,
            [AliasAs("is_billed")] bool? isBilled = null,
            [AliasAs("updated_since")] DateTime? updatedSince = null,
            DateTime? from = null,
            DateTime? to = null,
            int? page = null,
            [AliasAs("per_page")] int? perPage = null
        );

        [Get("/v2/expenses/{id}")]
        Task<Expense> GetAsync(long id);

        [Post("/v2/expenses")]
        Task<Expense> CreateAsync(CreateExpense info);
    }
}