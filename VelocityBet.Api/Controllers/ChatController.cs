using Microsoft.AspNetCore.Mvc;
using VelocityBet.Api.Services;
using VelocityBet.Domain.Entity.Chat;

namespace VelocityBet.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChatController : ControllerBase
	{
		private ChatService _chatservice;
		public ChatController(ChatService chatService)
		{
			_chatservice = chatService;
		}

		[HttpGet]
		[Route("Message")]
		public List<ChatMessage> GetAllMessage()
		{
			return _chatservice.GetAll();
		}




	}
}
