using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNatification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
