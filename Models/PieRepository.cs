
using Microsoft.EntityFrameworkCore;

namespace YuusufPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly YuusufPieShopDbContext _yuusufPieShopDbContext;
        public PieRepository( YuusufPieShopDbContext yuusufPieShopDbContext)
        {
            _yuusufPieShopDbContext = yuusufPieShopDbContext;
        }
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _yuusufPieShopDbContext.Pies.Include(c => c.Category);
            }

        }

        public IEnumerable<Pie> PiesOftheWeek
        {
            get
            {
                return _yuusufPieShopDbContext.Pies.Include(c => c.Category).Where(p =>
                p.IsPieOftheWeek);
            }

        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _yuusufPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));

        }

        public Pie? GetPieById(int pieid)
        {
           return _yuusufPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieid);
        }
    }
}
