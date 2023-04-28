using Microsoft.EntityFrameworkCore;
using VelocityBet.Domain.Entity.Authorize;

namespace VelocityBet.Application.Interfaces
{
	public interface IContext : IDisposable
	{
		DbSet<User> Users { get; set; }
	}
}
