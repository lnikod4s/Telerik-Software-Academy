using System.Globalization;
using System.Threading;
using FurnitureManufacturer.Engine;

namespace FurnitureManufacturer
{
	public class FurnitureProgram
	{
		public static void Main()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			FurnitureManufacturerEngine.Instance.Start();
		}
	}
}