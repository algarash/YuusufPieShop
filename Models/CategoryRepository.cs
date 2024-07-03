
namespace YuusufPieShop.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly YuusufPieShopDbContext _yuusufPieShopDbContext;


        public CategoryRepository(YuusufPieShopDbContext yuusufPieShopDbContext)
        {
            _yuusufPieShopDbContext = yuusufPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _yuusufPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
