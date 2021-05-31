using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WearClothes
{
	public class Program
	{
		static void Main(string[] args)
		{
			// 准备好所有衣服
			var pants = new Pants();
			var tShirts = new TShrits();
			var jeans = new Jeans();
			var skirts = new Skirts();
			var onePiece = new OnePiece();

			// 第一位，女生
			var girl1 = new Person("Halon");
			pants.Decorate(girl1);
			tShirts.Decorate(pants);
			skirts.Decorate(tShirts);

			skirts.Show();
			Console.WriteLine();

			// 第二位，女生
			var girl2 = new Person("Madam");
			pants.Decorate(girl2);
			onePiece.Decorate(pants);

			onePiece.Show();
			Console.WriteLine();

			// 第三位，男生
			var boy = new Person("Tom");
			pants.Decorate(boy);
			jeans.Decorate(pants);
			tShirts.Decorate(jeans);

			tShirts.Show();
			Console.WriteLine();
			Console.WriteLine("---------------------------");
			Console.WriteLine("注意，以上人物均用的是一套衣物。如果衣服还有自己的属性比如标签，那么需要重新实例化新的衣服。");

			//// 解决了以下麻烦：不用新建这么多的实例。
			//var nobody = new Person("NoBody");
			//pants3.Decorate(nobody);
			//tShirts2.Decorate(pants3);
			//tShirts2.Show();
			//Console.WriteLine();

			#region Test

			Console.ReadLine();

			#endregion
		}

		public class Person
		{
			public string name;

			public Person()
			{

			}

			public Person(string n)
			{
				this.name = n;
			}

			public virtual void Show()
			{
				Console.WriteLine("装扮者：{0}",name);
			}
		}

		public class Clothe : Person
		{
			protected Person component;

			// 打扮
			public void Decorate(Person p)
			{
				this.component = p;
			}

			public override void Show()
			{
				if (component != null)
					component.Show();
			}

		}

		public class TShrits : Clothe
		{
			public override void Show()
			{
				base.Show();
				Console.WriteLine("TShrits ");
			}
		}

		public class Pants : Clothe
		{
			public override void Show()
			{
				base.Show();
				Console.WriteLine("Pants ");
			}
		}

		public class Jeans : Clothe
		{
			public override void Show()
			{
				base.Show();
				Console.WriteLine("Jeans ");
			}
		}

		// 单裙
		public class Skirts : Clothe
		{
			public override void Show()
			{
				base.Show();
				Console.WriteLine("Skirts ");
			}
		}

		// 连衣裙
		public class OnePiece : Clothe
		{
			public override void Show()
			{
				base.Show();
				Console.WriteLine("OnePiece ");
			}
		}

	}
}
