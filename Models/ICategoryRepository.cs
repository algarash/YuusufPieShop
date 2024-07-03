namespace YuusufPieShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get;  }

    }
}
