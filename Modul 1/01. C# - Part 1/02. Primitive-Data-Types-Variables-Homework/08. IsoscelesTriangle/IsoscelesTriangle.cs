using System;
/*Problem 8. Isosceles Triangle
------------------------------------------------------------------------------------------------------------------------
Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
   ©

  © ©

 ©   ©

© © © ©
Note: The © symbol may be displayed incorrectly at the console so you may need to change the console character encoding to UTF-8 and assign a Unicode-friendly font in the console.

Note: Under old versions of Windows the © symbol may still be displayed incorrectly, regardless of how much effort you put to fix it.
*/

class IsoscelesTriangle
{
	static void Main()
	{
		const char copyrightSign = '\u00a9';
		const string whitespace = " ";
		Console.WriteLine("{1}{1}{1}{0}{1}{1}{1}", copyrightSign, whitespace);
		Console.WriteLine("{1}{1}{0}{1}{0}{1}{1}", copyrightSign, whitespace);
		Console.WriteLine("{1}{0}{1}{1}{1}{0}{1}", copyrightSign, whitespace);
		Console.WriteLine("{0}{1}{0}{1}{0}{1}{0}", copyrightSign, whitespace);
	}
}
