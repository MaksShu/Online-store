using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels
{
    public class CheckoutViewModels
    {
        public List<Product> CartProducts { get; set; }
        public List<int> CartProductsIds { get; set; }

    }

    public class ShopViewModel
    {
        public int MaximumPrice { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> FeaturedCategories { get; set; }

        public int? sortBy { get; set; }

    }
}