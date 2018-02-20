using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Nancy.Authentication.Basic;
using Nancy.Security;

namespace TestNancy.Authentication.Basic
{
	public class UserValidator : IUserValidator
	{
		public IUserIdentity Validate(string username, string password)
		{
			if (IsAuthenticatedUser(username, password))
			{
				return new SimpleUserIdentity(username);
			}

			// Not recognised => anonymous.
			return null;
		}

		private static bool IsAuthenticatedUser(string username, string password)
		{
			// Replace this with call to next API to authenticate credentials
			return username == "myUsername" && password == "myPassword";
		}
	}
}
