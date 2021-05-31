using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;//反射
using System.Configuration;

namespace MultiDBSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			#region Chinese Output
			Console.OutputEncoding = Encoding.GetEncoding(936);
			#endregion

			var userService = DataAccess.CreateUser();
			var departmentService = DataAccess.CreateDepartment();
			userService.Insert();
			userService.GetUser(22);
			departmentService.Insert();
			departmentService.GetDepartment(22);

			#region Test Wait
			Console.Read();
			#endregion
		}
	}

	public static class DataAccess
	{
		private static readonly string AssemblyName = "MultiDBSystem";
		private static readonly string db = ConfigurationManager.AppSettings["DB"];

		public static IUser CreateUser()
		{
			string className = AssemblyName + "." + db + "User";
			return (IUser) Assembly.Load(AssemblyName).CreateInstance(className);
		}

		public static IDepartment CreateDepartment()
		{
			string className = AssemblyName + "." + db + "Department";
			return (IDepartment)Assembly.Load(AssemblyName).CreateInstance(className);
		}
	}

	// 假设只有插入和获取2个方法
	public interface IUser
	{
		void Insert();
		IUser GetUser(int id);
	}

	public interface IDepartment
	{
		void Insert();
		IDepartment GetDepartment(int id);
	}

	public class MySQLUser:IUser
	{
		public void Insert()
		{
			Console.WriteLine("向MySQL数据库，插入了一条User数据");
		}

		public IUser GetUser(int id)
		{
			Console.WriteLine("访问MySQL数据库，获取到了id：{0}的User数据", id);
			return null;
		}
	}

	public class SQLiteUser : IUser
	{
		public void Insert()
		{
			Console.WriteLine("向SQLite数据库，插入了一条User数据");
		}

		public IUser GetUser(int id)
		{
			Console.WriteLine("访问SQLite数据库，获取到了id：{0}的User数据", id);
			return null;
		}
	}

	public class MySQLDepartment : IDepartment
	{
		public void Insert()
		{
			Console.WriteLine("向MySQL数据库，插入了一条Department数据");
		}

		public IDepartment GetDepartment(int id)
		{
			Console.WriteLine("访问MySQL数据库，获取到了id：{0}的Department数据", id);
			return null;
		}
	}

	public class SQLiteDepartment : IDepartment
	{
		public void Insert()
		{
			Console.WriteLine("向SQLite数据库，插入了一条Department数据");
		}

		public IDepartment GetDepartment(int id)
		{
			Console.WriteLine("访问SQLite数据库，获取到了id：{0}的Department数据", id);
			return null;
		}
	}
}
