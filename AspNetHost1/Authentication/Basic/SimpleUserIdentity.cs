using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Nancy.Security;

namespace TestNancy.Authentication.Basic
{
	public class SimpleUserIdentity : IUserIdentity
	{
		public SimpleUserIdentity(string userName)
		{
			UserName = userName;
		}

		//public IEnumerable<string> Claims => throw new NotImplementedException();

		public string UserName { get; }
	    public IEnumerable<string> Claims { get; }
	}
}
