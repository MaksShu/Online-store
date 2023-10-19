using Shop.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Shop.Services
{
    public class ProductsService
    {

        public List<Product> SearchProducts(string searchTerm,int? minPrice,int? maxPrice,int? categoryID,int? sortBy)
        {
            using (var context = new SHContext())
            {
                var products = context.Products.ToList();
                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.Category.ID == categoryID.Value).ToList();
                }
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }
                if (minPrice.HasValue)
                {
                    products = products.Where(x => x.Price>=minPrice.Value).ToList();
                }
                if (maxPrice.HasValue)
                {
                    products = products.Where(x => x.Price<=maxPrice.Value).ToList();
                }
                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                        case 3:
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                    }
                    
                }
                return products;
            }
        }

        public int GetMaximumPrice()
        {
            using (var context = new SHContext())
            {
                return (int)(context.Products.Max(x => x.Price));
            }
        }

        public List<Product> GetProductsByCategory(int categoryID, int pageSize)
        {
            using (var context = new SHContext())
            {
                return context.Products.Where(x => x.Category.ID == categoryID).Take(pageSize).Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetLatestProducts(int numberOfProducts){
            using (var context = new SHContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Take(numberOfProducts).Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetProducts(int pageNo, int pageSize)
        {
            using (var context = new SHContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Skip((pageNo-1)*pageSize).Take(pageSize).Include(x => x.Category).ToList();
            }
        }

        public static ProductsService ClassObject
        {
            get
            {
                if(privateInMemoryObject == null)
                    privateInMemoryObject = new ProductsService();
                return privateInMemoryObject;
            }
        }

        private static ProductsService privateInMemoryObject { get; set; }

        private ProductsService() { }

        public List<Product> GetProduct(List<int> ids)
        {
            using(var context = new SHContext())
            {
                return context.Products.Where(product => ids.Contains(product.ID)).ToList();
            }
        }

        public void SaveProduct(Product product)
        {
            using (var context = new SHContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public List<Product> GetProducts(int pageNo)
        {
            int pageSize = 10;
            using (var context = new SHContext())
            {
                    return context.Products.OrderBy(x => x.ID).Skip((pageNo - 1) * pageSize).Take(pageSize).Include(x => x.Category).ToList();
            }
        }

        public Product GetProduct(int ID)
        {
            using (var context = new SHContext())
            {
                return context.Products.Where(x=>x.ID==ID).Include(x=>x.Category).FirstOrDefault();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new SHContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new SHContext())
            {
                var product = context.Products.Find(ID);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
