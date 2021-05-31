using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberAndPublisher
{
	public delegate void TestHandler(string q);
	class Program
	{
		static void Main(string[] args)
		{

			var x = new Test();
			x.TestMethod += (string q) =>
			{
				Console.WriteLine(q);
			};
		}
	}

	public class Test
	{
		public event TestHandler TestMethod;
	}

}
