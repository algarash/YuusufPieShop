namespace YuusufPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOftheWeek { get; }
        Pie? GetPieById(int Pieid);
        IEnumerable<Pie> SearchPies(string searchQuery);
    }
}
