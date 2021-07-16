using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Persistance
{
	public class DataContext : DbContext
    {
		public DataContext([NotNull] DbContextOptions options) : base(options)
		{
		}

		public DbSet<Activity> Activities { get; set; }
	}
}
