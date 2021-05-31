using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OASystem
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			Composite root = new Composite("root");
			root.Add(new Leaf("Leaf 1"));
			root.Add(new Leaf("Leaf 2"));

			Composite comp = new Composite("Composite A");
			comp.Add(new Leaf("Leaf A1"));
			comp.Add(new Leaf("Leaf A2"));

			// 树枝A插入
			root.Add(comp);

			Component comp2 = new Composite("Composite B");
			comp2.Add(new Leaf("Leaf B1"));
			comp2.Add(new Leaf("Leaf B2"));

			// 树枝B插入
			root.Add(comp2);

			root.Add(new Leaf("Leaf 3"));

			// 树叶先插后剪
			Leaf leaf = new Leaf("Leaf 4");
			root.Add(leaf);
			root.Remove(leaf);

			root.Display(1);

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public abstract class Component
	{
		protected string name;

		public Component(string n)
		{
			name = n;
		}

		public abstract void Add(Component c);
		public abstract void Remove(Component c);
		public abstract void Display(int depth);
	}

	public class Leaf : Component
	{
		public Leaf(string n) : base(n)
		{
		}

		public override void Add(Component c)
		{
			Console.WriteLine("Cannot add to a leaf");
		}

		public override void Remove(Component c)
		{
			Console.WriteLine("Cannot remove from a leaf");
		}

		public override void Display(int depth)
		{
			Console.WriteLine(new string('-',depth) + name);
		}
	}

	public class Composite : Component
	{
		private List<Component> children = new List<Component>();

		public Composite(string n) : base(n)
		{
		}

		public override void Add(Component c)
		{
			children.Add(c);
		}

		public override void Remove(Component c)
		{
			children.Remove(c);
		}

		public override void Display(int depth)
		{
			Console.WriteLine(new string('-',depth) + name);

			foreach (var component in children)
			{
				component.Display(depth + 2);
			}
		}
	}
}
