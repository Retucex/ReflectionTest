using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
	public class Car
	{
		public int Year { get; set; }
		public bool Running { get; private set; }

		public Car(int year, bool start)
		{
			Year = year;
			Running = start;
		}

		public Car(int year) : this(year, false) { }

		public Car(bool start) : this(0, start) { }

		public Car() : this(0, false) { }
		
		[Findable]
		public void Start()
		{
			if(Running)
			{
				Console.WriteLine("Car is already running!");
			}
			else
			{
				Running = true;
				Console.WriteLine("Car has started.");
			}
		}

		[Findable]
		public void Stop()
		{
			if (Running)
			{
				Running = false;
				Console.WriteLine("Car has stopped");
			}
			else
			{
				Console.WriteLine("Car is not running!");
			}
		}
	}
}
