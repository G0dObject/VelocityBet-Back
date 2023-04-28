namespace VelocityBet.Application.Interfaces.Game
{
	public interface IRound
	{
		public List<IBet> Bets { get; set; }
		public decimal Total { get; set; }
	}
}
