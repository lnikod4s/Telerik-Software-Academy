using Cosmetics.Common;

namespace Cosmetics.Contracts
{
	public interface IShampoo : IProduct
	{
		uint Milliliters { get; }
		UsageType Usage { get; }
	}
}