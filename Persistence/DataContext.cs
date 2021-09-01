using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Persistence
{
	public class DataContext : IdentityDbContext<AppUser>
	{
		public DataContext([NotNull] DbContextOptions options) : base(options)
		{
		}

		public DbSet<Activity> Activities { get; set; }
	}
}
