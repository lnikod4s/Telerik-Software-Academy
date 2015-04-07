namespace TradeAndTravel
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var engine = new Engine(new InteractionManager());
			engine.Start();
		}
	}
}