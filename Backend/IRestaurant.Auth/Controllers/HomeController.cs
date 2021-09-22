
using Microsoft.AspNetCore.Mvc;

namespace IRestaurant.Auth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
