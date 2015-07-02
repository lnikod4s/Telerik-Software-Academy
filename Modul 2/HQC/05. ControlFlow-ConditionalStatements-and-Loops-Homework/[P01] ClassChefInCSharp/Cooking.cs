namespace ClassChefInCSharp
{
	public class Cooking
	{
		private Bowl GetBowl() { return new Bowl(); }
		private Carrot GetCarrot() { return new Carrot(); }
		private Potato GetPotato() { return new Potato(); }
		private void Cut(Potato potato) { }
		private void Cut(Carrot carrot) { }
		private void Peel(Potato potato) { }
		private void Peel(Carrot carrot) { }

		public void Cook()
		{
			var potato = this.GetPotato();
			var carrot = this.GetCarrot();
			var bowl = this.GetBowl();

			bowl.Add(carrot);
			bowl.Add(potato);

			this.Peel(potato);
			this.Peel(carrot);

			this.Cut(potato);
			this.Cut(carrot);
		}

		private static void Main() { }

		private struct Bowl
		{
			public void Add(Potato potato) { }
			public void Add(Carrot carrot) { }
		}

		private struct Carrot { }

		private struct Potato { }
	}
}