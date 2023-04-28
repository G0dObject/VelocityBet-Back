using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using VelocityBet.Api.Dto.Chat;
using VelocityBet.Api.Services;
using VelocityBet.Domain.Entity.Authorize;
using VelocityBet.Domain.Entity.Chat;

namespace VelocityBet.Api.Hubs
{
	public class ChatHub : Hub
	{
		private readonly ChatService _chatService;
		private readonly UserManager<User> _userManager;
		public ChatHub(ChatService chatService, UserManager<User> userManager)
		{
			_chatService = chatService;
			_userManager = userManager;
		}
		public async Task SendMessage(MessageTransferObject message)
		{
			User? user = await _userManager.FindByIdAsync(message.userId.ToString());
			ChatMessage chatmessage = new ChatMessage
			{
				Text = message.text,
				Time = DateTime.Now.ToString("HH:mm"),
				User = new ChatUser() { Exp = user.Exp, ImgUrl = user.ImgUrl, Level = user.Level, Name = user.UserName, Role = "User" }
			};
			_chatService.AddMessage(chatmessage);
			await Clients.All.SendAsync("Message", chatmessage);
		}
	}

}

