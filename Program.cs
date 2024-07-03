using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using YuusufPieShop.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("YuusufPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'YuusufPieShopDbContextConnection' not found.");

builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


builder.Services.AddControllersWithViews().
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddRazorPages();
builder.Services.AddDbContext<YuusufPieShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:YuusufPieShopDbContextConnection"]);
});

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<YuusufPieShopDbContext>();

builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
/*app.MapDefaultControllerRoute();*/
app.UseDeveloperExceptionPage();

app.UseStaticFiles();
app.UseSession();

app.MapRazorPages();

app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}", "/App/Index");

app.UseAuthentication();
app.UseAuthorization();

DbIntializer.Seed(app);

app.Run();
