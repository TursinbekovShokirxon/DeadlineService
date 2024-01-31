using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Identity.Application
{
	public static class ApplicationServices
	{
		public static void AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
		{
			//JWT
			services.AddAuthentication();
			
			
			services.AddAuthorization();
		}
	}
}
