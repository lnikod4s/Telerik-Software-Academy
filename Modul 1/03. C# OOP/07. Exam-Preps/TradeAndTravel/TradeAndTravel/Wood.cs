namespace TradeAndTravel
{
	public class Wood : Item
	{
		public Wood(string name, Location location = null)
			: base(name, 2, ItemType.Wood, location) { }

		public override void UpdateWithInteraction(string interaction)
		{
			if (interaction == "drop")
			{
				if (this.Value > 0)
				{
					this.Value--;
				}
			}

			base.UpdateWithInteraction(interaction);
		}
	}
}
