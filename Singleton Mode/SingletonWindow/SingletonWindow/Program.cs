using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonWindow
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			var a = TipWindow.Instantiate();
			a.name = "TipWindow_A";
			a.Show();

			var b = TipWindow.Instantiate();
			b.Show();

			TipWindow.Instantiate().Show();

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public class TipWindow
	{
		// 禁止外部构造
		private TipWindow() { Console.WriteLine("Create TipWindow!"); }

		// Singleton Mode
		private static TipWindow tipWindow = null;

		public static TipWindow Instantiate()
		{
			if (tipWindow == null) // || tipWindow.isDisposed
			{
				tipWindow = new TipWindow();
			}

			return tipWindow;
		}

		// Property and Function
		public string name;

		public void Show()
		{
			Console.WriteLine("{0} Opened!",name);
		}
	}
	
}
