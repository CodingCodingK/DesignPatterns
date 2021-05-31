using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoafOnTheJob_developed
{
	// 观察者模式，解耦中版，单向耦合:引入委托

	// 声明委托
	delegate void EventHandler();

	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			// 新建通知者
			Boss boss = new Boss();

			// 新建观察者 + 给观察者注册通知者
			StockObserver employeeA = new StockObserver("小强", boss);
			NBAObserver employeeB = new NBAObserver("小张", boss);

			// 给通知者添加发布者
			boss.Attach(employeeA.CloseStockWindow);
			boss.Attach(employeeB.CloseNBAWindow);

			// 通知消息
			boss.Message = "我回来了，让我看看谁在摸鱼。";
			boss.Notify();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	/// <summary>
	/// 观察者，由具体的员工们共通特征抽出而得
	/// </summary>
	interface Observer
	{
		//protected string name;
		//protected Subject sub;

		//public Observer(string n, Subject s)
		//{
		//	name = n;
		//	sub = s;
		//}

		// 暴露给通知者的接口，用来接收信息
		void Update();
	}

	/// <summary>
	/// 通知者，由具体的老板、前台共通特征抽出而得
	/// </summary>
	interface Subject
	{
		void Notify();

		// 传递的内容，一般是自己日常维护的某个状态，比如老板在/不在
		string Message { get; set; }
	}

	#region 具体实现类：员工/老板

	// 看股票的同事
	class StockObserver
	{
		string name;
		Subject sub;
		public StockObserver(string n, Subject s)
		{
			name = n;
			sub = s;
		}

		public void CloseStockWindow()
		{
			Console.WriteLine("正在看股票的同事{0}，收到了来自通知者的信息：{1}，立刻关闭了股票的页面。", name, sub.Message);
		}
	}

	// 看篮球的同事
	class NBAObserver
	{
		string name;
		Subject sub;
		public NBAObserver(string n, Subject s)
		{
			name = n;
			sub = s;
		}

		public void CloseNBAWindow()
		{
			Console.WriteLine("正在看NBA的同事{0}，收到了来自通知者的信息：{1}，立刻关闭了NBA的页面。", name, sub.Message);
		}
	}

	// 老板
	class Boss : Subject
	{
		//// 员工列表
		//List<Observer> ObserversCollection = new List<Observer>();

		private EventHandler Update;

		public void Attach(EventHandler method)
		{
			Update += method;
		}

		public void Detach(EventHandler method)
		{
			Update -= method;
		}

		public void Notify()
		{
			Update();
		}

		public string Message { get; set; }
	}

	// 前台小姐
	class Secretary : Subject
	{
		//// 员工列表
		//List<Observer> ObserversCollection = new List<Observer>();

		private EventHandler Update;

		public void Attach(EventHandler method)
		{
			Update += method;
		}

		public void Detach(EventHandler method)
		{
			Update -= method;
		}

		public void Notify()
		{
			Update();
		}

		public string Message { get; set; }
	}

	#endregion
}
