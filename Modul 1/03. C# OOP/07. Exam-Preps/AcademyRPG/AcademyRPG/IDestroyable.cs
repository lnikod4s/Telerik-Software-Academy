namespace AcademyRPG
{
	public interface IWorldObject
	{
		bool IsDestroyed { get; }
		int HitPoints { get; set; }
		Point Position { get; }
	}
}