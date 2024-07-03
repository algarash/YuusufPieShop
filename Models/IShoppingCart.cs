namespace YuusufPieShop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Pie pie);
        int RemovFromCart(Pie pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
