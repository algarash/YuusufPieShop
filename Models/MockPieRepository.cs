namespace YuusufPieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Pie> AllPies =>
            new List<Pie>
            {
                new Pie{PieId=1, Name = "Cakc", PiePrice = 15.15M, PieDescription = "ddm",
                IsPieOftheWeek = true, Category= _categoryRepository.AllCategories.ToList()[0],
                ImageThumbnailUri="https://extension.colostate.edu/wp-content/uploads/2021/04/07000-fig1.jpg",
            },
                 new Pie{PieId=1, Name = "Cakc", PiePrice = 15.15M, PieDescription = "ddm",
                IsPieOftheWeek = true, Category= _categoryRepository.AllCategories.ToList()[0],
                ImageThumbnailUri="https://extension.colostate.edu/wp-content/uploads/2021/04/07000-fig1.jpg",
            },
                 new Pie{PieId=1, Name = "Cakc", PiePrice = 15.15M, PieDescription = "ddm",
                IsPieOftheWeek = true, Category= _categoryRepository.AllCategories.ToList()[0],
                ImageThumbnailUri="https://extension.colostate.edu/wp-content/uploads/2021/04/07000-fig1.jpg",
            }

                };
        public IEnumerable<Pie> PiesOftheWeek
        {
            get
            {
                return AllPies.Where(p => p.IsPieOftheWeek);
            }
        }

        public Pie? GetPieById(int pieId) => AllPies.FirstOrDefault( p => p.PieId == pieId);

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
