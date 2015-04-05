namespace AcademyEcosystem
{
	public class ExtendedEngine : Engine
	{
		protected override void ExecuteBirthCommand(string[] commandWords)
		{
			switch (commandWords[1])
			{
				case "wolf":
				{
					var name = commandWords[2];
					var position = Point.Parse(commandWords[3]);
					this.AddOrganism(new Wolf(name, position));
					break;
				}
				default:
					base.ExecuteBirthCommand(commandWords);
					break;
			}
		}
	}
}