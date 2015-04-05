namespace AcademyRPG
{
	public class Rock : StaticObject, IResource
	{
		public Rock(int size, Point position)
			: base(position) { this.HitPoints = size; }

		public int Quantity
		{
			get { return this.HitPoints / 2; }
		}

		public ResourceType Type
		{
			get { return ResourceType.Stone; }
		}
	}
}