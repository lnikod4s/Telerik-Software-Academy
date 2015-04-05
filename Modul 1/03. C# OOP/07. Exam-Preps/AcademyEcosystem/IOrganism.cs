namespace AcademyEcosystem
{
	public interface IOrganism
	{
		bool IsAlive { get; }
		Point Location { get; }
		int Size { get; }
		void Update(int timeElapsed);
	}
}