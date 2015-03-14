using System;

namespace _03.AnimalHierarchy
{
	class Frog : Animal
	{
		 public Frog(string name, byte age, bool isMale) 
			 : base(name,age,isMale) { }

		#region Overrides of Animal

		public override void SaySomething()
		{
			Console.WriteLine("Rabbit, rabbit, rabbit...");
		}

		#endregion
	}
}
