using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			Context battle = new Context();
			// 模拟一回合2次行动的回合制对战
			battle.Text = "P_atk 20 P_def -1 M_atk 100 M_matk 20 P_matk 200 P_def 200 M_def -1 M_def -1 P_atk 300 ";

			ActionExpression expression = null;

			while (battle.Text?.Length > 0)
			{
				var role = battle.Text.Substring(0, 1);
				// 可用反射改写
				switch (role)
				{
					case "M" :
						expression = new MonsterExpression();
						break;
					case "P":
						expression = new PlayerExpression();
						break;
					default:
						expression = null;
						break;
				}

				if (expression != null)
				{
					expression.Interpret(battle);
				}
			}

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public class Context
	{
		private string text;
		public string Text {
			get => text;
			set => text = value;
		}
	}

	/// <summary>
	/// Expression
	/// </summary>
	public abstract class ActionExpression
	{
		public void Interpret(Context c)
		{
			if (c.Text.Length == 0) return;

			// get Action
			var action = GetOneWord(ref c);
			if (string.IsNullOrEmpty(action)) return;

			// get Value
			var value = GetOneWord(ref c);
			if (string.IsNullOrEmpty(value)) return;

			// Interpret
			Execute(action, value);
		}

		public abstract void Execute(string action, string value);

		private string GetOneWord(ref Context context)
		{
			var index = context.Text.IndexOf(" ");
			if (index == 0) return null;

			var word = context.Text.Substring(0, index);
			context.Text = context.Text.Substring(index+1);
			return word;
		}
	}

	public class MonsterExpression : ActionExpression
	{
		public override void Execute(string action, string value)
		{
			var note = "";
			switch (action)
			{
				case "M_atk" :
					note += "怪物进行攻击 ";
					break;
				case "M_matk":
					note += "怪物进行魔法攻击 ";
					break;
				case "M_def":
					note += "怪物进行防御 ";
					break;
				default:
					note += "怪物进行未知操作 ";
					break;
			}

			if (Convert.ToInt32(value) <= 0)
			{
				note += "失败";
			}
			else if (Convert.ToInt32(value) <= 50)
			{
				note += "成功";
			}
			else
			{
				note += "大成功";
			}

			Console.WriteLine(note);
		}
	}

	public class PlayerExpression : ActionExpression
	{
		public override void Execute(string action, string value)
		{
			var note = "";
			switch (action)
			{
				case "P_atk":
					note += "玩家进行攻击 ";
					break;
				case "P_matk":
					note += "玩家进行魔法攻击 ";
					break;
				case "P_def":
					note += "玩家进行防御 ";
					break;
				default:
					note += "玩家进行未知操作 ";
					break;
			}

			if (Convert.ToInt32(value) <= 0)
			{
				note += "失败";
			}
			else if (Convert.ToInt32(value) <= 50)
			{
				note += "成功";
			}
			else
			{
				note += "大成功";
			}

			Console.WriteLine(note);
		}
	}
}
