using VelocityBet.Domain.Entity.Chat;

namespace VelocityBet.Api.Dto.Chat
{
	public class MessageTransferObject
	{
		public string text { get; set; }
		public int userId { get; set; }
	}
}
