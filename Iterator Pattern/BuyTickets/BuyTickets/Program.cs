using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTickets
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

			ConcreteAggregate a = new ConcreteAggregate();
			a[0] = "大哥";
			a[1] = "小弟";
			a[2] = "大米";
			a[3] = "小蝶";
			a[4] = "大懒";
			a[5] = "小丢";

			// 正序迭代器
			Iterator i = new ConcreteIterator(a);
			Console.WriteLine(i.First());
			while (!i.IsDone())
			{
				Console.WriteLine("{0} 请买车票",i.CurrentItem());
				i.Next();
			}

			Console.WriteLine();

			// 逆序迭代器
			Iterator i_DESC = new ConcreteIteratorDesc(a);
			Console.WriteLine(i_DESC.First());
			while (!i_DESC.IsDone())
			{
				Console.WriteLine("{0} 请买车票", i_DESC.CurrentItem());
				i_DESC.Next();
			}

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public abstract class Iterator
	{
		public abstract object First();
		public abstract object Next();
		public abstract bool IsDone();
		public abstract object CurrentItem();
	}

	/// <summary>
	/// 聚集
	/// </summary>
	public abstract class Aggregate
	{
		public abstract Iterator CreateIterator();
	}

	public class ConcreteIterator : Iterator
	{
		private ConcreteAggregate aggregate;
		private int current = 0;

		public ConcreteIterator(ConcreteAggregate ag)
		{
			aggregate = ag;
		}

		public override object First()
		{
			return aggregate[0];
		}

		public override object Next()
		{
			object result = null;
			current++;

			if (current < aggregate.Count)
			{
				result = aggregate[current];
			}
			return result;
		}

		public override bool IsDone()
		{
			return current >= aggregate.Count;
		}

		public override object CurrentItem()
		{
			return aggregate[current];
		}
	}

	public class ConcreteAggregate : Aggregate
	{
		private List<object> items = new List<object>();

		public override Iterator CreateIterator()
		{
			return new ConcreteIterator(this);
		}

		public int Count
		{
			get => items.Count;
		}

		public object this[int index]
		{
			get => items[index];
			set => items.Insert(index,value);
		}
	}

	/// <summary>
	/// 逆向遍历迭代器
	/// </summary>
	public class ConcreteIteratorDesc : Iterator
	{
		private ConcreteAggregate aggregate;
		private int current;

		public ConcreteIteratorDesc(ConcreteAggregate ag)
		{
			aggregate = ag;
			current = aggregate.Count - 1;
		}

		public override object First()
		{
			return aggregate[aggregate.Count - 1];
		}

		public override object Next()
		{
			object result = null;
			current--;

			if (current >= 0)
			{
				result = aggregate[current];
			}
			return result;
		}

		public override bool IsDone()
		{
			return current < 0;
		}

		public override object CurrentItem()
		{
			return aggregate[current];
		}
	}
}
