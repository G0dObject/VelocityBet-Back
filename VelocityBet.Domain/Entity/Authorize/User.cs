using Microsoft.AspNetCore.Identity;

namespace VelocityBet.Domain.Entity.Authorize
{
	public class User : IdentityUser<int>
	{
		public string? ImgUrl { get; set; }
		public int Level { get; set; }
		public int Exp { get; set; }
	}
}
