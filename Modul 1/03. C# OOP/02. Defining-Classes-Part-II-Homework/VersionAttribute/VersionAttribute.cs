using System;

/// <summary>
/// Creates a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods 
/// and holds a version in the format major.minor (e.g. 2.11). 
/// </summary>
 [AttributeUsage(AttributeTargets.Struct | 
				 AttributeTargets.Class |
				 AttributeTargets.Interface | 
				 AttributeTargets.Enum | 
				 AttributeTargets.Method)]
public class VersionAttribute : Attribute
{
	public VersionAttribute(string version)
	{
		this.Version = version;
	}

	public string Version { get; private set; }

	public override string ToString()
	{
		return this.Version;
	}
}