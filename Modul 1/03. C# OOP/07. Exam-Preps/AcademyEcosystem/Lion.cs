namespace AcademyEcosystem
{
	public class Lion : Animal, ICarnivore
	{
		public Lion(string name, Point location)
			: base(name, location, 6) { }

		public int TryEatAnimal(Animal animal)
		{
			if (animal != null &&
			    2 * this.Size >= animal.Size)
			{
				this.Size += 1;
				return animal.GetMeatFromKillQuantity();
			}

			return 0;
		}
	}
}