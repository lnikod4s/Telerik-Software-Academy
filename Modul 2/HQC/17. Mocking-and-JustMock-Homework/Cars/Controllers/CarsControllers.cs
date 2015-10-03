namespace Cars.Controllers
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Data;
    using Infrastructure;
    using Models;

    public class CarsController
    {
        private readonly ICarsRepository carsData;

        public CarsController()
            : this(new CarsRepository())
        {
        }

        public CarsController(ICarsRepository data)
        {
            this.carsData = data;
        }

        public IView Index()
        {
            var cars = this.carsData.GetAll();
            return new View(cars);
        }

        public IView Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null");
            }

            if (string.IsNullOrEmpty(car.Make) || string.IsNullOrEmpty(car.Model))
            {
                throw new ArgumentNullException(nameof(car), "Car make and model cannot be empty");
            }

            this.carsData.Add(car);
            return this.GetDetailsById(car.Id);
        }

        public IView GetDetailsById(int id)
        {
            var car = this.carsData.GetById(id);
            if (car == null)
            {
                throw new ArgumentNullException(nameof(id), "Car with such id could not be found");
            }

            return new View(car);
        }

        public IView Search(string condition)
        {
            var result = this.carsData.Search(condition);
            return new View(result);
        }

        public IView Sort(string parameter)
        {
            ICollection<Car> result;
            switch (parameter)
            {
                case "make":
                    result = this.carsData.SortedByMake();
                    break;
                case "year":
                    result = this.carsData.SortedByYear();
                    break;
                default:
                    throw new ArgumentException("Invalid sorting parameter", nameof(parameter));
            }

            return new View(result);
        }
    }
}