using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Data
{
	public class IdentityApplicationDbContext:IdentityDbContext
	{


        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options):base(options) { }
        
            
        
    }
}
