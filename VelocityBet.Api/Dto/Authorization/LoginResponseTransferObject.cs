using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace VelocityBet.Api.Dto.Authorization
{
	public class LoginResponseTransferObject
	{
		public LoginResponseTransferObject(JwtSecurityToken token, string userName, int id)
		{
			Token = new JwtSecurityTokenHandler().WriteToken(token);
			UserName = userName;
			UserId = id;

		}

		public string Token { get; set; }
		public string UserName { get; set; }
		public int UserId { get; set; }


	}
}
