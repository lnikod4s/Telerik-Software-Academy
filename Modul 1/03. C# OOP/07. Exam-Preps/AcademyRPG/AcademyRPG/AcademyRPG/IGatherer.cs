namespace AcademyRPG
{
	public interface IGatherer : IControllable
	{
		bool TryGather(IResource resource);
	}
}