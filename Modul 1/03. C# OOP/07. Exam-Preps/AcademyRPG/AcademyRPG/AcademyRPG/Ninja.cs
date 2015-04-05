using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{
	public class Ninja : Character, IFighter, IGatherer
	{
		public Ninja(string name, Point position, int owner)
			: base(name, position, owner)
		{
			this.HitPoints = 1;
			this.AttackPoints = 0;
		}

		public int AttackPoints { get; private set; }

		public int DefensePoints
		{
			get { return int.MaxValue; }
		}

		public new bool IsDestroyed
		{
			get { return false; }
		}

		public int GetTargetIndex(List<WorldObject> availableTargets)
		{
			for (var i = 0; i < availableTargets.Count; i++)
			{
				if (availableTargets[i].Owner != this.Owner &&
				    availableTargets[i].Owner != 0 &&
				    availableTargets[i].HitPoints == availableTargets.Max(t => t.HitPoints))
				{
					return i;
				}
			}

			return -1;
		}

		public bool TryGather(IResource resource)
		{
			switch (resource.Type)
			{
				case ResourceType.Lumber:
					this.AttackPoints += resource.Quantity;
					return true;
				case ResourceType.Stone:
					this.AttackPoints += resource.Quantity * 2;
					return true;
			}

			return false;
		}
	}
}