﻿using System.Collections.Generic;

namespace AcademyRPG
{
	public class Guard : Character, IFighter
	{
		public Guard(string name, Point position, int owner)
			: base(name, position, owner) { this.HitPoints = 100; }

		public int AttackPoints
		{
			get { return 50; }
		}

		public int DefensePoints
		{
			get { return 20; }
		}

		public int GetTargetIndex(List<WorldObject> availableTargets)
		{
			for (var i = 0; i < availableTargets.Count; i++)
			{
				if (availableTargets[i].Owner != this.Owner &&
				    availableTargets[i].Owner != 0)
				{
					return i;
				}
			}

			return -1;
		}
	}
}