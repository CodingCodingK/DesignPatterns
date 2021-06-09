using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerAndNPC
{
	// 访问者模式要求elements是确定的，比如这个情况下的游戏世界里只有“玩家”和“NPC”两种人
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			EventTrigger eventTrigger = new EventTrigger();
			eventTrigger.Attach(new Player());
			eventTrigger.Attach(new NPC());

			// 攻击时大家的反应
			eventTrigger.Display(new Attack());

			// 死亡时大家的反应
			eventTrigger.Display(new Die());

			// 胜利时大家的反应
			eventTrigger.Display(new Win());

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	class EventTrigger
	{
		private List<Person> elements = new List<Person>();

		public void Attach(Person element)
		{
			elements.Add(element);
		}

		public void Detach(Person element)
		{
			elements.Remove(element);
		}

		public void Display(Action visitor)
		{
			elements.ForEach(o=>o.Accept(visitor));
		}
	}

	abstract class Action
	{
		public abstract void GetPlayerConclusion(Player element);

		public abstract void GetNPCConclusion(NPC element);
	}

	abstract class Person
	{
		public abstract void Accept(Action visitor);
	}

	class Attack : Action
	{
		public override void GetPlayerConclusion(Player element)
		{
			Console.WriteLine("{0} {1},Damage!",element.GetType().Name,this.GetType().Name);
		}

		public override void GetNPCConclusion(NPC element)
		{
			Console.WriteLine("{0} {1},Nothing happened!", element.GetType().Name, this.GetType().Name);
		}
	}

	class Die : Action
	{
		public override void GetPlayerConclusion(Player element)
		{
			Console.WriteLine("{0} {1},Game Over!", element.GetType().Name, this.GetType().Name);
		}

		public override void GetNPCConclusion(NPC element)
		{
			Console.WriteLine("{0} {1},Nothing happened!", element.GetType().Name, this.GetType().Name);
		}
	}

	class Win : Action
	{
		public override void GetPlayerConclusion(Player element)
		{
			Console.WriteLine("{0} {1},Congratulations!", element.GetType().Name, this.GetType().Name);
		}

		public override void GetNPCConclusion(NPC element)
		{
			Console.WriteLine("{0} {1},Nothing happened!", element.GetType().Name, this.GetType().Name);
		}
	}

	class Player : Person
	{
		public override void Accept(Action visitor)
		{
			visitor.GetPlayerConclusion(this);
		}
	}

	class NPC : Person
	{
		public override void Accept(Action visitor)
		{
			visitor.GetNPCConclusion(this);
		}
	}

}
