using System;
using System.IO;
using Api.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Api
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			string currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			IConfigurationBuilder configBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", false, reloadOnChange: true);

			if (currentEnvironment?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
			{
				configBuilder.AddJsonFile($"appsettings.{currentEnvironment}.json", optional: false);
			}

			IConfigurationRoot config = configBuilder.Build();
			LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
			Logger logger = LogManager.GetCurrentClassLogger();

			try
			{
				logger.Info($"{GlobalSettings.FriendlyServiceName} starts running...");

				CreateWebHostBuilder(args).Build().Run();

				logger.Info($"{GlobalSettings.FriendlyServiceName} is stopped");
			}
			catch (Exception exception)
			{
				logger.Error(exception);

				throw;
			}
			finally
			{
				LogManager.Shutdown();
			}
		}

		public static IHostBuilder CreateWebHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(
					webBuilder =>
					{
						webBuilder.UseStartup<Startup>()
							.ConfigureLogging(
								logging =>
								{
									logging.ClearProviders();
									logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
								})
							.UseNLog();
					});
		}
	}
}
