using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures
{
	public class ExtendedCreaturesFactory : CreaturesFactory
	{
		public override Creature CreateCreature(string name)
		{
			switch (name)
			{
				case "AncientBehemoth":
					return new AncientBehemoth();
				case "WolfRaider":
					return new WolfRaider();
				case "Goblin":
					return new Goblin();
				case "CyclopsKing":
					return new CyclopsKing();
				case "Griffin":
					return new Griffin();
				default:
					return base.CreateCreature(name);
			}
		}
	}
}