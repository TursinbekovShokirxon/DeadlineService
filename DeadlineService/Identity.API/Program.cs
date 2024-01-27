
using Identity.Domain.Entitys;
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

			builder.Services.AddDbContext<IdentityApplicationDbContext>(opt =>
			{
				opt.UseNpgsql(builder.Configuration.GetConnectionString("IdentityDatabase"));
			});

			builder.Services.AddAuthorization();

			builder.Services.AddIdentity<ApplicationUser, Role>(options =>
			{
				// ����� ������������� ��������
				options.SignIn.RequireConfirmedAccount = false; // ��������� ������������� ��������

				// ����� ������
				options.Password.RequireDigit = true;         // ��������� ���� �� ���� �����
				options.Password.RequireLowercase = true;     // ��������� ���� �� ���� �������� �����
				options.Password.RequireUppercase = true;     // ��������� ���� �� ���� ��������� �����
				options.Password.RequireNonAlphanumeric = false; // ��������� ���� �� ���� ����������
				options.Password.RequiredLength = 8;           // ����������� ����� ������

				// ����� ����������
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); // ����� ���������� ����� ��������� �������
				options.Lockout.MaxFailedAccessAttempts = 5;  // ������������ ���������� ��������� �������

				// ����� ���������������� ����������
				options.User.RequireUniqueEmail = true;       // ��������� ���������� email

			})
			.AddEntityFrameworkStores<IdentityApplicationDbContext>()
			.AddDefaultTokenProviders();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
