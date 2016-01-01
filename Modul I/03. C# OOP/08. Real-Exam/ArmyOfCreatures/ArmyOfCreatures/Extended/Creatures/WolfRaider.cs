﻿using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures
{
	public class WolfRaider : Creature
	{
		public WolfRaider()
			: base(8, 5, 10, 3.5M) { this.AddSpecialty(new DoubleDamage(7)); }
	}
}