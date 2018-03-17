using Xunit;
using Xunit.Abstractions;

namespace Harvest.Test
{
	public class ClientTests : HarvestTest
	{
		public ClientTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
			
		}

		[Fact]
		public async void GetAllClients()
		{
			//var _ = await HarvestClient.Clients.ListAllAsync();
		}
	}
}
