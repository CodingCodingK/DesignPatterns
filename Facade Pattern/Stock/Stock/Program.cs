using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
	// 前景提要：
	// 股民自己操作股票容易亏，原因是非专业的股民要面对成千上万的股票。
	// 但是股民买基金比较容易赚钱，原因是股民只要关心基金经理，而不用关心其背后成千上万的股票。
	// 这里实现用户对基金经理操作股票的情况
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			var user = new Fund();
			user.Buy();
			user.Sell();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public class Fund
	{
		private Stock1 s1;
		private Stock2 s2;
		private Realty1 r1;

		public Fund()
		{
			s1 = new Stock1();
			s2 = new Stock2();
			r1 = new Realty1();
		}

		public void Buy()
		{
			s1.Buy();
			s2.Buy();
			r1.Buy();
		}

		public void Sell()
		{
			s1.Sell();
			s2.Sell();
			r1.Sell();
		}
	}




	// 所有投资产品都需要有这两个方法。
	public abstract class Investment
	{
		public abstract void Buy();
		public abstract void Sell();
	}

	public class Stock1 : Investment
	{
		public override void Buy()
		{
			Console.WriteLine("买了股票1");
		}

		public override void Sell()
		{
			Console.WriteLine("卖了股票1");
		}
	}

	public class Stock2 : Investment
	{
		public override void Buy()
		{
			Console.WriteLine("买了股票2");
		}

		public override void Sell()
		{
			Console.WriteLine("卖了股票2");
		}
	}

	public class Realty1 : Investment
	{
		public override void Buy()
		{
			Console.WriteLine("买了房地产1");
		}

		public override void Sell()
		{
			Console.WriteLine("卖了房地产1");
		}
	}
}
