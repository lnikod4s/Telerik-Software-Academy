namespace CohesionAndCoupling
{
	internal static class Utils
	{
		internal static double Width { get; set; }
		internal static double Height { get; set; }
		internal static double Depth { get; set; }

		internal static double CalcVolume()
		{
			var volume = Width * Height * Depth;
			return volume;
		}

		internal static double CalcDiagonalXYZ()
		{
			var distance = CalcDistance.CalcDistance3D(0, 0, 0, Width, Height, Depth);
			return distance;
		}

		internal static double CalcDiagonalXY()
		{
			var distance = CalcDistance.CalcDistance2D(0, 0, Width, Height);
			return distance;
		}

		internal static double CalcDiagonalXZ()
		{
			var distance = CalcDistance.CalcDistance2D(0, 0, Width, Depth);
			return distance;
		}

		internal static double CalcDiagonalYZ()
		{
			var distance = CalcDistance.CalcDistance2D(0, 0, Height, Depth);
			return distance;
		}
	}
}