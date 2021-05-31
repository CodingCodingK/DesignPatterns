using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA
{
	// NBA的姚明无法听懂国外教练的指令，而我们不能在短时间内重构“姚明”和教练机制，那么就引入翻译人（适配器），在姚明外套一层。
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			var p1 = new Forwards("Sum");
			var p2 = new Center("Tom");
			var p3 = new ForeignCenterTranslator("姚明");
			//var p3 = new ForeignCenter("姚明");
			//p3.Attack(); 姚明听不懂Attack指令，只有ForeginAttack指令！

			p1.Attack();
			p2.Defense();
			p3.Attack();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	abstract class Player
	{
		protected string name;

		public Player(string n)
		{
			name = n;
		}

		public abstract void Attack();
		public abstract void Defense();
	}

	abstract class ForeignPlayer
	{
		protected string name;

		public ForeignPlayer(string n)
		{
			name = n;
		}

		public abstract void ForeginAttack();
		public abstract void ForeginDefense();
	}

	#region 普通球员

	/// <summary>
	/// 前锋
	/// </summary>
	class Forwards : Player
	{
		public Forwards(string n) : base(n)
		{
		}

		public override void Attack()
		{
			Console.WriteLine("Got it.Forward {0} Attack on command.", name);
		}

		public override void Defense()
		{
			Console.WriteLine("Got it.Forward {0} Defense on command.", name);
		}
	}

	/// <summary>
	/// 中锋
	/// </summary>
	class Center : Player
	{
		public Center(string n) : base(n)
		{
		}

		public override void Attack()
		{
			Console.WriteLine("Got it.Center {0} Attack on command.", name);
		}

		public override void Defense()
		{
			Console.WriteLine("Got it.Center {0} Defense on command.", name);
		}
	}

	#endregion

	/// <summary>
	/// 适配器：ForeignCenter用
	/// </summary>
	class ForeignCenterTranslator : Player
	{
		private ForeignCenter player;

		public ForeignCenterTranslator(string n) : base(n)
		{
			player = new ForeignCenter(n);
		}

		public override void Attack()
		{
			// 修改方法名，从而实现接口适配
			player.ForeginAttack();
		}

		public override void Defense()
		{
			// 修改方法名，从而实现接口适配
			player.ForeginDefense();
		}
	}

	/// <summary>
	/// 外国人中锋
	/// </summary>
	class ForeignCenter : ForeignPlayer
	{
		public ForeignCenter(string n) : base(n)
		{
		}

		public override void ForeginAttack()
		{
			Console.WriteLine("收到指令。外国人中锋 {0} 进行攻击。", name);
		}

		public override void ForeginDefense()
		{
			Console.WriteLine("收到指令。外国人中锋 {0} 进行防守。", name);
		}
	}
}
