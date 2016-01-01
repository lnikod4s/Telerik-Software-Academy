using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures
{
	public class CyclopsKing : Creature
	{
		public CyclopsKing()
			: base(17, 13, 70, 18M)
		{
			this.AddSpecialty(new AddAttackWhenSkip(3));
			this.AddSpecialty(new DoubleAttackWhenAttacking(4));
			this.AddSpecialty(new DoubleDamage(1));
		}
	}
}