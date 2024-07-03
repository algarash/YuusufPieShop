namespace YuusufPieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category {CategoryId = 1, CategoryName = "Fruit", Description = "d"},
                 new Category {CategoryId = 2, CategoryName = "Vigi", Description = "dd"},
                  new Category {CategoryId = 3, CategoryName = "Bana", Description = "ddd"},

            };

    }
}
