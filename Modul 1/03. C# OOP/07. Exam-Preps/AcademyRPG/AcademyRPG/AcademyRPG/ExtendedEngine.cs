namespace AcademyRPG
{
	public class ExtendedEngine : Engine
	{
		public override void ExecuteCreateObjectCommand(string[] commandWords)
		{
			switch (commandWords[1])
			{
				case "knight":
				{
					var name = commandWords[2];
					var position = Point.Parse(commandWords[3]);
					var owner = int.Parse(commandWords[4]);
					this.AddObject(new Knight(name, position, owner));
					break;
				}
				case "house":
				{
					var position = Point.Parse(commandWords[2]);
					var owner = int.Parse(commandWords[3]);
					this.AddObject(new House(position, owner));
					break;
				}
				case "giant":
				{
					var name = commandWords[2];
					var position = Point.Parse(commandWords[3]);
					this.AddObject(new Giant(name, position));
					break;
				}
				case "rock":
				{
					var hitPoints = int.Parse(commandWords[2]);
					var position = Point.Parse(commandWords[3]);
					this.AddObject(new Rock(hitPoints, position));
					break;
				}
				case "ninja":
				{
					var name = commandWords[2];
					var position = Point.Parse(commandWords[3]);
					var owner = int.Parse(commandWords[4]);
					this.AddObject(new Ninja(name, position, owner));
					break;
				}
				default:
					base.ExecuteCreateObjectCommand(commandWords);
					break;
			}
		}
	}
}