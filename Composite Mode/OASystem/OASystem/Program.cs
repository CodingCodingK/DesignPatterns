using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OASystem
{
	// treeView Construt
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			ConcreteCompany root = new ConcreteCompany("上海总公司");
			root.Add(new HRDepartment("总公司人力资源部"));
			root.Add(new TechDepartment("总公司技术部"));

			ConcreteCompany comp1 = new ConcreteCompany("广东办事处");
			comp1.Add(new HRDepartment("广东办事处人力资源部"));
			comp1.Add(new TechDepartment("广东办事处技术部"));
			root.Add(comp1);

			ConcreteCompany comp2 = new ConcreteCompany("东京分公司");
			comp2.Add(new HRDepartment("东京分公司人力资源部"));
			comp2.Add(new TechDepartment("东京分公司技术部"));
			root.Add(comp2);

			Console.WriteLine("结构图");
			root.Display(1);

			Console.WriteLine();
			Console.WriteLine("职责一览");
			root.LineOfDuty();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public abstract class Company
	{
		protected string name;

		public Company(string n)
		{
			name = n;
		}

		public abstract void Add(Company c);
		public abstract void Remove(Company c);
		public abstract void Display(int depth);
		public abstract void LineOfDuty();
	}

	// Leaf 1
	public class HRDepartment : Company
	{
		public HRDepartment(string n) : base(n)
		{
		}

		public override void Add(Company c) { }

		public override void Remove(Company c) { }

		public override void Display(int depth)
		{
			Console.WriteLine(new string('-', depth) + name);
		}

		public override void LineOfDuty()
		{
			Console.WriteLine("{0} 员工招聘培训管理",name);
		}
	}

	// Leaf 2
	public class TechDepartment : Company
	{
		public TechDepartment(string n) : base(n)
		{
		}

		public override void Add(Company c) { }

		public override void Remove(Company c) { }

		public override void Display(int depth)
		{
			Console.WriteLine(new string('-', depth) + name);
		}

		public override void LineOfDuty()
		{
			Console.WriteLine("{0} 就一修电脑的", name);
		}
	}

	// Concrete(Instance)
	public class ConcreteCompany : Company
	{
		private List<Company> children = new List<Company>();

		public ConcreteCompany(string n) : base(n)
		{
		}

		public override void Add(Company c)
		{
			children.Add(c);
		}

		public override void Remove(Company c)
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

		public override void LineOfDuty()
		{
			foreach (var child in children)
			{
				child.LineOfDuty();
			}
		}
	}
}
