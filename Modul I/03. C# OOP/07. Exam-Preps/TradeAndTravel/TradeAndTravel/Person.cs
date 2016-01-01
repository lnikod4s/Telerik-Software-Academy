﻿using System.Collections.Generic;

namespace TradeAndTravel
{
	public class Person : WorldObject
	{
		private readonly HashSet<Item> inventoryItems;

		public Person(string name, Location location)
			: base(name)
		{
			this.Location = location;
			this.inventoryItems = new HashSet<Item>();
		}

		public Location Location { get; protected set; }
		public void AddToInventory(Item item) { this.inventoryItems.Add(item); }
		public void RemoveFromInventory(Item item) { this.inventoryItems.Remove(item); }

		public List<Item> ListInventory()
		{
			var items = new List<Item>();
			foreach (var item in this.inventoryItems)
			{
				items.Add(item);
			}

			return items;
		}
	}
}