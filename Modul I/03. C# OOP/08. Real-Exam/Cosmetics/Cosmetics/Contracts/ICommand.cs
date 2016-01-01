using System.Collections.Generic;

namespace Cosmetics.Contracts
{
	internal interface ICommand
	{
		string Name { get; }
		IList<string> Parameters { get; }
	}
}