using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Threading.Tasks;

namespace API
{
	public class Program
	{
		public async static Task Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using IServiceScope scope = host.Services.CreateScope();

			IServiceProvider services = scope.ServiceProvider;

			try
			{
				DataContext context = services.GetRequiredService<DataContext>();
				UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();
				context.Database.Migrate();
				await Seed.SeedData(context, userManager);
			}
			catch (Exception ex)
			{
				var logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError(ex, "An error occured during migration");
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
