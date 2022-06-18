using Microsoft.AspNetCore.Mvc;

namespace SportAccountApi.Controllers
{
    public class RoomController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
