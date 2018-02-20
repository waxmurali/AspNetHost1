using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetHost1.Models;
using TestNancy.Models;

namespace TestNancy.Processing
{
	public interface IMessageGenerator
	{
		Message Generate(string[] messageArgs);
	}
}
