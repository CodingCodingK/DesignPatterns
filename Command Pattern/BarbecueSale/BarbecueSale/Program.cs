using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbecueSale
{
	// 实现烧烤店的 客户下单-服务员记录订单-后厨执行 模式
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			// 店铺准备
			Cooker cooker = new Cooker();
			Waiter waiter = new Waiter();
			Command bakeMutton = new BakeMuttonCommand(cooker);
			Command bakeChicken = new BakeChickenCommand(cooker);

			// 客户下订单
			waiter.AddOrder(bakeMutton);
			waiter.AddOrder(bakeMutton);
			waiter.AddOrder(bakeMutton);
			waiter.AddOrder(bakeChicken);
			waiter.AddOrder(bakeChicken);

			// 客户取消订单
			waiter.CancelOrder(bakeMutton);

			// 服务员通知后厨制作
			waiter.Notify();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public class Waiter
	{
		private List<Command> commands = new List<Command>();

		public void AddOrder(Command c)
		{
			commands.Add(c);
			Console.WriteLine("增加订单: {0}", c.name);
		}

		public void CancelOrder(Command c)
		{
			commands.Remove(c);
			Console.WriteLine("取消订单: {0}", c.name);
		}

		public void Notify()
		{
			Console.WriteLine("订单已确定，通知后厨开烤：");
			commands.ForEach(o=>o.ExcuteCommand());
		}
	}


	public class Cooker
	{
		public void BakeMutton()
		{
			Console.WriteLine("后厨烤羊肉串*1");
		}

		public void BakeChicken()
		{
			Console.WriteLine("后厨烤鸡肉串*1");
		}
	}

	public abstract class Command
	{
		public string name;

		protected Cooker receiver;

		public Command(Cooker r)
		{
			receiver = r;
		}

		public abstract void ExcuteCommand();
	}

	public class BakeMuttonCommand : Command
	{
		public BakeMuttonCommand(Cooker r) : base(r)
		{
			name = "羊肉串*1";
		}

		public override void ExcuteCommand()
		{
			receiver.BakeMutton();
		}
	}

	public class BakeChickenCommand : Command
	{
		public BakeChickenCommand(Cooker r) : base(r)
		{
			name = "鸡肉串*1";
		}

		public override void ExcuteCommand()
		{
			receiver.BakeChicken();
		}
	}
}
