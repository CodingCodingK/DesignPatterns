using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawAMan
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			Director director = new Director();
			ManBuilder m1 = new IdleManBuilder();
			ManBuilder m2 = new DanceManBuilder();

			// 建造man1,man2
			director.Construct(m1);
			director.Construct(m2);

			var man1 = m1.GetMan();
			var man2 = m2.GetMan();

			man1.Show();
			man2.Show();
			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	// 指挥者
	class Director
	{
		public void Construct(ManBuilder builder)
		{
			builder.BuildHead();
			builder.BuildBody();
			builder.BuildFoot();
		}
	}


	public abstract class ManBuilder
	{
		public abstract void BuildHead();
		public abstract void BuildBody();
		public abstract void BuildFoot();
		public abstract Man GetMan();
	}

	public class Man
	{
		List<string> parts = new List<string>();

		public void Add(string part)
		{
			parts.Add(part);
		}

		public void Show()
		{
			Console.WriteLine("-------Build Start-------");
			parts.ForEach(o=>
			{
				if (o != null) Console.WriteLine(o);
			});
		}
	}

	// 具体建造者
	class IdleManBuilder : ManBuilder
	{
		private Man man = new Man();

		public override void BuildHead()
		{
			man.Add("　〇　");
		}

		public override void BuildBody()
		{
			man.Add("/｜｜-");
		}

		public override void BuildFoot()
		{
			man.Add(" |~|");
		}

		public override Man GetMan()
		{
			return man;
		}
	}

	// 具体建造者
	class DanceManBuilder : ManBuilder
	{
		private Man man = new Man();

		public override void BuildHead()
		{
			man.Add("　〇　");
		}

		public override void BuildBody()
		{
			man.Add("~｜｜~");
		}

		public override void BuildFoot()
		{
			man.Add(" /~|");
		}

		public override Man GetMan()
		{
			return man;
		}
	}

}
