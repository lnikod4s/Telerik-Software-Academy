namespace TradeAndTravel
{
	public class Weapon : Item
	{
		public Weapon(string name, Location location = null)
			: base(name, 10, ItemType.Weapon, location) { }
	}
}
