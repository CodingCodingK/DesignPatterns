using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Factory
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("Give me Strategy Name.");
				var input = Console.ReadLine();
				Console.WriteLine("Give me Single Money.");
				var money = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Give me Num.");
				var num = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine(new Context(input).GetResult(money, num));
			}
		}
	}

	public class Context
	{
		private Strategy strategy =  new DefaultStrategy();

		#region Simple Factory Pattern(也许可以换成反射)
		public Context(string strategyName)
		{
			switch (strategyName)
			{
				case "Default":
					strategy = new DefaultStrategy();
					break;
				case "Rebate":
					// 此处假设打折就是打八折
					strategy = new RebateStrategy(0.8f);
					break;
				case "Return":
					// 此处假设满减就是满300减100
					strategy = new ReturnStrategy(300f, 100f);
					break;
			}
		}
		#endregion

		public double GetResult(double money, double num)
		{
			// 简单演示，不将num设为int
			return strategy.CashReturn( money, num);
		}
	}

	public abstract class Strategy
	{
		public abstract double CashReturn(double moneny, double num);
	}

	public class DefaultStrategy : Strategy
	{
		public override double CashReturn(double moneny, double num)
		{
			return moneny * num;
		}
	}

	public class RebateStrategy : Strategy
	{
		private double rebate;

		public RebateStrategy(double rebateInputed)
		{
			this.rebate = rebateInputed;
		}

		public override double CashReturn(double moneny, double num)
		{
			return moneny * num * rebate;
		}
	}

	public class ReturnStrategy : Strategy
	{
		private double targetMoney;
		private double returnMoney;
		public ReturnStrategy(double t, double r)
		{
			this.targetMoney = t;
			this.returnMoney = r;
		}

		public override double CashReturn(double moneny, double num)
		{
			return moneny * num- (double)(Math.Floor(moneny * num / targetMoney) * returnMoney);
		}
	}


}
