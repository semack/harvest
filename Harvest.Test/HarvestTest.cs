using System.IO;
using System.Reflection;
using Harvest.Test.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit.Abstractions;

namespace Harvest.Test
{
	public class HarvestTest
	{
		protected ILogger Logger { get; }
		protected HarvestClient HarvestClient { get; }
		protected Configuration Configuration { get; }

		protected HarvestTest(ITestOutputHelper iTestOutputHelper)
		{
			Logger = new LoggerFactory()
				.AddDebug(LogLevel.Trace)
				.AddXunit(iTestOutputHelper, LogLevel.Trace)
				.CreateLogger<HarvestTest>();

			Configuration = LoadConfiguration("appsettings.json");
			HarvestClient = new HarvestClient(Configuration.AccountId, Configuration.AccessToken, "http://localhost:8888");
		}

		private static Configuration LoadConfiguration(string jsonFilePath)
		{
			var location = typeof(HarvestTest).GetTypeInfo().Assembly.Location;
			var dirPath = Path.Combine(Path.GetDirectoryName(location), "../../..");

			Configuration configuration;
			var configurationRoot = new ConfigurationBuilder()
				.SetBasePath(dirPath)
				.AddJsonFile(jsonFilePath, false, false)
				.Build();
			var services = new ServiceCollection();
			services.AddOptions();
			services.Configure<Configuration>(configurationRoot);
			using (var sp = services.BuildServiceProvider())
			{
				var options = sp.GetService<IOptions<Configuration>>();
				configuration = options.Value;
			}

			return configuration;
		}
	}
}