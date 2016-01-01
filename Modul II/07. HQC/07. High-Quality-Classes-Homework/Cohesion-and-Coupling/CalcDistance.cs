﻿using System;

namespace CohesionAndCoupling
{
	internal class CalcDistance
	{
		internal static double CalcDistance2D(double x1, double y1, double x2, double y2)
		{
			var distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			return distance;
		}

		internal static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
		{
			var distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
			return distance;
		}
	}
}