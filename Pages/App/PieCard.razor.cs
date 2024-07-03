using YuusufPieShop.Models;
using Microsoft.AspNetCore.Components;

namespace YuusufPieShop.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
