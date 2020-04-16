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
        //injecting DB context in constructor
        private readonly ApplicationDbContext _appDbContext;
        public Cart(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //declare properties
        public string CartId { get; set; }
        public List<CartPurchase> CartPurchases { get; set; }

        //Creating a session, establilshing a CartID Session variable, and creating the Cart
        public static Cart GetCart(IServiceProvider service)
        {
            //this creates the session - service is added in startup file
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //this is our db context
            var context = service.GetService<ApplicationDbContext>();
            //check for existing cartID in session, else generate unique id
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            //confirm or set cartId
            session.SetString("CartId", cartId);
            //constructs and returns an empty cart
            return new Cart(context) { CartId = cartId };
        }

        public void AddToCart (Purchase purchase, int quantity)
        {
            //check to see if this item is already in the cart
            var cartPurchase = _appDbContext.CartPurchases.SingleOrDefault(c => c.Purchase.PurchaseId == purchase.PurchaseId && c.CartId == CartId);
            if (cartPurchase == null) //item does not exist yet in cart?
            {
                cartPurchase = new CartPurchase  //create new instance of item in cart
                {
                    CartId = CartId,
                    Purchase = purchase,
                    Quantity = quantity
                };
                _appDbContext.CartPurchases.Add(cartPurchase); //create a new cartpurchase record
            } else //item is already in cart
            {
                cartPurchase.Quantity += quantity; //increase qty
            }
            _appDbContext.SaveChanges(); //save changes
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
