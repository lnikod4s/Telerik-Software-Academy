namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Models;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        //: this(new JustMockCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car { Id = 15, Make = null, Model = "330d", Year = 2014 };

            var model = (Car)GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsEmptyString()
        {
            var car = new Car { Id = 15, Make = string.Empty, Model = "330d", Year = 2014 };

            var model = (Car)GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car { Id = 15, Make = "BMW", Model = null, Year = 2014 };

            var model = (Car)GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsEmptyString()
        {
            var car = new Car { Id = 15, Make = "BMW", Model = string.Empty, Year = 2014 };

            var model = (Car)GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car { Id = 15, Make = "BMW", Model = "330d", Year = 2014 };

            var model = (Car)GetModel(() => this.controller.Add(car));

            Assert.AreEqual(4, model.Id);
            Assert.AreEqual("Opel", model.Make);
            Assert.AreEqual("Astra", model.Model);
            Assert.AreEqual(2010, model.Year);
        }

        [TestMethod]
        public void SearchingSpecificCarMakeShouldReturnListOfExactlyTwoCars()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Search("Audi"));

            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        public void SearchingSpecificCarMakeShouldReturnListOfBmwCars()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Search("Audi"));

            Assert.AreEqual("BMW", model.FirstOrDefault().Make);
        }

        [TestMethod]
        public void GetDetailsByUnknownIdShouldReturnFirstCar()
        {
            var model = (Car)GetModel(() => this.controller.GetDetailsById(5));

            Assert.AreEqual(4, model.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingByUnknownParameterShouldThrowAnException()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Sort("model"));
        }

        [TestMethod]
        public void SortingByMakeShouldReturnAllCars()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void SortingByMakeShouldReturnAllCarsSortedByMake()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual("Audi", model.FirstOrDefault().Make);
            Assert.AreEqual("Opel", model.LastOrDefault().Make);
        }

        [TestMethod]
        public void SortingByYearShouldReturnAllCars()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        public void SortingByYearShouldReturnAllCarsSortedByYear()
        {
            var model = (ICollection<Car>)GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(2005, model.FirstOrDefault().Year);
            Assert.AreEqual(2010, model.LastOrDefault().Year);
        }

        private static object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}