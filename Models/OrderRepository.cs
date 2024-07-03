namespace YuusufPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly YuusufPieShopDbContext _yuusufPieShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(YuusufPieShopDbContext yuusufPieShopDbContext, IShoppingCart shoppingCart)
        {
            _yuusufPieShopDbContext = yuusufPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.PiePrice, // as there is a buying price and selling price
                };
                order.OrderDetails.Add(orderDetail);
            }
            _yuusufPieShopDbContext.Orders.Add(order);
            _yuusufPieShopDbContext.SaveChanges();


            
        }
    }
}
