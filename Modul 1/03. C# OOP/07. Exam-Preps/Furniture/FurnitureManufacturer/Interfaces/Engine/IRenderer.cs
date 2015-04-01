using System.Collections.Generic;

namespace FurnitureManufacturer.Interfaces.Engine
{
	public interface IRenderer
	{
		IEnumerable<string> Input();
		void Output(IEnumerable<string> output);
	}
}