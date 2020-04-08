using System;
using Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
	public static class SettingsConfiguration
	{
		public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			var serviceSettings = new ServiceSettings();

			configuration.Bind("ServiceSettings", serviceSettings);
			services.AddSingleton(serviceSettings);

			return services;
		}
	}
}
