using Microsoft.AspNetCore.Mvc;

namespace YuusufPieShop.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
               return View();
        }
    }
}
