using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeiFengFactory
{

	public class LeiFeng
	{
		public void Sweep()
		{
			Console.WriteLine("Sweeping Ground");
		}
		public void Wash()
		{
			Console.WriteLine("Washing Clothes");
		}
		public void BuyRice()
		{
			Console.WriteLine("Go Buying Rice");
		}
	}

	class Student : LeiFeng
	{
		public int StudentNo;
	}

	class Volunteer : LeiFeng
	{
		public int VolunteerNo;
	}

	class Program
	{
		static void Main(string[] args)
		{
			#region Simple Factory

			//LeiFeng student = SimpleFactory.CreateLeiFeng("Student");
			//student.Sweep();
			//student.BuyRice();
			//student.Wash();

			#endregion

			#region Method Factory

			LeiFeng student = new StudentFactory().CreateLeiFeng();
			student.Sweep();
			student.BuyRice();
			student.Wash();

			#endregion


			#region Test

			Console.Read();

			#endregion
		}
	}

	#region Simple Factory

	//public static class SimpleFactory
	//{
	//	public static LeiFeng CreateLeiFeng(string name)
	//	{
	//		switch (name)
	//		{
	//			case "Student":
	//				return new Student();
	//			case "Volunteer":
	//				return new Volunteer();
	//		}

	//		return null;
	//	}

	//}

	#endregion

	// Change to

	#region Method Factory

	interface IFactory
	{
		LeiFeng CreateLeiFeng();
	}

	class StudentFactory : IFactory
	{
		public LeiFeng CreateLeiFeng()
		{
			return new Student();
		}
	}

	class VolunteerFactory : IFactory
	{
		public LeiFeng CreateLeiFeng()
		{
			return new Volunteer();
		}
	}

	#endregion






}
