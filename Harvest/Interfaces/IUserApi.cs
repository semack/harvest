using System;
using System.Threading.Tasks;
using Harvest.Models;
using Refit;

namespace Harvest.Interfaces
{
	public interface IUserApi
	{
		[Get("/v2/users")]
		Task<UsersContainer> ListAllAsync(
			[AliasAs("updated_since")] DateTime? updatedSince = null,
			int? page = null,
			[AliasAs("per_page")] int? perPage = null
		);

		[Get("/v2/users/{id}")]
		Task<User> GetAsync(long id);

		[Get("/v2/users/me")]
		Task<User> GetMeAsync();
	}
}