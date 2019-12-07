using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using TaskThree.Files;


namespace TaskThree
{
    public class Tools
    {
        public static List<Product> GetProductsByName(string name)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<Product> db = dataContext.GetTable<Product>();

                List<Product> answer = (from product in db
                                        where product.Name.Contains(name)
                                        select product).ToList();

                return answer;
            }
        }


        public static List<Product> GetProductsByVendorName(string name)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductVendor> db = dataContext.GetTable<ProductVendor>();

                List<Product> answer = (from productVendor in db
                                        where productVendor.Vendor.Name.Equals(name)
                                        select productVendor.Product).ToList();

                return answer;
            }
        }


        public static List<string> GetProductNamesByVendorName(string name)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductVendor> db = dataContext.GetTable<ProductVendor>();

                List<string> answer = (from productVendor in db
                                       where productVendor.Vendor.Name.Equals(name)
                                       select productVendor.Product.Name).ToList();

                return answer;
            }
        }


        public static string GetProductVendorByProductName(string name)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductVendor> db = dataContext.GetTable<ProductVendor>();

                List<string> answer = (from productVendor in db
                                       where productVendor.Product.Name.Equals(name)
                                       select productVendor.Vendor.Name).ToList();

                return answer[0];
            }
        }


        public static List<Product> GetProductsWithNRecentReviews(int number)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductReview> reviews = dataContext.GetTable<ProductReview>();

                Table<Product> products = dataContext.GetTable<Product>();               

                List<Product> answer = (from product in products
                                        where product.ProductReview.Count == number
                                        select product).ToList();

                return answer;
            }
        }


        public static List<Product> GetNRecentlyReviewedProducts(int number)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductReview> db = dataContext.GetTable<ProductReview>();

                List<Product> answer = (from review in db
                                        orderby review.ReviewDate descending
                                        group review.Product by review.ProductID into p
                                        select p.First()).Take(number).ToList();

                return answer;
            }
        }


        public static List<Product> GetNProductsFromCategory(string name, int number)
        {
            using (DataDataContext dataContext = new DataDataContext())
            { 
                Table<Product> db = dataContext.GetTable<Product>();

                List<Product> answer = (from product in db
                                        where product.ProductSubcategory.ProductCategory.Name.Equals(name)
                                        select product).Take(number).ToList();

                return answer;
            }
        }


        public static double GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<Product> db = dataContext.GetTable<Product>();

                decimal answer = (from product in db
                                  where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                                  select product.StandardCost).ToList().Sum();

                return (double)answer;
            }
        }
    }
}
