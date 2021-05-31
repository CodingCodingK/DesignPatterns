using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveGame
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			Player player = new Player();
			player.ShowState();

			// Save Data
			RoleStateCaretaker careTaker = new RoleStateCaretaker();
			careTaker.Memento = player.SaveGame();

			// Meet Boss
			Console.WriteLine("Player meet boss,Battle.");
			Console.WriteLine();
			player.ExpPoint += 100;
			player.ManaPoint -= 50;
			player.HealthPoint -= 100;
			player.ShowState();

			// Dead, Load Data
			Console.WriteLine("Player has been dead, Load data");
			Console.WriteLine();
			player.LoadMemento(careTaker.Memento);
			player.ShowState();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public class Player
	{
		public int HealthPoint;
		public int ManaPoint;
		public int ExpPoint;

		public Player()
		{
			HealthPoint = 100;
			ManaPoint = 100;
			ExpPoint = 0;
		}

		public RoleStateMemento SaveGame()
		{
			return new RoleStateMemento(HealthPoint,ManaPoint,ExpPoint);
		}

		public void LoadMemento(RoleStateMemento memento)
		{
			HealthPoint = memento.HealthPoint;
			ManaPoint = memento.ManaPoint;
			ExpPoint = memento.ExpPoint;
		}

		public void ShowState()
		{
			Console.WriteLine("Player Statement :");
			Console.WriteLine("HealthPoint:{0}", HealthPoint);
			Console.WriteLine("ManaPoint:{0}", ManaPoint);
			Console.WriteLine("ExpPoint:{0}", ExpPoint);
			Console.WriteLine();
		}
	}

	public class RoleStateMemento
	{
		public int HealthPoint;
		public int ManaPoint;
		public int ExpPoint;

		public RoleStateMemento(int hp,int mana,int exp)
		{
			HealthPoint = hp;
			ManaPoint = mana;
			ExpPoint = exp;
		}
	}

	public class RoleStateCaretaker
	{
		private RoleStateMemento memento;

		public RoleStateMemento Memento
		{
			get { return memento; }
			set { memento = value; }
		}
	}
}
