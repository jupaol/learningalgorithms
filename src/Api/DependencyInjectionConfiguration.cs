using System;
using Core.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
	public static class DependencyInjectionConfiguration
	{
		public static IServiceCollection InjectServices(
			this IServiceCollection services, IConfiguration configuration)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			if (configuration == null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			services.Scan(scan =>
				scan
					.FromAssembliesOf(
						typeof(Startup),
						typeof(Core.DependencyInjectionHook),
						typeof(Infrastructure.DependencyInjectionHook))
					.AddClasses(x => x
						.WithoutAttribute<TransientLifetimeAttribute>()
						.WithoutAttribute<SingletonLifetimeAttribute>()
						.WithoutAttribute<ManualContainerInjectionAttribute>())
					.AsImplementedInterfaces()
					.WithScopedLifetime()

					.AddClasses(x => x
						.WithAttribute<TransientLifetimeAttribute>()
						.WithoutAttribute<ManualContainerInjectionAttribute>())
					.AsImplementedInterfaces()
					.WithTransientLifetime()

					.AddClasses(x => x
						.WithAttribute<SingletonLifetimeAttribute>()
						.WithoutAttribute<ManualContainerInjectionAttribute>())
					.AsImplementedInterfaces()
					.WithSingletonLifetime());

			// Example to add an EF context.
			////services.AddDbContext<PortfolioEngineContext>(
			////	o => o
			////		.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
			////		.UseSqlServer(configuration.GetConnectionString("PortfolioEngine")));

			return services;
		}
	}
}
