using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLover
{
	public class Program
	{
		static void Main(string[] args)
		{
			#region UTF8

			Console.OutputEncoding = Encoding.UTF8;

			#endregion

			var schoolGril = new Girl("Susan");

			Proxy proxy = new Proxy(schoolGril);
			proxy.GiveDolls();
			proxy.GiveFlowers();
			proxy.GiveMoney();

			#region Test
			
			Console.Read();

			#endregion
		}
	}

	public class Girl
	{
		public string Name;

		public Girl(string n)
		{
			Name = n;
		}
	}

	public interface IGiveGirft
	{
		void GiveDolls();
		void GiveFlowers();
		void GiveMoney();
	}

	public class Pursuit:IGiveGirft
	{
		private Girl lover;

		public Pursuit(Girl g)
		{
			lover = g;
		}

		public void GiveDolls()
		{
			Console.WriteLine("「追求者」对{0}送出了娃娃", lover.Name);
		}

		public void GiveFlowers()
		{
			Console.WriteLine("「追求者」对{0}送出了花朵", lover.Name);
		}

		public void GiveMoney()
		{
			Console.WriteLine("「追求者」对{0}送出了钱", lover.Name);
		}
	}

	public class Proxy : IGiveGirft
	{
		// 放入本体
		private Pursuit pursuit;

		public Proxy(Girl g)
		{
			pursuit = new Pursuit(g);
		}

		public void GiveDolls()
		{
			pursuit.GiveDolls();
		}

		public void GiveFlowers()
		{
			pursuit.GiveFlowers();
		}

		public void GiveMoney()
		{
			pursuit.GiveMoney();
		}
	}

}
