
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VelocityBet.Api.Dto.Authorization;
using VelocityBet.Application.Interfaces;
using VelocityBet.Application.Interfaces.Services;
using VelocityBet.Domain.Entity.Authorize;

namespace VelocityBet.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly IContext _context;
		private readonly UserManager<User> _userManager;
		public LoginController(IJwtTokenGenerator jwtTokenGenerator, IContext context, UserManager<User> userManager)
		{
			_jwtTokenGenerator = jwtTokenGenerator;
			_context = context;
			_userManager = userManager;
		}

		[HttpPost]
		[Route("Login")]
		public async Task<object> Login([FromBody] LoginTransferObject model)
		{
			User? user = await _userManager.FindByEmailAsync(model.Email);

			if (user != null)
			{
				bool currect = await _userManager.CheckPasswordAsync(user, model.Password);

				if (currect)
				{
					List<Claim> authClaims = new()
					{
						new Claim(ClaimTypes.Name, user.UserName),
						new Claim(ClaimTypes.NameIdentifier.ToString(), user.Id.ToString())
					};

					JwtSecurityToken? token = _jwtTokenGenerator.GenerateJwtToken(authClaims);

					return new LoginResponseTransferObject(token, user.UserName, user.Id);
				}
			}
			return StatusCode(401);
		}
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterTransferObject model)
		{
			User userExists = await _userManager.FindByEmailAsync(model.Email);
			if (userExists != null)
			{
				return StatusCode(StatusCodes.Status409Conflict, "Alredy exist");
			}

			User user = new()
			{
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.Username
			};
			IdentityResult result = await _userManager.CreateAsync(user, model.Password);
			return !result.Succeeded
				? StatusCode(StatusCodes.Status400BadRequest, "Create Failed")
				: Ok("User created successfully!");
		}
		[HttpGet]
		[Route("Test")]
		[Authorize]
		public string Test()
		{
			return "Ok";
		}
	}
}
