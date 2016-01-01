using System;

/// <summary>
/// Applies the version attribute to a sample class and displays its version at runtime.
/// </summary>
[Version("2.7.1 Alpha")]
class VersionAttributeTester
{
	static void Main()
	{
		object[] attributes = typeof(VersionAttributeTester).GetCustomAttributes(false);
		Console.WriteLine("Version: {0}", attributes[0]);
	}
}