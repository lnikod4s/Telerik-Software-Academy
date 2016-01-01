namespace AcademyEcosystem
{
	public class Grass : Plant
	{
		public Grass(Point location)
			: base(location, 2) { }

		public override void Update(int timeElapsed)
		{
			if (this.IsAlive)
			{
				this.Size += timeElapsed;
			}
		}
	}
}