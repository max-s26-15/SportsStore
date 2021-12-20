using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        public Cart cart;

        public CartSummaryViewComponent(Cart cartService) => cart = cartService;

        public IViewComponentResult Invoke() => View(cart);
    }
}