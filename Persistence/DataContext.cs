using Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Persistence
{
	public class DataContext : DbContext
	{
		public DataContext([NotNull] DbContextOptions options) : base(options)
		{
		}

		public DbSet<Activity> Activities { get; set; }
	}
}
