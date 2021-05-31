using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			var facade = new Facade();
			facade.MethodA();
			facade.MethodB();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	class Facade
	{
		private SubSystemA subA;
		private SubSystemB subB;
		private SubSystemC subC;

		public Facade()
		{
			subA = new SubSystemA();
			subB = new SubSystemB();
			subC = new SubSystemC();
		}

		// 对外界只公布方法A的接口，调用即可，而具体实现由自己承担
		public void MethodA()
		{
			subA.MethodA();
			subA.MethodB();
			subC.MethodA();
		}

		// 对外界只公布方法B的接口，调用即可，而具体实现由自己承担
		public void MethodB()
		{
			subA.MethodA();
			subB.MethodA();
		}
	}

	class SubSystemA
	{
		public void MethodA()
		{
			Console.WriteLine("执行子系统A.方法A");
		}

		public void MethodB()
		{
			Console.WriteLine("执行子系统A.方法B");
		}
	}

	class SubSystemB
	{
		public void MethodA()
		{
			Console.WriteLine("执行子系统B.方法A");
		}
	}

	class SubSystemC
	{
		public void MethodA()
		{
			Console.WriteLine("执行子系统C.方法A");
		}

		public void MethodB()
		{
			Console.WriteLine("执行子系统C.方法B");
		}
	}

}
