using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.CustomeValidate
{
	public class UniqueUsernameValidator<TUser> : IUserValidator<TUser> where TUser : class
	{
		public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
		{
			var userName = manager.GetUserNameAsync(user).Result;

			var existingUser = await manager.FindByNameAsync(userName);

			if (existingUser != null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "This username is already taken." });
			}

			return IdentityResult.Success;
		}
	}
}
