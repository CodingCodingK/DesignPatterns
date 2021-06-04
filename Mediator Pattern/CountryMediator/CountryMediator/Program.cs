using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryMediator
{
	// 有些类似于订阅者-观察者模式
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			var manager = new UnitedNationsSecurityCouncil();
			var usa = new USA(manager);
			var japan = new Japan(manager);
			var india = new India(manager);
			manager.SetColleague(usa,japan,india);
			usa.Notify("美国疫情需要支援");
			japan.Notify("日本疫情需要支援");
			india.Notify("印度疫情需要支援");

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public class UnitedNationsSecurityCouncil : UnitedNations
	{
		private USA usa;
		private Japan japan;
		private India india;

		public void SetColleague(USA c1, Japan c2, India c3)
		{
			usa = c1;
			japan = c2;
			india = c3;
		}

		public override void Notify(string message, Country country)
		{
			if (country == usa)
			{
				japan.GetMessage(message);
				india.GetMessage(message);
			}
			else if (country == japan)
			{
				india.GetMessage(message);
				usa.GetMessage(message);
			}
			else if (country == india)
			{
				japan.GetMessage(message);
				usa.GetMessage(message);
			}
		}
	}

	/// <summary>
	/// 联合国-中介者
	/// </summary>
	public abstract class UnitedNations
	{
		public abstract void Notify(string message, Country country);
	}

	public class Country
	{
		protected UnitedNations mediator;

		public Country(UnitedNations m)
		{
			mediator = m;
		}
	}

	public class USA : Country
	{
		public USA(UnitedNations m) : base(m) { }

		public void Notify(string message)
		{
			mediator.Notify(message,this);
		}

		public void GetMessage(string message)
		{
			Console.WriteLine("美国获得信息：{0}",message);
		}
	}

	public class Japan : Country
	{
		public Japan(UnitedNations m) : base(m) { }

		public void Notify(string message)
		{
			mediator.Notify(message, this);
		}

		public void GetMessage(string message)
		{
			Console.WriteLine("日本获得信息：{0}", message);
		}
	}

	public class India : Country
	{
		public India(UnitedNations m) : base(m) { }

		public void Notify(string message)
		{
			mediator.Notify(message, this);
		}

		public void GetMessage(string message)
		{
			Console.WriteLine("印度获得信息：{0}", message);
		}
	}

}
