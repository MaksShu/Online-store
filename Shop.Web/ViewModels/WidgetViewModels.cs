using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.ViewModels
{
    public class ProductWidgetViewModels
    {
        public List<Product> Products {get;set;}

        public bool isLatestProducts { get; set; }

        public int? CategoryID { get; set; }
    }
}