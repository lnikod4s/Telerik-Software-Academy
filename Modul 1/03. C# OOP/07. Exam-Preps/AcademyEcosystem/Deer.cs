namespace AcademyEcosystem
{
	public class Deer : Animal, IHerbivore
	{
		private readonly int biteSize;

		public Deer(string name, Point location)
			: base(name, location, 3) { this.biteSize = 1; }

		public int EatPlant(Plant p)
		{
			if (p != null)
			{
				return p.GetEatenQuantity(this.biteSize);
			}

			return 0;
		}

		public override void Update(int timeElapsed)
		{
			if (this.State == AnimalState.Sleeping)
			{
				if (timeElapsed >= this.sleepRemaining)
				{
					this.Awake();
				}
				else
				{
					this.sleepRemaining -= timeElapsed;
				}
			}

			base.Update(timeElapsed);
		}
	}
}