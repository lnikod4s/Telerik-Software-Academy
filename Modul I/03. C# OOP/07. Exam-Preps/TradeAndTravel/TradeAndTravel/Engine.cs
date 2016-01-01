using System;

namespace TradeAndTravel
{
	public class Engine
	{
		protected InteractionManager interactionManager;
		public Engine(InteractionManager interactionManager) { this.interactionManager = interactionManager; }
		public void ParseAndDispatch(string command) { this.interactionManager.HandleInteraction(command.Split(' ')); }

		public void Start()
		{
			var endCommandReached = false;
			while (!endCommandReached)
			{
				var command = Console.ReadLine();
				if (command != "end")
				{
					this.ParseAndDispatch(command);
				}
				else
				{
					endCommandReached = true;
				}
			}
		}
	}
}