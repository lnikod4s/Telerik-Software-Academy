using System;

namespace CohesionAndCoupling
{
	internal class File
	{
		internal static string GetFileExtension(string fileName)
		{
			var indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
			if (indexOfLastDot == -1)
			{
				return "";
			}

			var extension = fileName.Substring(indexOfLastDot + 1);
			return extension;
		}

		internal static string GetFileNameWithoutExtension(string fileName)
		{
			var indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
			if (indexOfLastDot == -1)
			{
				return fileName;
			}

			var extension = fileName.Substring(0, indexOfLastDot);
			return extension;
		}
	}
}