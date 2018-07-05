using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[] assemblyBytes = File.ReadAllBytes("ReflectionTest.exe");
			Assembly assembly = Assembly.Load(assemblyBytes);

			var methods = assembly.GetTypes()
								.SelectMany(t => t.GetMethods())
								.Where(m => m.GetCustomAttributes<FindableAttribute>().Any())
								.ToArray();

			foreach(var m in methods)
			{
				m.Invoke(Activator.CreateInstance(m.DeclaringType), new Object[] { });
			}

			Console.ReadKey();
		}
	}
}
