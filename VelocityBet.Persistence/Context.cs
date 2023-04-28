using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VelocityBet.Application.Interfaces;
using VelocityBet.Domain.Entity.Authorize;

namespace VelocityBet.Persistence
{
	public class Context : IdentityDbContext<User, Role, int>, IContext
	{
		public Context()
		{
			_ = Database.EnsureCreated();
		}


		DbSet<User> IContext.Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			_ = optionsBuilder.UseSqlite("Data Source=Api.db");
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}