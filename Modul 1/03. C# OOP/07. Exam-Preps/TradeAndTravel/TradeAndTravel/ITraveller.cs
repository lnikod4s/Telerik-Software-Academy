namespace TradeAndTravel
{
	public interface ITraveller
	{
		Location Location { get; }
		void TravelTo(Location location);
	}
}