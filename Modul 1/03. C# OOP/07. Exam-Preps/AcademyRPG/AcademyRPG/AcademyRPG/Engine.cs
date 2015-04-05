using System;
using System.Collections.Generic;

namespace AcademyRPG
{
	public class Engine
	{
		public static readonly char[] separators = {' '};
		protected List<WorldObject> allObjects;
		protected List<IControllable> controllables;
		protected List<IResource> resources;
		//protected List<IGatherer> gatherers;
		//protected List<IFighter> fighters;

		public Engine()
		{
			this.allObjects = new List<WorldObject>();
			this.controllables = new List<IControllable>();
			this.resources = new List<IResource>();
			//this.gatherers = new List<IGatherer>();
			//this.fighters = new List<IFighter>();
		}

		public void AddObject(WorldObject obj)
		{
			this.allObjects.Add(obj);

			var objAsControllable = obj as IControllable;
			if (objAsControllable != null)
			{
				this.controllables.Add(objAsControllable);
			}

			var objAsResource = obj as IResource;
			if (objAsResource != null)
			{
				this.resources.Add(objAsResource);
			}

			//IGatherer objAsGatherer = obj as IGatherer;
			//if (objAsGatherer != null)
			//{
			//    this.gatherers.Add(objAsGatherer);
			//}

			//IFighter objAsFighter = obj as IFighter;
			//if (objAsFighter != null)
			//{
			//    this.fighters.Add(objAsFighter);
			//}
		}

		private void RemoveDestroyed()
		{
			this.allObjects.RemoveAll(obj => obj.IsDestroyed);
			this.controllables.RemoveAll(obj => obj.IsDestroyed);
			this.resources.RemoveAll(obj => obj.IsDestroyed);
			//this.gatherers.RemoveAll(obj => obj.IsDestroyed);
			//this.fighters.RemoveAll(obj => obj.IsDestroyed);
		}

		public void ExecuteCommand(string command)
		{
			var commandWords = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			if (commandWords[0] == "create")
			{
				this.ExecuteCreateObjectCommand(commandWords);
			}
			else
			{
				this.ExecuteControllableCommand(commandWords);
			}

			this.RemoveDestroyed();
		}

		public virtual void ExecuteCreateObjectCommand(string[] commandWords)
		{
			switch (commandWords[1])
			{
				case "lumberjack":
				{
					var name = commandWords[2];
					var position = Point.Parse(commandWords[3]);
					var owner = int.Parse(commandWords[4]);
					this.AddObject(new Lumberjack(name, position, owner));
					break;
				}
				case "guard":
				{
					var name = commandWords[2];
					var position = Point.Parse(commandWords[3]);
					var owner = int.Parse(commandWords[4]);
					this.AddObject(new Guard(name, position, owner));
					break;
				}
				case "tree":
				{
					var size = int.Parse(commandWords[2]);
					var position = Point.Parse(commandWords[3]);
					this.AddObject(new Tree(size, position));
					break;
				}
			}
		}

		public virtual void ExecuteControllableCommand(string[] commandWords)
		{
			var controllableName = commandWords[0];
			IControllable current = null;

			for (var i = 0; i < this.controllables.Count; i++)
			{
				if (controllableName == this.controllables[i].Name)
				{
					current = this.controllables[i];
				}
			}

			if (current != null)
			{
				switch (commandWords[1])
				{
					case "go":
					{
						this.HandleGoCommand(commandWords, current);
						break;
					}
					case "attack":
					{
						this.HandleAttackCommand(current);
						break;
					}
					case "gather":
					{
						this.HandleGatherCommand(current);
						break;
					}
				}
			}
		}

		private void HandleGatherCommand(IControllable current)
		{
			var currentAsGatherer = current as IGatherer;
			if (currentAsGatherer != null)
			{
				//List<WorldObject> objectsAtGathererPosition = new List<WorldObject>();
				IResource resource = null;
				foreach (var obj in this.resources)
				{
					if (obj.Position == current.Position)
					{
						resource = obj;
						break;
					}
				}

				if (resource != null)
				{
					this.HandleGathering(currentAsGatherer, resource);
				}
				else
				{
					Console.WriteLine("No resource to gather at {0}'s position", current);
				}
			}
			else
			{
				Console.WriteLine("{0} can't do that", current);
			}
		}

		private void HandleAttackCommand(IControllable current)
		{
			var currentAsFighter = current as IFighter;
			if (currentAsFighter != null)
			{
				var availableTargets = new List<WorldObject>();
				foreach (var obj in this.allObjects)
				{
					if (obj.Position == current.Position)
					{
						availableTargets.Add(obj);
					}
				}

				var targetIndex = currentAsFighter.GetTargetIndex(availableTargets);
				if (targetIndex != -1)
				{
					this.HandleBattle(currentAsFighter, availableTargets[targetIndex]);
				}
				else
				{
					Console.WriteLine("No targets to attack at {0}'s position", current);
				}
			}
			else
			{
				Console.WriteLine("{0} can't do that", current);
			}
		}

		private void HandleGathering(IGatherer gatherer, IResource resource)
		{
			var gatheringSuccess = gatherer.TryGather(resource);
			if (gatheringSuccess)
			{
				Console.WriteLine("{0} gathered {1} {2} from {3}", gatherer, resource.Quantity, resource.Type, resource);
				resource.HitPoints = 0;
			}
		}

		private void HandleBattle(IFighter attacker, WorldObject defender)
		{
			var defenderAsFighter = defender as IFighter;
			var defenderDefensePoints = 0;
			if (defenderAsFighter != null)
			{
				defenderDefensePoints = defenderAsFighter.DefensePoints;
			}

			var damage = attacker.AttackPoints - defenderDefensePoints;

			if (damage < 0)
			{
				damage = 0;
			}

			if (damage > defender.HitPoints)
			{
				damage = defender.HitPoints;
			}

			defender.HitPoints -= damage;

			Console.WriteLine("{0} attacked {1} and did {2} damage", attacker, defender, damage);
		}

		private void HandleGoCommand(string[] commandWords, IControllable current)
		{
			var currentAsMoving = current as MovingObject;
			currentAsMoving.GoTo(Point.Parse(commandWords[2]));
			Console.WriteLine("{0} is now at position {1}", current, current.Position);
		}
	}
}