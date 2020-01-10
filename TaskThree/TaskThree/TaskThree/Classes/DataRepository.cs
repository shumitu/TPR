using System.Collections.Generic;
using System.Linq;
using TaskThree.Files;


namespace TaskThree.Classes
{
    public class DataRepository
    {
        private DataContext dataContext;
        public delegate void OwnHandler();
        public event OwnHandler ChangeInCollection;


        public DataRepository()
        {
            dataContext = new DataContext();
        }


        public bool Add(Product product)
        {
            bool result = dataContext.AddProduct(product);
            ChangeInCollection?.Invoke();
            return result;
        }


        public Product Get(int productId)
        {
            return dataContext.GetProduct(productId);
        }


        public bool Remove(int productId)
        {
            Product product = dataContext.GetProduct(productId);
            bool result = dataContext.RemoveProduct(product);
            ChangeInCollection?.Invoke();
            return result;
        }


        public bool Update(Product item)
        {
            bool result = dataContext.UpdateProduct(item);
            ChangeInCollection?.Invoke();
            return result;
        }


        public IQueryable<Product> GetAll()
        {
            return dataContext.GetItems<Product>();
        }


        public List<Product> GetAllProducts()
        {
            List<Product> result = (from product in GetAll()
                                    select product).ToList();
            return result;
        }


        public List<Product> GetProductsByName(string namePart)
        {
            List<Product> result = (from product in GetAll()
                                    where product.Name.Contains(namePart)
                                    select product).ToList();

            return result;
        }


        public List<Product> GetProductsByVendorName(string vendorName)
        {
            List<Product> result = (from productVendor in dataContext.GetItems<ProductVendor>()
                                    where productVendor.Vendor.Name.Equals(vendorName)
                                    select productVendor.Product).ToList();

            return result;
        }


        public List<string> GetProductNamesByVendorName(string vendorName)
        {
            List<string> answer = (from productVendor in dataContext.GetItems<ProductVendor>()
                                   where productVendor.Vendor.Name.Equals(vendorName)
                                   select productVendor.Product.Name).ToList();

            return answer;
        }


        public string GetProductVendorByProductName(string productName)
        {
            List<string> answer = (from productVendor in dataContext.GetItems<ProductVendor>()
                                   where productVendor.Product.Name.Equals(productName)
                                   select productVendor.Vendor.Name).ToList();

            return answer[0];
        }


        public List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            IQueryable<Product> products = dataContext.GetItems<Product>();

            List<Product> answer = (from product in products
                                    where product.ProductReview.Count == howManyReviews
                                    select product).ToList();

            return answer;
        }


        public List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            List<Product> answer = (from review in dataContext.GetItems<ProductReview>()
                                    orderby review.ReviewDate descending
                                    group review.Product by review.ProductID into p
                                    select p.First()).Take(howManyProducts).ToList();

            return answer;
        }


        public List<Product> GetNProductsFromCategory(string categoryName, int number)
        {
            List<Product> answer = (from product in GetAll()
                                    where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                    select product).Take(number).ToList();

            return answer;
        }


        public int GetTotalStandardCostByCategory(ProductCategory category)
        {
            decimal answer = (from product in GetAll()
                              where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                              select product.StandardCost).ToList().Sum();

            return (int)answer;
        }


        public decimal GetTotalStandardCostByCategory(string category)
        {
            decimal answer = (from product in GetAll()
                              where product.ProductSubcategory.ProductCategory.Name.Equals(category)
                              select product.StandardCost).Sum();

            return (int)answer;
        }
    }
}