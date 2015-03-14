using System;
using System.Text;

namespace _03.AnimalHierarchy
{
	class Test
	{
		private static Random rnd = new Random();

		static void Main()
		{
			TestCreatures();

			Cat[] catArr = FillCatArr();
			Dog[] dogArr = FillDogArr();
			Frog[] frogArr = FillFrogArr();
			Kitten[] kitArr = FillKittenArr();
			Tomcat[] tomArr = FillTomArr();

			Animal[] animals = { new Cat("cat", 2, true), new Dog("dog", 2, true), new Frog("frog", 2, true) };

			Console.WriteLine(animals[1]);

			decimal averageAgeCats = Animal.AverageAge(catArr);
			decimal averageAgeDogs = Animal.AverageAge(dogArr);
			decimal averageAgeFrogs = Animal.AverageAge(frogArr);
			decimal averageAgeKittens = Animal.AverageAge(kitArr);
			decimal averageAgeTomcats = Animal.AverageAge(tomArr);

			Console.WriteLine("\n***** Average ages *****");
			Console.WriteLine("Cats {0:F2}", averageAgeCats);
			Console.WriteLine("Dogs {0:F2}", averageAgeDogs);
			Console.WriteLine("Frogs {0:F2}", averageAgeFrogs);
			Console.WriteLine("Kittens {0:F2}", averageAgeKittens);
			Console.WriteLine("Tomcats {0:F2}", averageAgeTomcats);
		}

		public static Tomcat[] FillTomArr()
		{
			var tomArr = new Tomcat[rnd.Next(5, 21)];
			for (int i = 0; i < tomArr.Length; i++)
			{
				tomArr[i] = new Tomcat(GetRandomName(), (byte)rnd.Next(1, 16));
			}
			return tomArr;
		}

		public static Kitten[] FillKittenArr()
		{
			var kitArr = new Kitten[rnd.Next(5, 21)];
			for (int i = 0; i < kitArr.Length; i++)
			{
				kitArr[i] = new Kitten(GetRandomName(), (byte)rnd.Next(1, 16));
			}
			return kitArr;
		}

		public static Frog[] FillFrogArr()
		{
			var frogArr = new Frog[rnd.Next(5, 21)];
			for (int i = 0; i < frogArr.Length; i++)
			{
				frogArr[i] = new Frog(GetRandomName(), (byte)rnd.Next(1, 16), rnd.Next(1, 3) == 1);
			}
			return frogArr;
		}

		public static Dog[] FillDogArr()
		{
			var dogArr = new Dog[rnd.Next(5, 21)];
			for (int i = 0; i < dogArr.Length; i++)
			{
				dogArr[i] = new Dog(GetRandomName(), (byte)rnd.Next(1, 16), rnd.Next(1, 3) == 1);
			}
			return dogArr;
		}

		public static Cat[] FillCatArr()
		{
			var catArr = new Cat[rnd.Next(5, 21)];
			for (int i = 0; i < catArr.Length; i++)
			{
				catArr[i] = new Cat(GetRandomName(), (byte)rnd.Next(1, 16), rnd.Next(1, 3) == 1);
			}
			return catArr;
		}

		public static void TestCreatures()
		{
			Dog charlie = new Dog("Charlie", 4, true);
			Console.WriteLine(charlie);
			charlie.SaySomething();

			Console.WriteLine();

			Frog quackster = new Frog("Rab", 1, false);
			Console.WriteLine(quackster);
			quackster.SaySomething();

			Console.WriteLine();

			Cat miew = new Cat("Dangleton", 3, false);
			Console.WriteLine(miew);
			miew.SaySomething();

			Console.WriteLine();

			Kitten kitty = new Kitten("KittyCat", 3);
			Console.WriteLine(kitty);
			kitty.SaySomething();

			Console.WriteLine();

			Tomcat tom = new Tomcat("Tom", 2);
			Console.WriteLine(tom);
			tom.SaySomething();
		}

		public static string GetRandomName()
		{
			var name = new StringBuilder();
			name.Append((char)rnd.Next(65, 91));
			for (int i = 0; i < rnd.Next(2, 6); i++)
			{
				name.Append((char)rnd.Next(97, 123));
			}

			return name.ToString();
		}
	}
}
