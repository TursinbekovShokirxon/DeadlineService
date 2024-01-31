using Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure
{
	public static class ConfigurationServices
	{
		public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			
			services.AddDbContext<IdentityApplicationDbContext>((sp,opt) =>
			{
				opt.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());
				opt.UseNpgsql(configuration.GetConnectionString("IdentityDatabase"));
			});


		}
	}
}
