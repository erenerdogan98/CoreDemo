using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44368/api/Default"); // from BlogCoreApıDemo , Default controoler GET/api/default..
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View();
        }
    }
    public class Class1
    {
        // same props with Employee!!
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
