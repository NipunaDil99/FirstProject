using FirstProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Employee> Get()
        {

            using (var _context = new EmployeeDBContext())
            {
                return _context.Employees.ToList();
            }

        }

        [HttpPost]
        public IEnumerable<Employee> Post(Employee emp)
        {

            using (var _context = new EmployeeDBContext())
            {
                Employee employee = new Employee();
                employee.EmployeeName = emp.EmployeeName;

                _context.Employees.Add(employee);
                _context.SaveChanges();

            }

            return new List<Employee>();

        }
    }
}
