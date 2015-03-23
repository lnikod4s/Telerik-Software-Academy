using System;
using System.Collections.Generic;

namespace DefineClasses
{
	public class GSMTest
	{
		public static void TestExecutor()
		{
			var phones = new[]
						 {
							 new GSM("One M8", "HTC", 658.99, "Zdravko Zheliazkov", new Battery(BatteryType.NiMH, "16:45", "04:56"), new Display(5.1, 16000000), new List<Call>()),
							 new GSM("Galaxy S6", "Samsung", 833.99, "Blagoi Georgiergiev", new Battery(BatteryType.NiMH, "20:00", "05:34"), new Display(5.0, 16000000), new List<Call>()),
							 GSM.IPhone4S, 
							 new GSM("Xperia Z1", "Sony", 559.99, "Lyudmil Nikodimov", new Battery(BatteryType.LiPoly, "25:00", "06:45"), new Display(5.0, 16000000), new List<Call>()),
							 new GSM("G3", "LG", 459.89, "Radostin Kishishev", new Battery(BatteryType.NiCd, "23:43", "05:23"), new Display(5.2, 16000000), new List<Call>()) 
						 };

			foreach (var phone in phones)
			{
				Console.WriteLine(phone);
			}
		}
	}
}