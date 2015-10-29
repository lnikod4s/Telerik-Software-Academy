namespace WebApiDemo
{
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeesRepository
    {
        // GET Method
        public static List<Employee> GetAllEmployees()
        {
            var db = new TelerikAcademyEntities();
            var query = db.Employees.Select(emp => emp);
            return query.ToList();
        }

        public static Employee GetEmployee(int id)
        {
            var db = new TelerikAcademyEntities();
            var query = db.Employees.Where(emp => emp.EmployeeID == id).Select(emp => emp).FirstOrDefault();
            return query;
        }

        // POST Method
        public static void InsertEmployee(Employee newEmployee)
        {
            var db = new TelerikAcademyEntities();
            db.Employees.Add(newEmployee);
            db.SaveChanges();
        }

        // PUT Method
        public static void UpdateEmployee(Employee oldEmployee)
        {
            var db = new TelerikAcademyEntities();
            var query =
                db.Employees.Where(emp => emp.EmployeeID == oldEmployee.EmployeeID).Select(emp => emp).FirstOrDefault();
            query.FirstName = oldEmployee.FirstName;
            query.LastName = oldEmployee.LastName;
            db.SaveChanges();
        }

        public static void DeleteEmployee(int id)
        {
            var db = new TelerikAcademyEntities();
            var query = db.Employees.FirstOrDefault(emp => emp.EmployeeID == id);
            db.Employees.Remove(query);
            db.SaveChanges();
        }
    }
}