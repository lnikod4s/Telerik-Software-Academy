﻿namespace Cars.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;

    public class CarsRepository : ICarsRepository
    {
        public CarsRepository()
            : this(new Database())
        {
        }

        public CarsRepository(IDatabase database)
        {
            this.Data = database;
        }

        protected IDatabase Data { get; set; }

        public int TotalCars => this.Data.Cars.Count;

        public void Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentException("Null car cannot be added");
            }

            this.Data.Cars.Add(car);
        }

        public void Remove(Car car)
        {
            if (car == null)
            {
                throw new ArgumentException("Null car cannot be removed");
            }

            this.Data.Cars.Remove(car);
        }

        public Car GetById(int id)
        {
            var car = this.Data.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                throw new ArgumentException("Car with such Id could not be found");
            }

            return car;
        }

        public ICollection<Car> GetAll()
        {
            return this.Data.Cars.ToList();
        }

        public ICollection<Car> SortedByMake()
        {
            return this.Data.Cars.OrderBy(c => c.Make).ToList();
        }

        public ICollection<Car> SortedByYear()
        {
            return this.Data.Cars.OrderByDescending(c => c.Year).ToList();
        }

        public ICollection<Car> Search(string condition)
        {
            return string.IsNullOrEmpty(condition)
                ? this.Data.Cars.ToList()
                : this.Data.Cars.Where(c => c.Make == condition || c.Model == condition).ToList();
        }
    }
}