using System;
using System.Net;

/*Problem 4. Download file
-----------------------------------------------------------------------------------------------------------
Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
Find in Google how to download files in C#.
Be sure to catch all exceptions and to free any used resources in the finally block.
*/
class DownloadFile
{
	static void Main()
	{
		Console.WriteLine("Do you allow access of the program to download a picture from the web?\n");

		string userChoice = string.Empty;
		do
		{
			Console.Write("Enter your choice ([Y] / [N]): ");
			userChoice = Console.ReadLine();
		}
		while (userChoice.ToLower() != "n" && userChoice.ToLower() != "y");

		if (userChoice.ToLower() == "n")
		{
			return;
		}

		using (WebClient webClient = new WebClient())
		{
			try
			{
				Console.WriteLine("\nStart downloading...");

				webClient.DownloadFile("http://telerikacademy.com/Content/Images/news-img01.png", "../../Telerik-Ninja.png");

				Console.WriteLine("\n-> The download was sucessful!");
			}
			catch (ArgumentException)
			{
				Console.Error.WriteLine("\n-> Error: You have entered an empty URL!");
			}
			catch (WebException)
			{
				Console.Error.WriteLine("\n-> Error: You have entered an invalid URL!");
			}
			catch (NotSupportedException)
			{
				Console.Error.WriteLine("\n-> Error: This method does not support simultaneous downloads!");
			}
			finally
			{
				Console.WriteLine("\nGoodbye!\n");
			}
		}
	}
}