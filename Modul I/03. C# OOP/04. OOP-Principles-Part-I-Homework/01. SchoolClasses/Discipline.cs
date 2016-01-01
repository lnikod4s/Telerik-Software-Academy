using System;

namespace _01.SchoolClasses
{
	class Discipline
	{
		// Fields
		private string name;
		private byte numberOfLectures;
		private byte numberOfExercies;

		// Constructors => protected in abstract classes
		protected Discipline() { }

		protected Discipline(string name, byte numberOfLectures, byte numberOfExercies)
		{
			this.Name = name;
			this.NumberOfLectures = numberOfLectures;
			this.NumberOfExercises = numberOfExercies;
		}

		// Properties => can be made protected in abstract classes
		protected string Name { get; set; }

		protected byte NumberOfLectures { get; set; }

		protected byte NumberOfExercises { get; set; }
	}
}
