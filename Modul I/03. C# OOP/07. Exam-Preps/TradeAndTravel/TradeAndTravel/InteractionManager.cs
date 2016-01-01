using System;
using System.Collections.Generic;
using System.Linq;

namespace TradeAndTravel
{
	public class InteractionManager
	{
		private const int InitialPersonMoney = 100;
		protected Dictionary<string, Location> locationByName = new Dictionary<string, Location>();
		protected HashSet<Location> locations = new HashSet<Location>();
		protected Dictionary<Person, int> moneyByPerson = new Dictionary<Person, int>();
		protected Dictionary<Item, Person> ownerByItem = new Dictionary<Item, Person>();
		protected HashSet<Person> people = new HashSet<Person>();
		protected Dictionary<Location, List<Person>> peopleByLocation = new Dictionary<Location, List<Person>>();
		protected Dictionary<string, Person> personByName = new Dictionary<string, Person>();
		protected Dictionary<Location, List<Item>> strayItemsByLocation = new Dictionary<Location, List<Item>>();

		public void HandleInteraction(string[] commandWords)
		{
			if (commandWords[0] == "create")
			{
				this.HandleCreationCommand(commandWords);
			}
			else
			{
				var actor = this.personByName[commandWords[0]];

				this.HandlePersonCommand(commandWords, actor);
			}
		}

		protected virtual void HandlePersonCommand(string[] commandWords, Person actor)
		{
			switch (commandWords[1])
			{
				case "drop":
					this.HandleDropInteraction(actor);
					break;
				case "pickup":
					this.HandlePickUpInteraction(actor);
					break;
				case "sell":
					this.HandleSellInteraction(commandWords, actor);
					break;
				case "buy":
					this.HandleBuyInteraction(commandWords, actor);
					break;
				case "inventory":
					this.HandleListInventoryInteraction(actor);
					break;
				case "money":
					Console.WriteLine(this.moneyByPerson[actor]);
					break;
				case "travel":
					this.HandleTravelInteraction(commandWords, actor);
					break;
				case "gather":
					this.HandleGatherInteraction(actor, commandWords[2]);
					break;
				case "craft":
					this.HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
					break;
				default:
					break;
			}
		}

		private void HandleCraftInteraction(Person actor, string craftedItemType, string craftedItemName)
		{
			switch (craftedItemType)
			{
				case "armor":
					this.CraftArmor(actor, craftedItemName);
					break;
				case "weapon":
					this.CraftWeapon(actor, craftedItemName);
					break;
			}
		}

		private void CraftWeapon(Person actor, string craftedItemName)
		{
			var actorInventory = actor.ListInventory();
			if (actorInventory.Any((item) => item.ItemType == ItemType.Iron) &&
				actorInventory.Any((item) => item.ItemType == ItemType.Wood))
			{
				this.AddToPerson(actor, new Weapon(craftedItemName));
			}
		}

		private void CraftArmor(Person actor, string craftedItemName)
		{
			var actorInventory = actor.ListInventory();
			if (actorInventory.Any((item) => item.ItemType == ItemType.Iron))
			{
				this.AddToPerson(actor, new Armor(craftedItemName));
			}
		}

		private void HandleGatherInteraction(Person actor, string gatheredItemName)
		{
			var gatheringLocation = actor.Location as IGatheringLocation;
			if (gatheringLocation != null)
			{
				var actorInventory = actor.ListInventory();
				bool hasRequiredItem = actorInventory.Any(i => i.ItemType == gatheringLocation.RequiredItem);

				if (hasRequiredItem)
				{
					var producedItem = gatheringLocation.ProduceItem(gatheredItemName);
					this.AddToPerson(actor, producedItem);
				}
			}
		}

		private void HandleTravelInteraction(string[] commandWords, Person actor)
		{
			var traveller = actor as ITraveller;
			if (traveller != null)
			{
				var targetLocation = this.locationByName[commandWords[2]];
				this.peopleByLocation[traveller.Location].Remove(actor);
				traveller.TravelTo(targetLocation);
				this.peopleByLocation[traveller.Location].Add(actor);

				foreach (var item in actor.ListInventory())
				{
					item.UpdateWithInteraction("travel");
				}
			}
		}

		private void HandleListInventoryInteraction(Person actor)
		{
			var inventory = actor.ListInventory();
			foreach (var item in inventory)
			{
				if (this.ownerByItem[item] == actor)
				{
					Console.WriteLine(item.Name);
					item.UpdateWithInteraction("inventory");
				}
			}

			if (inventory.Count == 0)
			{
				Console.WriteLine("empty");
			}
		}

		private void HandlePickUpInteraction(Person actor)
		{
			foreach (var item in this.strayItemsByLocation[actor.Location])
			{
				this.AddToPerson(actor, item);
				item.UpdateWithInteraction("pickup");
			}
			this.strayItemsByLocation[actor.Location].Clear();
		}

		private void HandleDropInteraction(Person actor)
		{
			foreach (var item in actor.ListInventory())
			{
				if (this.ownerByItem[item] == actor)
				{
					this.strayItemsByLocation[actor.Location].Add(item);
					this.RemoveFromPerson(actor, item);

					item.UpdateWithInteraction("drop");
				}
			}
		}

		private void HandleBuyInteraction(string[] commandWords, Person actor)
		{
			Item saleItem = null;
			var saleItemName = commandWords[2];
			var buyer = this.personByName[commandWords[3]] as Shopkeeper;

			if (buyer != null &&
				this.peopleByLocation[actor.Location].Contains(buyer))
			{
				foreach (var item in buyer.ListInventory())
				{
					if (this.ownerByItem[item] == buyer &&
						saleItemName == item.Name)
					{
						saleItem = item;
					}
				}

				var price = buyer.CalculateSellingPrice(saleItem);
				this.moneyByPerson[buyer] += price;
				this.moneyByPerson[actor] -= price;
				this.RemoveFromPerson(buyer, saleItem);
				this.AddToPerson(actor, saleItem);

				saleItem.UpdateWithInteraction("buy");
			}
		}

		private void HandleSellInteraction(string[] commandWords, Person actor)
		{
			Item saleItem = null;
			var saleItemName = commandWords[2];
			foreach (var item in actor.ListInventory())
			{
				if (this.ownerByItem[item] == actor &&
					saleItemName == item.Name)
				{
					saleItem = item;
				}
			}

			var buyer = this.personByName[commandWords[3]] as Shopkeeper;
			if (buyer != null &&
				this.peopleByLocation[actor.Location].Contains(buyer))
			{
				var price = buyer.CalculateBuyingPrice(saleItem);
				this.moneyByPerson[buyer] -= price;
				this.moneyByPerson[actor] += price;
				this.RemoveFromPerson(actor, saleItem);
				this.AddToPerson(buyer, saleItem);

				saleItem.UpdateWithInteraction("sell");
			}
		}

		protected void AddToPerson(Person actor, Item item)
		{
			actor.AddToInventory(item);
			this.ownerByItem[item] = actor;
		}

		protected void RemoveFromPerson(Person actor, Item item)
		{
			actor.RemoveFromInventory(item);
			this.ownerByItem[item] = null;
		}

		protected void HandleCreationCommand(string[] commandWords)
		{
			if (commandWords[1] == "item")
			{
				var itemTypeString = commandWords[2];
				var itemNameString = commandWords[3];
				var itemLocationString = commandWords[4];
				this.HandleItemCreation(itemTypeString, itemNameString, itemLocationString);
			}
			else if (commandWords[1] == "location")
			{
				var locationTypeString = commandWords[2];
				var locationNameString = commandWords[3];
				this.HandleLocationCreation(locationTypeString, locationNameString);
			}
			else
			{
				var personTypeString = commandWords[1];
				var personNameString = commandWords[2];
				var personLocationString = commandWords[3];
				this.HandlePersonCreation(personTypeString, personNameString, personLocationString);
			}
		}

		protected virtual void HandleLocationCreation(string locationTypeString, string locationName)
		{
			var location = this.CreateLocation(locationTypeString, locationName);

			this.locations.Add(location);
			this.strayItemsByLocation[location] = new List<Item>();
			this.peopleByLocation[location] = new List<Person>();
			this.locationByName[locationName] = location;
		}

		protected virtual void HandlePersonCreation(string personTypeString, string personNameString,
													string personLocationString)
		{
			var personLocation = this.locationByName[personLocationString];

			var person = this.CreatePerson(personTypeString, personNameString, personLocation);

			this.personByName[personNameString] = person;
			this.peopleByLocation[personLocation].Add(person);
			this.moneyByPerson[person] = InitialPersonMoney;
		}

		protected virtual void HandleItemCreation(string itemTypeString, string itemNameString, string itemLocationString)
		{
			var itemLocation = this.locationByName[itemLocationString];

			Item item = null;
			item = this.CreateItem(itemTypeString, itemNameString, itemLocation, item);

			this.ownerByItem[item] = null;
			this.strayItemsByLocation[itemLocation].Add(item);
		}

		protected virtual Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
		{
			switch (itemTypeString)
			{
				case "armor":
					item = new Armor(itemNameString, itemLocation);
					break;
				case "weapon":
					item = new Weapon(itemNameString, itemLocation);
					break;
				case "wood":
					item = new Wood(itemNameString, itemLocation);
					break;
				case "iron":
					item = new Iron(itemNameString, itemLocation);
					break;
				default:
					break;
			}
			return item;
		}

		protected virtual Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
		{
			Person person = null;
			switch (personTypeString)
			{
				case "shopkeeper":
					person = new Shopkeeper(personNameString, personLocation);
					break;
				case "traveller":
					person = new Traveller(personNameString, personLocation);
					break;
				case "merchant":
					person = new Merchant(personNameString, personLocation);
					break;
				default:
					break;
			}
			return person;
		}

		protected virtual Location CreateLocation(string locationTypeString, string locationName)
		{
			Location location = null;
			switch (locationTypeString)
			{
				case "town":
					location = new Town(locationName);
					break;
				case "forest":
					location = new Forest(locationName);
					break;
				case "mine":
					location = new Forest(locationName);
					break;
				default:
					break;
			}
			return location;
		}
	}
}