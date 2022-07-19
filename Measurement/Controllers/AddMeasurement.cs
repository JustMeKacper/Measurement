using Microsoft.AspNetCore.Mvc;

namespace Measurement.Controllers
{
    public class AddMeasurement : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
