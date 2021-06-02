using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafetyLockSingleton
{
	// 双重验证的 线程安全锁
	// 线程锁是为了防止多线程下，出现多次实例化的现象
	// 双重验证是为了执行效率
	class Program
	{
		static void Main(string[] args)
		{

		}
	}

	public class Singleton<T> where T : class
	{
		private static T instance;
		private static readonly object syncRoot = new object();// 用于lock的 进程辅助对象
		protected Singleton() { }

		public static T GetInstance()
		{
			if (instance == null)
			{
				lock (syncRoot)
				{
					if (instance == null)
					{
						instance = (T)Activator.CreateInstance(typeof(T), true);// 创建实例方法
					}
				}
			}

			return instance;
		}

	}

	public class SingletonWindow : Singleton<SingletonWindow>
	{
		private SingletonWindow()
		{

		}
	}
}
