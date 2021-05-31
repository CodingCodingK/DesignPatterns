using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
	class Program
	{
		static void Main(string[] args)
		{
			TestPaper A = new TestPaperA();
			A.TestQuestion1();
			TestPaper B = new TestPaperB();
			B.TestQuestion1();

			Console.Read();
		}
	}

	class TestPaper
	{
		public void TestQuestion1()
		{
			Console.WriteLine("Q1: 1 + 1 = ? A:1,B:2,C:3");
			Console.WriteLine("Answer:" + Answer1());
		}

		protected virtual string Answer1()
		{
			return string.Empty;
		}
	}

	// 学生A的试卷
	class TestPaperA : TestPaper
	{
		protected override string Answer1()
		{
			return "A";
		}
	}

	// 学生B的试卷
	class TestPaperB : TestPaper
	{
		protected override string Answer1()
		{
			return "C";
		}
	}

}
