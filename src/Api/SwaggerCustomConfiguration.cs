﻿using System;
using System.IO;
using Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api
{
	public static class SwaggerCustomConfiguration
	{
		public static IApplicationBuilder ConfigureSwagger(
			this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
		{
			if (app == null)
			{
				throw new ArgumentNullException(nameof(app));
			}

			app.UseSwagger(
				options => options.RouteTemplate = $"swagger/{GlobalSettings.ServiceName}/{{documentName}}/swagger.json");
			app.UseSwaggerUI(
				options =>
				{
					options.RoutePrefix = $"swagger/{GlobalSettings.ServiceName}";

					// build a swagger endpoint for each discovered API version
					foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
					{
						options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
					}
				});

			return app;
		}

		public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			services.AddVersionedApiExplorer(options =>
			{
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});
			services.AddApiVersioning(options =>
			{
				options.ReportApiVersions = true;
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
			});

			services.AddSwaggerGen(
				options =>
				{
					options.EnableAnnotations();

					IApiVersionDescriptionProvider provider =
						services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

					foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
					{
						options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
					}

					string xmlFile = $"{typeof(SwaggerCustomConfiguration).Assembly.GetName().Name}.xml";

					options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
					options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");
				});

			return services;
		}

		private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
		{
			string serviceDescription = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "ServiceDescription.md"));
			var info = new OpenApiInfo
			{
				Title = $"{GlobalSettings.FriendlyServiceName} API {description.ApiVersion}",
				Version = description.ApiVersion.ToString(),
				Description = serviceDescription,
			};

			if (description.IsDeprecated)
			{
				info.Description += $"{Environment.NewLine} This API version has been deprecated.";
			}

			return info;
		}
	}
}
