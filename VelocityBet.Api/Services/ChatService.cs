using VelocityBet.Application.Interfaces;
using VelocityBet.Domain.Entity.Chat;

namespace VelocityBet.Api.Services
{
	public class ChatService
	{
		List<ChatMessage> _messages;
		public ChatService()
		{
			_messages = new List<ChatMessage>();
		}

		public List<ChatMessage> GetAll()
		{
			return _messages.ToList();
		}
		public void AddMessage(ChatMessage message)
		{
			_messages.Add(message);
		}


	}
}
