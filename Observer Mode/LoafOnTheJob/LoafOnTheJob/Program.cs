using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LoafOnTheJob
{
	// 观察者模式，解耦初版
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
			StockObserver employeeB = new StockObserver("小张", boss);

			// 给通知者添加发布者
			boss.Attach(employeeA);
			boss.Attach(employeeB);

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
		void Attach(Observer ob);
		void Detach(Observer ob);
		void Notify();

		// 传递的内容，一般是自己日常维护的某个状态，比如老板在/不在
		string Message { get; set; }
	}

	#region 具体实现类：员工/老板

	// 看股票的同事
	class StockObserver: Observer
	{
		string name;
		Subject sub;
		public StockObserver(string n, Subject s)
		{
			name = n;
			sub = s;
		}

		public void Update()
		{
			Console.WriteLine("正在看股票的同事{0}，收到了来自通知者的信息：{1}", name,sub.Message);
		}
	}

	// 看篮球的同事
	class NBAObserver : Observer
	{
		string name;
		Subject sub;
		public NBAObserver(string n, Subject s)
		{
			name = n;
			sub = s;
		}

		public void Update()
		{
			Console.WriteLine("正在看NBA的同事{0}，收到了来自通知者的信息：{1}", name, sub.Message);
		}
	}

	// 老板
	class Boss : Subject
	{
		// 员工列表
		List<Observer> ObserversCollection = new List<Observer>();

		public void Attach(Observer ob)
		{
			ObserversCollection.Add(ob);
		}

		public void Detach(Observer ob)
		{
			ObserversCollection.Remove(ob);
		}

		public void Notify()
		{
			ObserversCollection.ForEach(o=>o.Update());
		}

		public string Message { get; set; }
	}

	// 前台小姐
	class Secretary : Subject
	{
		// 员工列表
		List<Observer> ObserversCollection = new List<Observer>();

		public void Attach(Observer ob)
		{
			ObserversCollection.Add(ob);
		}

		public void Detach(Observer ob)
		{
			ObserversCollection.Remove(ob);
		}

		public void Notify()
		{
			ObserversCollection.ForEach(o => o.Update());
		}

		public string Message { get; set; }
	}

	#endregion

}
