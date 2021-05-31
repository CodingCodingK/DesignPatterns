using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Factory
{
	class Program
	{
		static void Main(string[] args)
		{
			
			float x = 0;
			float y = 0;
			string operater = "";

			#region Get Input
			try
			{
				GetInput(out x, out y, out operater);
			}
			catch (Exception e)
			{
				Console.WriteLine("Input Missing ！");
			}
			#endregion

			var operation = SimpleFactory.GetInstance(operater);
			operation.NumA = x;
			operation.NumB = y;
			Console.WriteLine("Result:");
			Console.WriteLine(operation.GetResult());

			#region Test

			Console.ReadLine();

			#endregion

		}

		#region Get Input
		static void GetInput(out float x, out float y, out string operater)
		{
			Console.WriteLine("Give Me X.");
			x = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Give Me Y.");
			y = Int32.Parse(Console.ReadLine());
			Console.WriteLine("Give Me Operater.");
			operater = Console.ReadLine();
		}
		#endregion
	}

	#region Simple Factory

	public static class SimpleFactory
	{
		public static Operation GetInstance(string operater)
		{
			var result = new Operation();
			switch (operater)
			{
				case "+":
					result = new Plus();
					break;
				case "-":
					result = new Minus();
					break;
				case "*":
					result = new Multi();
					break;
				case "/":
					result = new Divide();
					break;
			}

			return result;
		}

	}

	#region Instance

	public class Operation
	{
		public float NumA;
		public float NumB;

		public virtual float GetResult()
		{
			Console.WriteLine("Error : Operater is strange !");
			return 0;
		}
	}

	public class Plus : Operation
	{
		public override float GetResult()
		{
			return NumA + NumB;
		}
	}

	public class Minus : Operation
	{
		public override float GetResult()
		{
			return NumA - NumB;
		}
	}

	public class Multi : Operation
	{
		public override float GetResult()
		{
			return NumA * NumB;
		}
	}

	public class Divide : Operation
	{
		public override float GetResult()
		{
			try
			{
				return NumA / NumB;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error : B is 0 !");
				return 0;
			}
		}
	}


	#endregion

	#endregion








}
