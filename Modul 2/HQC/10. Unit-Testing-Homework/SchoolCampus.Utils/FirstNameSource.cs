using System;
using System.Collections.Generic;

namespace SchoolCampus.Utils
{
    public class FirstNameSource
    {
        private static readonly Random rnd = new Random();

        private static readonly string[] FirstNames =
        {
            "Jack", "Thomas", "Oliver", "Joshua", "Harry", "Charlie", "Daniel", "William", "James", "Alfie", "Samuel", "George", "Megan", 
            "Joseph", "Benjamin", "Ethan", "Lewis", "Mohammed", "Jake", "Dylan", "Jacob", "Ruby", "Olivia", "Grace", "Emily", "Jessica", 
            "Chloe", "Lily", "Mia", "Lucy", "Amelia", "Evie", "Ella", "Katie", "Ellie", "Charlotte", "Summer", "Mohammed", "Hannah", "Ava"
        };

        public static List<string> GenerateNamesList(int count)
        {
            var names = new List<string>();

            for (int i = 0; i < count; i++)
            {
                var rndIndex = rnd.Next(0, FirstNames.Length);
                names.Add(FirstNames[rndIndex]);
            }

            return names;
        }
    }
}
