using System;
/*Problem 2. Print Company Information
------------------------------------------------------------------------------------------------------------------------
A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number.
Write a program that reads the information about a company and its manager and prints it back on the console.

Example input:

program					user
Company name:			Telerik Academy
Company address:		31 Al. Malinov, Sofia
Phone number:			+359 888 55 55 555
Fax number:				2
Web site:				http://telerikacademy.com/
Manager first name:		Nikolay
Manager last name:		Kostov
Manager age:			25
Manager phone:			+359 2 981 981

Example output:

Telerik Academy
Address: 231 Al. Malinov, Sofia
Tel. +359 888 55 55 555
Fax: (no fax)
Web site: http://telerikacademy.com/
Manager: Nikolay Kostov (age: 25, tel. +359 2 981 981)  
*/

class PrintCompanyInformation
{
	static void Main()
	{
		Console.WriteLine("Please enter a company name: ");
		string companyName = Console.ReadLine();
		Console.WriteLine("Please enter a company address: ");
		string companyAddress = Console.ReadLine();
		Console.WriteLine("Please enter a phone number: ");
		string phoneNumber = Console.ReadLine();
		Console.WriteLine("Please enter a fax number: ");
		string faxNumber = Console.ReadLine();
		Console.WriteLine("Please enter a website: ");
		string webSite = Console.ReadLine();
		Console.WriteLine("Please enter a manager first name: ");
		string firstName = Console.ReadLine();
		Console.WriteLine("Please enter a manager last name: ");
		string lastName = Console.ReadLine();
		Console.WriteLine("Please enter a manager age: ");
		int age = int.Parse(Console.ReadLine());
		Console.WriteLine("Please enter a manager phone number: ");
		string managerPhone = Console.ReadLine();

		Console.WriteLine(companyName);
		Console.WriteLine("Address: {0}", companyAddress);
		Console.WriteLine("Tel. {0}", phoneNumber);
		Console.WriteLine("Fax: {0}", faxNumber.Length >= 18 ? faxNumber : "(no fax)");
		Console.WriteLine("Web Site: {0}", webSite);
		Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", firstName, lastName, age, managerPhone);
	}
}