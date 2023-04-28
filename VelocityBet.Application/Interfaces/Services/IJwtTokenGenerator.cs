using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace VelocityBet.Application.Interfaces.Services
{
	public interface IJwtTokenGenerator
	{
		public JwtSecurityToken GenerateJwtToken(List<Claim> authClaims);
	}
}
