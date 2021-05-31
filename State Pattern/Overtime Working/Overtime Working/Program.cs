using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtime_Working
{
	// 需求是早上12点前工作状态好
	// 12-13点状态不好
	// 13-17点状态较好
	// 17点之后，如果任务完成了就下班
	// 如果没完成任务，17-21点疲劳加班
	// 23点之后，会直接睡着
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			var w1 = new Work(10, false);
			w1.WriteProgram();
			w1.time = 18;
			w1.isWorkFinished = true;
			w1.WriteProgram();

			var w2 = new Work(14, false);
			w2.WriteProgram();
			w2.time = 24;
			w2.WriteProgram();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public interface IState
	{
		void WriteProgram(Work work);
	}

	public class Work
	{
		private IState currentStatetate;
		public int time;
		public bool isWorkFinished;

		public Work(int t,bool w)
		{
			time = t;
			isWorkFinished = w;
			currentStatetate = new MoringState();
		}

		/// <summary>
		/// 暴露一个设置当前状态的接口
		/// </summary>
		/// <param name="state">状态</param>
		public void SetState(IState state)
		{
			this.currentStatetate = state;
		}

		/// <summary>
		/// 状态转换器
		/// </summary>
		public void WriteProgram()
		{
			currentStatetate.WriteProgram(this);
		}
	}

	// before 12
	public class MoringState : IState
	{
		public void WriteProgram(Work work)
		{
			if (work.time < 12)
			{
				Console.WriteLine("{0}点了，工作状态很好",work.time);
			}
			else
			{
				work.SetState(new MidAfternoonState());
				work.WriteProgram();
			}
		}
	}

	// 12-13
	public class MidAfternoonState : IState
	{
		public void WriteProgram(Work work)
		{
			if (work.time < 13)
			{
				Console.WriteLine("{0}点了，工作状态不好，吃完饭犯困", work.time);
			}
			else
			{
				work.SetState(new AfternoonState());
				work.WriteProgram();
			}
	
		}
	}

	// 13-17
	public class AfternoonState : IState
	{
		public void WriteProgram(Work work)
		{
			if (work.time < 17)
			{
				Console.WriteLine("{0}点了，工作状态还行，想喝下午茶", work.time);
			}
			else
			{
				work.SetState(new EveningState());
				work.WriteProgram();
			}
			
		}
	}

	// after 17
	public class EveningState : IState
	{
		public void WriteProgram(Work work)
		{
			if (work.isWorkFinished)
			{
				work.SetState(new RestState());
				work.WriteProgram();
			}
			else
			{
				if (work.time < 23)
				{
					Console.WriteLine("{0}点了，还在加班工作，非常疲劳", work.time);
				}
				else
				{
					work.SetState(new SleepingState());
					work.WriteProgram();
				}
			}
			
		}
	}

	// 终结点1-下班状态
	public class RestState : IState
	{
		public void WriteProgram(Work work)
		{
			Console.WriteLine("{0}点了，活干完了，下班回家了", work.time);
		}
	}

	// 终结点2-睡觉状态
	public class SleepingState : IState
	{
		public void WriteProgram(Work work)
		{
			Console.WriteLine("{0}点了，活还没干完，但睡了", work.time);
		}
	}

}
