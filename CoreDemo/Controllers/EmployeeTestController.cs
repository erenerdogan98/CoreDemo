using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        private readonly HttpClient _httpClient;
        public EmployeeTestController(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));    
        }
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:44368/api/Default"); // from BlogCoreApıDemo , Default controoler GET/api/default..
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View();
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 employee) 
        {
            var jsonEmployee = JsonConvert.SerializeObject(employee);
            StringContent stringContent = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await _httpClient.PostAsync("https://localhost:44368/api/Default", stringContent);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
    public class Class1
    {
        // same props with Employee!!
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
