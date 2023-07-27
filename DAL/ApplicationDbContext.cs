using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Board> Boards { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
		public DbSet<Sprint> Sprints { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BaseCamp;Trusted_Connection=True;MultipleActiveResultSets=True";
			
			// Configure your database connection here.
			optionsBuilder.UseSqlServer(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Declare the entity type as keyless
			modelBuilder.Entity<List<string>>().HasNoKey();
		}
	}
}
