using System;
/*Problem 11. Programming Languages
-------------------------------------------------------------------------------------------------------------------------------
Perform a research (e.g. in Google or Wikipedia) and provide a short list with information about the most popular programming languages. How similar are they to C#? How do they differ from C#?
Write in a text file called “programming-languages.txt” at least five languages along with 2-3 sentences about each of them. Use English.
*/

class ProgrammingLanguages
{
	static void Main()
	{
		/*	Dec 2014	Dec 2013	Change			Programming Language		Ratings				Change
			1			1							C							17.588%				-0.30%
			2			2							Java						14.959%				-2.35%
			3			3							Objective-C					9.130%				-1.07%
			4			4							C++							6.104%				-2.16%
			5			5							C#							4.328%				-1.29%
			6			6							PHP							2.746%				-2.53%
			7			10			up				JavaScript					2.433%				+0.58%
			8			8							Python						2.287%				+0.08%
			9			11			up				Visual Basic .NET			2.235%				+0.55%
			10			12			up				Perl						1.826%				+0.75%
		 
		 The TIOBE Programming Community index is an indicator of the popularity of programming languages. The index is updated once a month. The ratings are based on the number of skilled engineers world-wide, courses and third party vendors. Popular search engines such as Google, Bing, Yahoo!, Wikipedia, Amazon, YouTube and Baidu are used to calculate the ratings. It is important to note that the TIOBE index is not about the best programming language or the language in which most lines of code have been written.
		 
		 ----------------------------------------------------------------------------------------------------------------------
		 Im Focus: C
		 ----------------------------------------------------------------------------------------------------------------------
		 Back in 1969, the programming language C was created at Bell Labs by a computer scientist named Dennis Ritchie. Ritchie based C off of an earlier language called B. C spread to wide use quickly and is arguably the most popular programming language ever made; one big reason is that programs written in C can run on all sorts of different operating systems (Macs vs. Windows, for example) with only small tweaks.

		 These days, C is used when you need something that runs quickly without using much memory. This usually means behind-the-scenes code, like the code that lets your keyboard or monitor talk to the rest of your computer (a.k.a. device drivers). Since it’s so common, though, you’re going to be finding C all over the place!
		 
		 ----------------------------------------------------------------------------------------------------------------------
		 Im Focus: Java
		 ----------------------------------------------------------------------------------------------------------------------
		 Simplicity:  Their relative simplicity is their prime attraction as an introductory programming language.
		 Safety:  Java and C# were designed to be robust.  Their type systems are a major source of this robustness, and the  absence of pointers removes one common source of problems.  They also provide exception handling and other methods  for creating programs that are less likely to crash.
		 Cost:  Free implementations of both Java and C# are available.
		 Cross-platform:  A Java program written for one platform, such as a PC or Mac, will run on any other Java platform  automatically.  Java programs are compiled into platform-independent byte-codes.  C# is not quite as platform- independent, but should at least run under Windows and Mac OS-X (but not Linux).
		 Object-oriented:  In Java and C#, (almost) everything is an object.   In fact, there are no functions or procedures --  just class methods.  C#'s treatment of objects is a bit more uniform than that of Java.
		 Client-Server and Network support:  Java and C# applets are client-server programs that run on the Internet.
		 Multimedia support:  The standard Java and C# libraries have support for graphic images, animation, and sound.
		 Ubiquitous:  Java and C# applications are spreading throughout the Internet.  Students learning these languages can  find numerous examples, as well as employment opportunities.
		 Related to C/C++:  Java and C# are perhaps 75% of C++, and vice versa.  Students who already know C or C++ will have little difficulty learning Java or C#.   Students who learn Java or C# first will have little difficulty picking up C or C++.
		 
		 ----------------------------------------------------------------------------------------------------------------------
		 Im Focus: Objective-C
		 ----------------------------------------------------------------------------------------------------------------------
		 Objective C was created by two guys, Brad Cox and Tom Love, at their company Stepstone in 1983, but has recently become very popular as the driving force behind OS X and iPhone apps. It’s a “superset” of the C language – it can do everything C can, but also has a few extra features. These features were pulled from a language called Smalltalk, and like C++, were mainly focused on making the language more object-oriented.
		 
		 ----------------------------------------------------------------------------------------------------------------------
		 Im Focus: C++
		 ----------------------------------------------------------------------------------------------------------------------
		 C++ was a programming language developed in 1979 by a Danish programmer with the amazing name Bjarne Stroustrup. It was originally called “C with Classes,” and was renamed C++ in 1983. ++ is shorthand for adding 1 to a number in programming, so C++ roughly means “one better than C.” We might just plain call that D, but because it was so closely related to C he went with C++ instead.

		 C++ added a ton of new features to C, designed to make programming more efficient and give the developer more options on	how	they’d like to code. The biggest addition is something called object oriented programming. The basic idea of object		oriented   programming is that all of your code is arranged in little bundles of data and actions, instead of a spread- out jumble.
		
		 For example, if I’m writing a program about a bike and a person, I’d have an object called bike and an object called	person,	and write things like bike->color, bike->brand, and person->name to get information about them. Why’s this	important? Just	   like you might keep all of your bills in one drawer and your love letters in another drawer, a lot of	programmers find this		sort of organization helpful. We’ll write a whole email on object oriented programming soon,	we promise!
		
		 Thanks to object oriented programming and other additions, it’s easier to write complex programs in C++ than plain C. This  	makes C++ popular for complex software packages – most of Windows is written in C++. With all of the additions,		though, C++	 has a little more overhead in terms of things like memory usage and file size. C++ is the third most popular    programming	 language, behind C and Java.
		
		 ----------------------------------------------------------------------------------------------------------------------
		 Im Focus: C#
		 --------------------------------------------------------------------------------------------------------------------- 
		 C# came out of Microsoft in 2001, intended as a new object-oriented language. It isn’t actually based on C – it was intended to be “C-like,” but the two languages didn’t end up having much in common. C# was originally code-named “Cool,” but Microsoft was on a roll with adding # to letters (A#, F#) so they went ahead and named it C#.

		 C#, like C++, can be used for pretty much anything. Since it was produced by Microsoft it ends up powering a lot of Windows programs also, but it’s also an option for doing web development on a Windows-based web server.

		 All in all, C spawned a lot of new languages. You can imagine C++ and Objective C as C’s sophisticated offspring, while C# is the neighbor kid who’s always hanging around the house.
		 
		*/
	}
}