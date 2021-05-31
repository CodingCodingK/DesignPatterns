using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeCopy
{
	class Program
	{
		static void Main(string[] args)
		{
			Resume r1 = new Resume("Sim");
			
			r1.SetPersonalInfo("Man","21");
			r1.SetWorkExperience("1998-2000", "XDWL");

			Resume r2 = (Resume)r1.Clone();
			r2.SetWorkExperience("2001-2005","Bilibili");

			Resume r3 = (Resume)r2.Clone();
			r3.SetWorkExperience("2006-now", "Mihoyo");

			r1.Display();
			r2.Display();
			r3.Display();

			Console.Read();
		}
	}

	// 实现ICloneable接口来达成复制的目的。
	// MemberwiseClone():复制值类型时会逐个复制（包括特殊类型string）
	// 使用MemberwiseClone()浅表复制方法的如上特性，实现一个类内有浅、深不同拷贝策略的情况

	public class WorkExperience : ICloneable
	{
		public string workDate;
		public string company;

		public object Clone()
		{
			return (object)MemberwiseClone();
		}
	}

	public class Resume : ICloneable
	{
		private string name;
		private string sex;
		private string age;
		private WorkExperience work;

		public Resume(string n)
		{
			name = n;
			work = new WorkExperience();
		}

		// 提供给内部使用的深拷贝方法
		private Resume(WorkExperience we)
		{
			this.work = (WorkExperience)we.Clone();
		}

		public void SetWorkExperience(string a, string b)
		{
			work.workDate = a;
			work.company = b;
		}

		public void SetPersonalInfo(string a,string b)
		{
			sex = a;
			age = b;
		}

		public void Display()
		{
			Console.WriteLine("Resume Name:{0},Sex:{1},Age:{2},ExpDate:{3},ExpCompany:{4}",name,sex,age,work.workDate,work.company);
		}

		public object Clone()
		{
			Resume obj = new Resume(this.work);
			obj.name = name;
			obj.sex = sex;
			obj.age = age;
			return obj;
		}
	}

}
