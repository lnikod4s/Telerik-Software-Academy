namespace _04.PersonClass
{
	class Person
	{
		// Fields
		private byte? age;
		private string name;

		// Constructors
		public Person() { }
		public Person(string name, byte? age)
		{
			this.Name = name;
			this.Age = age;
		}

		// Properties
		public byte? Age { get; private set; }
		public string Name { get; private set; }

		#region Overrides of Object

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			if (this.Age != null)
			{
				return string.Format("[Name: {0}, Age: {1}]", this.Name, this.Age);
			}
			else
			{
				return string.Format("[Name: {0}, Age: {1}]", this.Name, "unknown");
			}
		}
		#endregion
	}
}
