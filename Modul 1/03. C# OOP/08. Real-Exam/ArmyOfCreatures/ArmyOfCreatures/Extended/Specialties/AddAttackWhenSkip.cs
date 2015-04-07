using System;
using System.Globalization;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures
{
	public class AddAttackWhenSkip : Specialty
	{
		private readonly int additionalAttack;

		public AddAttackWhenSkip(int additionalAttack)
		{
			if (additionalAttack <= 0 ||
			    additionalAttack > 10)
			{
				throw new ArgumentOutOfRangeException("additionalAttack", "The additional attack should be in the range (0;10].");
			}

			this.additionalAttack = additionalAttack;
		}

		public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
		{
			if (skipCreature == null)
			{
				throw new ArgumentNullException("skipCreature");
			}

			skipCreature.PermanentAttack += this.additionalAttack;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.additionalAttack);
		}
	}
}