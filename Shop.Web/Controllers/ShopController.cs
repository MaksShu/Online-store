using Shop.Services;
using Shop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Web.Controllers
{
    public class ShopController : Controller
    {
        //ProductsService productsService = new ProductsService();
        // GET: Shop
        public ActionResult Checkout()
        {
            CheckoutViewModels model = new CheckoutViewModels();
            var CartProductCookie = Request.Cookies["CartProducts"];
            if (CartProductCookie != null)
            {
                model.CartProductsIds = CartProductCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = ProductsService.ClassObject.GetProduct(model.CartProductsIds);
            }
            return View(model);
        }

        public ActionResult Index(string searchTerm,int? minPrice,int? maxPrice,int? categoryID,int? sortBy)
        {
            ShopViewModel model = new ShopViewModel();
            model.FeaturedCategories = CategoriesService.Instance.GetFeaturedCategories();
            model.MaximumPrice = ProductsService.ClassObject.GetMaximumPrice();
            model.Products = ProductsService.ClassObject.SearchProducts(searchTerm, minPrice, maxPrice, categoryID, sortBy);
            model.sortBy = sortBy;
            return View(model);
        }
    }
}