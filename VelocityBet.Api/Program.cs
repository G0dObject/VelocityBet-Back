using VelocityBet.Api.DependencyInjection;
using VelocityBet.Api.Hubs;
using VelocityBet.Api.Services;
using VelocityBet.Application.Interfaces;
using VelocityBet.Application.Interfaces.Services;
using VelocityBet.Persistence;

namespace VelocityBet.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			_ = builder.Services.AddControllers();
			_ = builder.Services.AddEndpointsApiExplorer();
			_ = builder.Services.AddSwaggerGen();
			_ = builder.Services.AddSignalRCore();
			_ = builder.Services.AddDbContext<IContext, Context>();
			_ = builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
			_ = builder.Services.AddSingleton<ChatService>();
			_ = builder.Services.AddIdentityDependency();
			_ = builder.Services.AddAuthenticationDependency(builder.Configuration);
			_ = builder.Services.AddSignalR();
			_ = builder.Services.AddCors(options =>
			{
				options.AddPolicy("ClientPermission", policy =>
				{
					policy.AllowAnyHeader()
						.AllowAnyMethod()
						.WithOrigins("https://localhost:3000")
						.AllowCredentials();
				});
			});
			WebApplication app = builder.Build();
			if (app.Environment.IsDevelopment())
			{
				_ = app.UseSwagger();
				_ = app.UseSwaggerUI();
			}
			app.UseCors("ClientPermission");
			app.MapHub<ChatHub>("/Chat");
			_ = app.UseHttpsRedirection();
			_ = app.UseAuthorization();

			_ = app.MapControllers();
			app.Run();
		}
	}
}