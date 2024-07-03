using YuusufPieShop.Models;

namespace YuusufPieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOftheWeek { get; }
        public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
        {
            PiesOftheWeek = piesOfTheWeek;
        }
    }
}
