using System.Collections.Generic;

namespace FurnitureManufacturer.Interfaces.Engine
{
	public interface ICommand
	{
		string Name { get; }
		IList<string> Parameters { get; }
	}
}