namespace TradeAndTravel
{
	public class Iron : Item
	{
		public Iron(string name, Location location = null)
			: base(name, 3, ItemType.Iron, location) { }
	}
}
