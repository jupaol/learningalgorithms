using Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration) => Configuration = configuration;

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.ConfigureSettings(Configuration);
			services.InjectServices(Configuration);

			services.AddDistributedMemoryCache();
			services.AddHttpContextAccessor();
			////services.AddMvcCore().AddJsonFormatters(f => f.Converters.Add(new StringEnumConverter()));

			services.ConfigureSwagger();
		}

#pragma warning disable S3242 // Method parameters should be declared with base types
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
#pragma warning restore S3242 // Method parameters should be declared with base types
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseHttpCodeAndLogMiddleware();
			}
			else
			{
				app.UseHttpCodeAndLogMiddleware();
				app.UseHsts();
			}

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
			});

			app.UseStaticFiles();
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
			app.ConfigureSwagger(provider);
		}
	}
}
