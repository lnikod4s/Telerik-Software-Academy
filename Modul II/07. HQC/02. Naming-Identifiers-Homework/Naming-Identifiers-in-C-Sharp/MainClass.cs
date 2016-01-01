namespace Naming_Identifiers_in_C_Sharp
{
	public class MainClass
	{
		enum Sex { Male, Female };

		class Person
		{
			public Sex PersonSex { get; set; }
			public string PersonName { get; set; }
			public int PersonAge { get; set; }
		}

		public void GeneratePerson(int personID)
		{
			var newPerson = new Person { PersonAge = personID };

			if (personID % 2 == 0)
			{
				newPerson.PersonName = "Man";
				newPerson.PersonSex = Sex.Male;
			}
			else
			{
				newPerson.PersonName = "Woman";
				newPerson.PersonSex = Sex.Female;
			}
		}
	}
}
