using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeCoffee
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			MakeCoffee A = new CoffeMakerA();
			A.DoMakeCoffee();
			MakeCoffee B = new CoffeMakerB();
			B.DoMakeCoffee();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public abstract class MakeCoffee
	{
		protected abstract void ShowCoffeeMakerName();
		protected abstract void PourCoffeePowder();
		protected abstract void PourWater();
		protected abstract void Mix();

		// 核心部分，将的固定行为抽成一个模板，而行为的每个流程的具体实现交给子类来定义。
		public void DoMakeCoffee()
		{
			// 展示制作咖啡的咖啡师名
			ShowCoffeeMakerName();
			// 倒咖啡粉
			PourCoffeePowder();
			// 倒开水
			PourWater();
			// 搅拌
			Mix();
			// Ready
			Console.WriteLine("咖啡做完并端上来了。");
			Console.WriteLine();
		}
	}

	public class CoffeMakerA : MakeCoffee
	{
		protected override void ShowCoffeeMakerName()
		{
			Console.WriteLine("咖啡师：CoffeMakerA");
		}

		protected override void PourCoffeePowder()
		{
			Console.WriteLine("倒入雀巢");
		}

		protected override void PourWater()
		{
			Console.WriteLine("倒入100度沸水");
		}

		protected override void Mix()
		{
			Console.WriteLine("用勺子搅拌");
		}
	}

	public class CoffeMakerB : MakeCoffee
	{
		protected override void ShowCoffeeMakerName()
		{
			Console.WriteLine("咖啡师：CoffeMakerB");
		}

		protected override void PourCoffeePowder()
		{
			Console.WriteLine("倒入星巴克");
		}

		protected override void PourWater()
		{
			Console.WriteLine("倒入80度热水");
		}

		protected override void Mix()
		{
			Console.WriteLine("不搅拌");
		}
	}

}
