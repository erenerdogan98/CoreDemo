using BlogCoreDemo.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BlogCoreAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly Context _context;
        public DefaultController(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        [HttpGet]
        public IActionResult EmployeeList()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee) 
        {
            _context.Add(employee);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            var employee = _context.Employees.Find(id); 
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(employee);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
