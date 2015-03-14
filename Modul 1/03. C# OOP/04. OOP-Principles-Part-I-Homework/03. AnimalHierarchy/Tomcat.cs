using System;

namespace _03.AnimalHierarchy
{
	class Tomcat : Cat
	{
		public Tomcat(string name, byte age) 
			: base(name, age, true) { }

		#region Overrides of Cat

		public override void SaySomething()
		{
			Console.WriteLine("Tomcat miao, miao, miao...");
		}

		#endregion
	}
}
