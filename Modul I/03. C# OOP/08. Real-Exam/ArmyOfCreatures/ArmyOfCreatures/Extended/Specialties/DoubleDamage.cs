using System;
using System.Globalization;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures
{
	public class DoubleDamage : Specialty
	{
		private int rounds;

		public DoubleDamage(int rounds)
		{
			if (rounds <= 0 ||
			    rounds > 10)
			{
				throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
			}

			this.rounds = rounds;
		}

		public override decimal ChangeDamageWhenAttacking
			(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
		{
			if (attackerWithSpecialty == null)
			{
				throw new ArgumentNullException("defenderWithSpecialty");
			}

			if (defender == null)
			{
				throw new ArgumentNullException("attacker");
			}

			if (this.rounds <= 0 ||
			    this.rounds > 10)
			{
				// Effect expires after fixed number of rounds
				return currentDamage;
			}

			this.rounds--;
			return currentDamage * 2;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
		}
	}
}