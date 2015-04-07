using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures
{
	public class AncientBehemoth : Creature
	{
		public AncientBehemoth()
			: base(19, 19, 300, 40)
		{
			this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
			this.AddSpecialty(new DoubleDefenseWhenDefending(5));
		}
	}
}