using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetHost1.Models;
using TestNancy.Models;

namespace TestNancy.Processing.Implementation
{
	public class RandomMessageGenerator : IMessageGenerator
	{
		private const int Type = 0;

		private static readonly Random _random = new Random();

		public Message Generate(string[] messageArgs)
		{
			return new Message(GetRandomString(_random.Next(16, 32)), Type);
		}

		private string GetRandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			const string explanation = " - a random message serving no point apart from testing our Dependency Injection registrations in the Bootstrapper";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[_random.Next(s.Length)]).ToArray()) + explanation;
		}
	}
}
