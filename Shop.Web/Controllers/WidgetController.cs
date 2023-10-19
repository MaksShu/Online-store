using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Web.ViewModels;
using Shop.Services;

namespace Shop.Web.Controllers
{
    public class WidgetController : Controller
    {
        // GET: Widget
        public ActionResult Products(bool isLatestProducts, int? CategoryID)
        {
            ProductWidgetViewModels model = new ProductWidgetViewModels();
            model.isLatestProducts = isLatestProducts;
            model.CategoryID = CategoryID;
            if (isLatestProducts)
            {
                model.Products = ProductsService.ClassObject.GetLatestProducts(4);
            }else if (CategoryID.HasValue && CategoryID.Value > 0)
            {
                model.Products = ProductsService.ClassObject.GetProductsByCategory(CategoryID.Value, 4);
            }
            else 
            {
                model.Products = ProductsService.ClassObject.GetProducts(1, 8);
            }
            return PartialView(model);
        }
    }
}