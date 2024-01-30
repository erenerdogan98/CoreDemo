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
    }
}
