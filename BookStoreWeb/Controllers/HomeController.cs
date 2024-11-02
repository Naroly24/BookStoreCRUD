using Microsoft.AspNetCore.Mvc;

namespace BookStoreCRUD.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
