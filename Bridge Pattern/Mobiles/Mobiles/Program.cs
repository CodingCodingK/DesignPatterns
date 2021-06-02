using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobiles
{
	// 过去的手机和软件耦合，不同厂家之间的软件无法复用
	// 根据合成原理，同一厂家的不同软件可以组合起来 => 手机软件和手机硬件分离，抽象出“软件”类 和 “手机品牌”类
	// 根据聚合原理，“软件”类 属于 “手机品牌”类

	// 但是这就不是过去的手机生态了。这样的理念就是现在的手机生态，不同品牌的手机对应同一个安卓平台，上面的软件可以通用。
	// 手机和软件之间，采取桥接模式，各自管各自继承实现业务。
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			AndroidPhoneBrand huawei = new Huawei();
			Console.WriteLine(huawei.name);
			huawei.SetAndroidSoft(new ChatApp());
			huawei.SetAndroidSoft(new GameApp());
			huawei.RunEverySoft();

			AndroidPhoneBrand xiaomi = new Xiaomi();
			Console.WriteLine(xiaomi.name);
			xiaomi.SetAndroidSoft(new ToolApp());
			xiaomi.SetAndroidSoft(new ChatApp());
			xiaomi.SetAndroidSoft(new GameApp());
			xiaomi.RunEverySoft();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public abstract class AndroidSoft
	{
		public abstract void Run();
	}

	public class GameApp : AndroidSoft
	{
		public override void Run()
		{
			Console.WriteLine("运行手游");
		}
	}

	public class ToolApp : AndroidSoft
	{
		public override void Run()
		{
			Console.WriteLine("运行手机工具App");
		}
	}

	public class ChatApp : AndroidSoft
	{
		public override void Run()
		{
			Console.WriteLine("运行聊天工具App");
		}
	}

	/// <summary>
	/// 手机品牌
	/// </summary>
	public abstract class AndroidPhoneBrand
	{
		public string name;

		private List<AndroidSoft> softList = new List<AndroidSoft>();

		public void SetAndroidSoft(AndroidSoft soft)
		{
			softList.Add(soft);
		}

		public void RunEverySoft()
		{
			softList.ForEach(o=>o.Run());
		}
	}

	public class Huawei : AndroidPhoneBrand
	{
		public Huawei()
		{
			name = "Huawei";
		}
	}

	public class Xiaomi : AndroidPhoneBrand
	{
		public Xiaomi()
		{
			name = "Xiaomi";
		}
	}
}
