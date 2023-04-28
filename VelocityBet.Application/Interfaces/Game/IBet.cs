using VelocityBet.Domain.Entity.Authorize;

namespace VelocityBet.Application.Interfaces.Game
{
	public interface IBet
	{
		public decimal Staked { get; set; }
		public decimal Ratio { get; set; }
		public User User { get; set; }
	}
}