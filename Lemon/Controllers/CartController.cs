using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lemon.Data.Interfaces;
using Lemon.Models;
using Lemon.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lemon.Controllers
{
    public class CartController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly Cart _cart;
        public CartController(IPurchaseRepository purchaseRepository, Cart cart)
        {
            _purchaseRepository = purchaseRepository;
            _cart = cart;
        }
        // GET: Cart
        public ViewResult Index()
        {
            var purchases = _cart.GetCartPurchases();
            _cart.CartPurchases = purchases;

            var cartViewModel = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.getCartTotal()
            };

            return View(cartViewModel);
        }

        public RedirectToActionResult AddToCart(int purchaseId)
        {
            var selectedPurchase = _purchaseRepository.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
            if(selectedPurchase != null)
            {
                _cart.AddToCart(selectedPurchase, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int purchaseId)
        {
            var selectedPurchase = _purchaseRepository.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
            if (selectedPurchase != null)
            {
                _cart.RemoveFromCart(selectedPurchase);
            }
            return RedirectToAction("Index");

        }


    }
}