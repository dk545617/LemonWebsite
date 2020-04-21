using Lemon.Data.Interfaces;
using Lemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly Cart _cart;
        public OrderRepository(ApplicationDbContext appDbContext, Cart cart)
        {
            _appDbContext = appDbContext;
            _cart = cart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Add(order);

            var cartPurchases = _cart.CartPurchases;
            foreach (var purchase in cartPurchases)
            {
                var orderDetail = new OrderDetail()
                {
                    OrderId = order.OrderId,
                    PurchaseId = purchase.Purchase.PurchaseId,
                    Quantity = purchase.Quantity,
                    Price = purchase.Purchase.Price

                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
