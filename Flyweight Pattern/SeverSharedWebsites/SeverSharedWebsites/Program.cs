using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeverSharedWebsites
{
	// 希望多个网页能使用同一个数据库
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			WebsiteFactory severs = new WebsiteFactory();

			Website a1 = severs.GetWebsiteCategory("电商平台");
			a1.Use(new User("马"));
			Website a2 = severs.GetWebsiteCategory("电商平台");
			a1.Use(new User("刘"));

			Website b1 = severs.GetWebsiteCategory("游戏平台");
			b1.Use(new User("马"));
			Website b2 = severs.GetWebsiteCategory("游戏平台");
			b2.Use(new User("G"));

			Website c1 = severs.GetWebsiteCategory("软件平台");
			c1.Use(new User("方"));

			severs.ShowWebsiteCount();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public class WebsiteFactory
	{
		/// <summary>
		/// 服务器列表
		/// </summary>
		private Hashtable flyweights = new Hashtable();

		public Website GetWebsiteCategory(string key)
		{
			if (!flyweights.ContainsKey((key)))
				flyweights.Add(key,new ConcreteWebsite(key));
			return (Website)flyweights[key];
		}

		public void ShowWebsiteCount()
		{
			Console.WriteLine("共享的网站服务器总服务端数为：{0}", flyweights.Count);
		}
	}

	public class ConcreteWebsite:Website
	{
		private string name;

		public ConcreteWebsite(string n)
		{
			name = n;
		}

		public override void Use(User user)
		{
			Console.WriteLine("网站分类：" + name + ",客户：" + user.name);
		}
	}

	public abstract class Website
	{
		public abstract void Use(User user);
	}

	public class User
	{
		public string name;

		public User(string n)
		{
			name = n;
		}
	}


}
