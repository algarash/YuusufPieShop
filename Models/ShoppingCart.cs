
using Microsoft.EntityFrameworkCore;

namespace YuusufPieShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly YuusufPieShopDbContext _yuusufPieShopDbContext;
        public string? ShoppingCartId { get; set; }
         
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
        private ShoppingCart(YuusufPieShopDbContext yuusufPieShopDbContext)
        {
            _yuusufPieShopDbContext = yuusufPieShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>
                ()?.HttpContext?.Session;

            YuusufPieShopDbContext context = services.GetRequiredService<YuusufPieShopDbContext>
                () ?? throw new Exception("Error initialization");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId};
        }

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem = 
                _yuusufPieShopDbContext.ShoppingCartItems.FirstOrDefault(
                    s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null) {

                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };
                _yuusufPieShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _yuusufPieShopDbContext.SaveChanges();
        }

        public int RemovFromCart(Pie pie)
        {
            var shoppingCartItem =
                _yuusufPieShopDbContext.ShoppingCartItems.FirstOrDefault(
                    s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _yuusufPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);

                }
            }
            _yuusufPieShopDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _yuusufPieShopDbContext.ShoppingCartItems.Where(c =>
            c.ShoppingCartId == ShoppingCartId).
            Include(s => s.Pie).
            ToList();
        }

        public void ClearCart()
        {
            var cartItems = _yuusufPieShopDbContext
                 .ShoppingCartItems
                 .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _yuusufPieShopDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _yuusufPieShopDbContext.SaveChanges();

        }

       

        public decimal GetShoppingCartTotal()
        {
            var total = _yuusufPieShopDbContext.ShoppingCartItems.Where(c =>
            c.ShoppingCartId == ShoppingCartId).
            Select(c => c.Pie.PiePrice * c.Amount).Sum();

            return total;
        }

       
    }
}
