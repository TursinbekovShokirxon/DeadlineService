
using Identity.Application;
using Identity.Application.CustomeValidate;
using Identity.Domain.Entitys;
using Identity.Infrastructure;
using Identity.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddApplicationServices(builder.Configuration);

			builder.Services.AddInfrastructureServices(builder.Configuration);

			builder.Services.AddIdentity<ApplicationUser, Role>(options =>
			{
				// Опции подтверждения аккаунта
				options.SignIn.RequireConfirmedAccount = false; // Требовать подтверждение аккаунта

				// Опции пароля
				options.Password.RequireDigit = true;         // Требовать хотя бы одну цифру
				options.Password.RequireLowercase = true;     // Требовать хотя бы одну строчную букву
				options.Password.RequireUppercase = true;     // Требовать хотя бы одну заглавную букву
				options.Password.RequireNonAlphanumeric = false; // Требовать хотя бы один спецсимвол
				options.Password.RequiredLength = 8;           // Минимальная длина пароля

				// Опции блокировки
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); // Время блокировки после неудачных попыток
				options.Lockout.MaxFailedAccessAttempts = 5;  // Максимальное количество неудачных попыток

				// Опции пользовательских требований
				options.User.RequireUniqueEmail = true;       // Требовать уникальный email

			})
			.AddEntityFrameworkStores<IdentityApplicationDbContext>()
			.AddDefaultTokenProviders()
			.AddUserValidator<UniqueUsernameValidator<ApplicationUser>>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
