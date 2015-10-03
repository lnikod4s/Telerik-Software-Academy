namespace Cars.Tests.JustMock.Mocks
{
    using System.Linq;
    using Contracts;
    using Models;
    using Moq;

    public class MoqCarsRepository : CarRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.GetAll()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>()))
                .Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());
            mockedCarsRepository.Setup(r => r.SortedByMake())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());
            mockedCarsRepository.Setup(r => r.SortedByYear())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());
            this.CarsData = mockedCarsRepository.Object;
        }
    }
}