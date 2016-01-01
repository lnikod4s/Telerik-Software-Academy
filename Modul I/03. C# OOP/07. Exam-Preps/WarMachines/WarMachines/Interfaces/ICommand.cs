using System.Collections.Generic;

namespace WarMachines.Interfaces
{
	public interface ICommand
	{
		string Name { get; }
		IList<string> Parameters { get; }
	}
}