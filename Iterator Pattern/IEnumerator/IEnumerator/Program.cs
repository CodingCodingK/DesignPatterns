using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerator
{
	// foreach 在编译期里做的事：
	// IEnumerator<string> e = a.GetEnumerator();
	// while(e.MoveNext())
	// {
	//	  do sth
	// }

	//public interface IEnumerator
	//{
	//	object Current { get; }
	//	bool MoveNext();
	//	void Reset();
	//}

	//public interface IEnumerable
	//{
	//	IEnumerator GetEnumerator();
	//}
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			//手动实现foreach简单版
			List<object> testList = new List<object>(){"A","B","C"};

			IEnumerable a = new Enumerable(testList);
			IEnumerator e = a.GetEnumerator();

			while (e.MoveNext())
			{
				Console.WriteLine(e.Current.ToString());
			}
			e.Reset();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public interface IEnumerator
	{
		object Current { get; }
		bool MoveNext();
		void Reset();
	}

	public interface IEnumerable
	{
		IEnumerator GetEnumerator();
	}

	public class Enumerator : IEnumerator
	{
		private Enumerable e;
		private int current = -1;

		public Enumerator(Enumerable e)
		{
			this.e = e;
		}

		public object Current
		{
			get => e.items[current];
		}

		public bool MoveNext()
		{
			return current++ < e.items.Count - 1;
		}

		public void Reset()
		{
			current = -1;
		}
	}

	public class Enumerable : IEnumerable
	{
		public List<object> items = new List<object>();

		public Enumerable(List<object> items)
		{
			this.items = items;
		}

		public IEnumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

	}
}
