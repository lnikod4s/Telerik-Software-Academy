using System;
using System.Collections.Generic;
using System.Linq;

namespace DefineClasses
{
	public class GSMCallHistoryTest
	{
		public static void TestExecutor()
		{
			var myGSM = new GSM("Xperia Z1", "Sony", 559.99, "Lyudmil Nikodimov",
																				new Battery(BatteryType.LiPoly, "25:00", "06:45"),
																				new Display(5.0, 16000000), new List<Call>());
			myGSM.AddCall(new Call(new DateTime(2015, 03, 23), "+4915209892427", 234.34));
			myGSM.AddCall(new Call(new DateTime(2015, 01, 19), "+4965464566425", 145.78));
			myGSM.AddCall(new Call(new DateTime(2015, 02, 16), "+4921542848464", 478.41));

			foreach (var call in myGSM.CallHistory)
			{
				Console.WriteLine(call);
			}

			Console.WriteLine(myGSM.CalculateOverallCallPrice(0.37M));
			myGSM.DeleteCall(myGSM.CallHistory.Last());
			Console.WriteLine(myGSM.CalculateOverallCallPrice(0.37M));
			myGSM.ClearCallHistory();

			foreach (var call in myGSM.CallHistory)
			{
				Console.WriteLine(call);
			}
		}
	}
}