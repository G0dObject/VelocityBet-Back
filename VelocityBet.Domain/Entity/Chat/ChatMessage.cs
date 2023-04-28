using VelocityBet.Domain.Entity.Authorize;

namespace VelocityBet.Domain.Entity.Chat
{
	public class ChatMessage
	{
		public string Text { get; set; }
		public string Time { get; set; }
		public ChatUser User { get; set; }
	}
}
