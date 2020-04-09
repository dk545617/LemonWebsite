using Lemon.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Models
{
    public class Cart
    {
        private readonly ApplicationDbContext _appDbContext;
        public Cart(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CartId { get; set; }
        public List<CartPurchase> CartPurchases { get; set; }

        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new Cart(context) { CartId = cartId };
        }

        public void AddToCart (Purchase purchase, int quantity)
        {
            var cartPurchase = _appDbContext.CartPurchases.SingleOrDefault(c => c.Purchase.PurchaseId == purchase.PurchaseId && c.CartId == CartId);
            if (cartPurchase == null)
            {
                cartPurchase = new CartPurchase
                {
                    CartId = CartId,
                    Purchase = purchase,
                    Quantity = quantity
                };
                _appDbContext.CartPurchases.Add(cartPurchase);
            } else
            {
                cartPurchase.Quantity += quantity;
            }
            _appDbContext.SaveChanges();
        }//end of AddToCart

        public int RemoveFromCart(Purchase purchase)
        {
            var cartPurchase = _appDbContext.CartPurchases.SingleOrDefault(c => c.Purchase.PurchaseId == purchase.PurchaseId && c.CartId == CartId);
            var newQuantity = 0;

            if (cartPurchase != null)
            {
                if(cartPurchase.Quantity > 1)
                {
                    cartPurchase.Quantity--;
                    newQuantity = cartPurchase.Quantity;
                }
                else
                {
                    _appDbContext.CartPurchases.Remove(cartPurchase);
                }
            }            
            _appDbContext.SaveChanges();
            return newQuantity;
        }//end of RemoveFromCart

        public List<CartPurchase> GetCartPurchases()
        {
            return CartPurchases ?? (CartPurchases = _appDbContext.CartPurchases.Where(cart => cart.CartId == CartId).Include(s => s.Purchase).ToList());
        }

        public void ClearCart()
        {
            var currentPurchases = _appDbContext.CartPurchases.Where(cart => cart.CartId == CartId);
            _appDbContext.CartPurchases.RemoveRange(currentPurchases);
            _appDbContext.SaveChanges();
        }

        public float getCartTotal()
        {
            var total = _appDbContext.CartPurchases.Where(cart => cart.CartId == CartId).Select(c => c.Purchase.Price * c.Quantity).Sum();
            return total;
        }
    }
}
