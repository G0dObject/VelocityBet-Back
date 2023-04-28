using Microsoft.AspNetCore.Identity;
using VelocityBet.Domain.Entity.Authorize;
using VelocityBet.Persistence;

namespace VelocityBet.Api.DependencyInjection
{
	public static class IdentityDependencyInjection
	{
		public static IServiceCollection AddIdentityDependency(this IServiceCollection services)
		{
			IdentityBuilder? builder = services.AddIdentity<User, Role>(option =>
			{
				option.User.RequireUniqueEmail = true;

				option.Stores.MaxLengthForKeys = 128;

				option.Password.RequireUppercase = false;
				option.Password.RequireNonAlphanumeric = false;
				option.Password.RequireDigit = false;

				option.SignIn.RequireConfirmedPhoneNumber = false;
				option.SignIn.RequireConfirmedEmail = false;
				option.SignIn.RequireConfirmedAccount = false;
			}).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

			return services;
		}
	}
}
