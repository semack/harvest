using System.Threading.Tasks;
using Harvest.Models;
using Refit;

namespace Harvest.Interfaces
{
	public interface ICompanyApi
	{
		[Get("/v2/company")]
		Task<Company> GetAsync();
	}
}
