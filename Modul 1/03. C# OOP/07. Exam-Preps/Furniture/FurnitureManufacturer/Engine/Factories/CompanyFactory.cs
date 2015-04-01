using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;

namespace FurnitureManufacturer.Engine.Factories
{
	public class CompanyFactory : ICompanyFactory
	{
		public ICompany CreateCompany(string name, string registrationNumber)
		{
			return new Company(name, registrationNumber);
		}
	}
}