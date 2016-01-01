using System;

class GSMTester
{
	static void Main()
	{
		GSMTest();
		GSMCallHistoryTest();
	}

	private static void GSMCallHistoryTest()
	{
		GSM testGSM = new GSM("Nokia", "Telerik - A Progress Company");

		testGSM.AddCall("+359873432142", 53);
		testGSM.AddCall("+359811432142", 123);
		testGSM.AddCall("+359872412142", 41);
		testGSM.AddCall("+359833332142", 72);
		testGSM.AddCall("+359614432142", 231);

		testGSM.ShowCallHistory();

		Console.WriteLine("Total call price: " + testGSM.TotalCallPrice());

		testGSM.DeleteCall(5);
		Console.WriteLine("Longest call was removed.");

		Console.WriteLine("Total call price: " + testGSM.TotalCallPrice());

		testGSM.ClearCallHistory();
		Console.WriteLine("Call history was removed.");
		testGSM.ShowCallHistory();
	}

	private static void GSMTest()
	{
		GSM test1 = new GSM("Samsung", "Samsung C&T Corporation", 140000, "HappyOwner", 
					new Battery("High-Tech-Battery", 1000, 10000, Battery.Type.Unknown), 
					new Display(1000, 1000, 16000000));

		GSM test2 = new GSM("Nokia", "Microsoft Corporation");

		GSM test3 = new GSM("Sony", "Sony Corporation", 100, "Me&Myself", new Battery(), new Display());

		GSM[] allPhones = { test1, test2, test3 };

		foreach (var gsm in allPhones)
		{
			Console.WriteLine(gsm);
		}

		Console.WriteLine(GSM.IPhone4S);
	}
}