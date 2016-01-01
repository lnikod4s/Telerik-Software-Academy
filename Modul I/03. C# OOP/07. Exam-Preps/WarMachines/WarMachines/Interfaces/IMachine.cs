﻿using System.Collections.Generic;

namespace WarMachines.Interfaces
{
	public interface IMachine
	{
		string Name { get; set; }
		IPilot Pilot { get; set; }
		double HealthPoints { get; set; }
		double AttackPoints { get; }
		double DefensePoints { get; }
		IList<string> Targets { get; }
		void Attack(string target);
		string ToString();
	}
}