using System;
using System.Threading.Tasks;
using Harvest.Models;
using Refit;

namespace Harvest.Interfaces
{
	public interface IClientApi
	{
		[Get("/v2/clients")]
		Task<ClientsContainer> ListAllAsync(
			[AliasAs("updated_since")] DateTime? updatedSince = null,
			int? page = null,
			[AliasAs("per_page")] int? perPage = null
		);

		[Get("/v2/clients/{id}")]
		Task<Client> GetAsync(long id);
	}
}