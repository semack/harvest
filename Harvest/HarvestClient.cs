using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using Harvest.ContractResolvers;
using Harvest.Interfaces;
using Newtonsoft.Json;
using Refit;

namespace Harvest
{
	public class HarvestClient : IHarvestClient, IDisposable
	{
		private readonly HttpClient _httpClient;

		public HarvestClient(int accountId, string accessToken)
		{
			var refitSettings = new RefitSettings
			{
				JsonSerializerSettings = new JsonSerializerSettings
				{
					ContractResolver = new SnakeCaseContractResolver()
				}
			};

			_httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://api.harvestapp.com"),
				DefaultRequestHeaders =
				{
					Authorization = new AuthenticationHeaderValue("Bearer", accessToken),
					UserAgent =
					{
						new ProductInfoHeaderValue("harvest.net", Assembly.GetExecutingAssembly().GetName().Version.ToString())
					}
				}
			};

			_httpClient.DefaultRequestHeaders.Add("Harvest-Account-Id", accountId.ToString());

			Companies = RestService.For<ICompanyApi>(_httpClient, refitSettings);
			Clients = RestService.For<IClientApi>(_httpClient, refitSettings);
			TimeEntries = RestService.For<ITimeEntryApi>(_httpClient, refitSettings);
			Projects = RestService.For<IProjectApi>(_httpClient, refitSettings);
			Tasks = RestService.For<ITaskApi>(_httpClient, refitSettings);
			ProjectTaskAssignments = RestService.For<IProjectTaskAssignmentApi>(_httpClient, refitSettings);
			Users = RestService.For<IUserApi>(_httpClient, refitSettings);
			UserProjectAssignments = RestService.For<IUserProjectAssignmentApi>(_httpClient, refitSettings);
		}

		/// <summary>
		/// Clients
		/// </summary>
		public IClientApi Clients { get; }

		/// <summary>
		/// Clients
		/// </summary>
		public ICompanyApi Companies { get; }

		/// <summary>
		/// TimeEntries
		/// </summary>
		public ITimeEntryApi TimeEntries { get; }

		/// <summary>
		/// Projects
		/// </summary>
		public IProjectApi Projects { get; }

		/// <summary>
		/// ProjectTaskAssignments
		/// </summary>
		public IProjectTaskAssignmentApi ProjectTaskAssignments { get; }

		/// <summary>
		/// Users
		/// </summary>
		public IUserApi Users { get; }

		/// <summary>
		/// User project assignments
		/// </summary>
		public IUserProjectAssignmentApi UserProjectAssignments { get; }

		/// <summary>
		/// Tasks
		/// </summary>
		public ITaskApi Tasks { get; }

		public void Dispose()
		{
			_httpClient.Dispose();
		}
	}
}