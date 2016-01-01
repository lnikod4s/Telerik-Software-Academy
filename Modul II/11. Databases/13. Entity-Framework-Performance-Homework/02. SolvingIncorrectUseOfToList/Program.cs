namespace SolvingIncorrectUseOfToList
{
    using System;
    using System.Linq;
    using TelerikAcademy.Models;

    internal class Program
    {
        private static void Main()
        {
            //ProfileQueryWithMultipleToListUsings();
            ProfileQueryWithSingleToListUsing();
        }

        private static void ProfileQueryWithSingleToListUsing()
        {
            using (var db = new TelerikAcademyDb())
            {
                var employees = db.Employees
                                  .Select(e => e.Address)
                                  .Select(e => e.Town)
                                  .Where(t => t.Name == "Sofia")
                                  .ToList();

                Console.WriteLine("Employees Count: {0}", employees.Count);
            }
        }

        private static void ProfileQueryWithMultipleToListUsings()
        {
            using (var db = new TelerikAcademyDb())
            {
                var employees = db.Employees
                                  .ToList()
                                  .Select(e => e.Address)
                                  .ToList()
                                  .Select(e => e.Town)
                                  .ToList()
                                  .Where(t => t.Name == "Sofia")
                                  .ToList();

                Console.WriteLine("Employees Count: {0}", employees.Count);
            }
        }
    }
}