using YuusufPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using YuusufPieShop.ViewModels;


namespace YuusufPieShop.Controllers
{
    public class HomeController: Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;

        }

        public ActionResult Index()
        {
            var piesOfTheWeek = _pieRepository.PiesOftheWeek;
            var homeViewModel = new HomeViewModel(piesOfTheWeek);
            return View(homeViewModel);

        }
    }
}
