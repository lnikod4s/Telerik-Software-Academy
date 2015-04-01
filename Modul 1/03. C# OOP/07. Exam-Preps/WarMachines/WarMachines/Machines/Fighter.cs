using WarMachines.Interfaces;

namespace WarMachines.Machines
{
	public class Fighter : Machine, IFighter
	{
		private bool stealthMode;

		public Fighter(string name, double attackPoints, double defensePoints, bool initialStealthMode)
			: base(name, 200, attackPoints, defensePoints)
		{
			this.StealthMode = initialStealthMode;
		}

		public bool StealthMode
		{
			get { return this.stealthMode; }

			private set { this.stealthMode = value; }
		}

		public void ToggleStealthMode()
		{
			if (this.StealthMode)
			{
				this.StealthMode = false;
			}
			else
			{
				this.StealthMode = true;
			}
		}

		public override string ToString()
		{
			return base.ToString() + string.Format("\n *Stealth: {0}", this.StealthMode ? "ON" : "OFF");
		}
	}
}