namespace WebApiDemo
{
    using System.Collections.Generic;
    using System.Web.Http;

    public class EmployeesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            return EmployeesRepository.GetAllEmployees();
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            return EmployeesRepository.GetEmployee(id);
        }

        // POST api/<controller>
        public void Post([FromBody] Employee employee)
        {
            EmployeesRepository.InsertEmployee(employee);
        }

        // PUT api/<controller>/5
        public void Put([FromBody] Employee employee)
        {
            EmployeesRepository.UpdateEmployee(employee);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            EmployeesRepository.DeleteEmployee(id);
        }
    }
}