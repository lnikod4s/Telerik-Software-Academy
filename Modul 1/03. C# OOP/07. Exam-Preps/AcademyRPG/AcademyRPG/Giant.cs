using System.Collections.Generic;

namespace AcademyRPG
{
	public class Giant : Character, IFighter, IGatherer
	{
		private const int INITIAL_HIT_POINTS = 200;
		private const int INITIAL_ATTACK_POINTS = 150;
		private const int INITIAL_DEFENSE_POINTS = 80;
		private int attackPointsAccumulation;

		public Giant(string name, Point position)
			: base(name, position, 0)
		{
			this.HitPoints = INITIAL_HIT_POINTS;
			this.attackPointsAccumulation = 0;
		}

		public int AttackPoints
		{
			get { return INITIAL_ATTACK_POINTS + this.attackPointsAccumulation; }
		}

		public int DefensePoints
		{
			get { return INITIAL_DEFENSE_POINTS; }
		}

		public int GetTargetIndex(List<WorldObject> availableTargets)
		{
			for (var i = 0; i < availableTargets.Count; i++)
			{
				if (availableTargets[i].Owner != 0)
				{
					return i;
				}
			}

			return -1;
		}

		public bool TryGather(IResource resource)
		{
			if (resource.Type != ResourceType.Stone)
				return false;
			this.attackPointsAccumulation = 100;
			return true;
		}
	}
}