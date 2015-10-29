﻿namespace CreatingNorthwindDbContext
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                var companies = db.Customers.Select(c => c.CompanyName).ToList();
                companies.ForEach(Console.WriteLine);
            }
        }
    }
}