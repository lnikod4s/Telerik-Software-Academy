using WarMachines.Interfaces;

namespace WarMachines.Machines
{
	public class Tank : Machine, ITank
	{
		private bool defenseMode;

		public Tank(string name, double attackPoints, double defensePoints)
			: base(name, 100, attackPoints, defensePoints)
		{
			this.DefenseMode = true;
			this.DefensePoints += 30;
			this.AttackPoints -= 40;
		}

		public bool DefenseMode
		{
			get { return this.defenseMode; }

			private set { this.defenseMode = value; }
		}

		public void ToggleDefenseMode()
		{
			if (this.DefenseMode)
			{
				this.DefenseMode = false;
				this.DefensePoints -= 30;
				this.AttackPoints += 40;
			}
			else
			{
				this.DefenseMode = true;
				this.DefensePoints += 30;
				this.AttackPoints -= 40;
			}
		}

		public override string ToString()
		{
			return base.ToString() + string.Format("\n *Defense: {0}", this.DefenseMode ? "ON" : "OFF");
		}
	}
}