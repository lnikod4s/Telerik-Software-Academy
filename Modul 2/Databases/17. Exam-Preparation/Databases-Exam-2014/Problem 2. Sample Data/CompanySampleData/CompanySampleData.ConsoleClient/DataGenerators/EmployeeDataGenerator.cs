namespace CompanySampleData.ConsoleClient.DataGenerators
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Data;

    public class EmployeeDataGenerator : IDataGenerator
    {
        public void Generate(CompanyEntities data, IRandomGenerator random, int entriesCount)
        {
            var employeesToAdd = new List<Employee>();
            var departmentIdsToAdd = data.Departments.Select(d => d.Id).ToList();
            for (var entry = 0; entry < entriesCount; entry++)
            {
                var employee = new Employee
                    {
                        FirstName = random.GenerateRandomString(random.GenerateRandomNumber(5, 20)),
                        LastName = random.GenerateRandomString(random.GenerateRandomNumber(5, 20)),
                        YearSalary = random.GenerateRandomNumber(50000, 200000),
                        DepartmentId = departmentIdsToAdd[random.GenerateRandomNumber(0, departmentIdsToAdd.Count - 1)]
                    };

                // Guarantees that the first 95% of all employees has a manager
                if (employeesToAdd.Count > 0 && random.GenerateRandomNumber(1, 100) <= 95)
                {
                    employee.Employee1 = employeesToAdd[random.GenerateRandomNumber(0, employeesToAdd.Count - 1)];
                }

                employeesToAdd.Add(employee);
            }

            data.Employees.AddRange(employeesToAdd);
        }
    }
}