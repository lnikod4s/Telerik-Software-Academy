Homework: Exception Handling
============================

### Problem 1. Square root
*	Write a program that reads an integer number and calculates and prints its square root.
	*	If the number is invalid or negative, print `Invalid number`.
	*	In all cases finally print `Good bye`.
*	Use `try-catch-finally` block.

### Problem 2. Enter numbers
*	Write a method `ReadNumber(int start, int end)` that enters an integer number in a given range [`start�end`].
	*	If an invalid number or non-number text is entered, the method should throw an exception.
*	Using this method write a program that enters `10` numbers:	`a1, a2, � a10`, such that `1 < a1 < � < a10 < 100`

### Problem 3. Read file contents
*	Write a program that enters file name along with its full file path (e.g. `C:\WINDOWS\win.ini`), reads its contents and prints it on the console.
*	Find in MSDN how to use `System.IO.File.ReadAllText(�)`.
*	Be sure to catch all possible exceptions and print user-friendly error messages.

### Problem 4. Download file
*	Write a program that downloads a file from Internet (e.g. [Ninja image](http://telerikacademy.com/Content/Images/news-img01.png)) and stores it the current directory.
*	Find in Google how to download files in C#.
*	Be sure to catch all exceptions and to free any used resources in the finally block.
