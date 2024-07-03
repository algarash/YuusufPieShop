namespace YuusufPieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal PiePrice { get; set; }
        public string? PieDescription { get; set; }
        public string? ShortDesic { get; set; }
        public string? LongDesic { get; set; }

        public bool IsPieOftheWeek { get; set; }
        public string? ImageThumbnailUri { get; set; }

        public Category Category { get; set; } = default!;
    }
}
