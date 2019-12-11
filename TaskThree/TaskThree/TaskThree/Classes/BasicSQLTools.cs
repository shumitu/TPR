using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using TaskThree.Files;


namespace TaskThree.Classes
{
    public static class BasicSqlTools
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<Product> db = dataContext.GetTable<Product>();

                List<Product> answer = (from product in db
                                        where product.Name.Contains(namePart)
                                        select product).ToList();

                return answer;
            }
        }


        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductVendor> db = dataContext.GetTable<ProductVendor>();

                List<Product> answer = (from productVendor in db
                                        where productVendor.Vendor.Name.Equals(vendorName)
                                        select productVendor.Product).ToList();

                return answer;
            }
        }


        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductVendor> db = dataContext.GetTable<ProductVendor>();

                List<string> answer = (from productVendor in db
                                       where productVendor.Vendor.Name.Equals(vendorName)
                                       select productVendor.Product.Name).ToList();

                return answer;
            }
        }


        public static string GetProductVendorByProductName(string productName)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductVendor> db = dataContext.GetTable<ProductVendor>();

                List<string> answer = (from productVendor in db
                                       where productVendor.Product.Name.Equals(productName)
                                       select productVendor.Vendor.Name).ToList();

                return answer[0];
            }
        }


        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {

                Table<Product> products = dataContext.GetTable<Product>();               

                List<Product> answer = (from product in products
                                        where product.ProductReview.Count == howManyReviews
                                        select product).ToList();

                return answer;
            }
        }


        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductReview> db = dataContext.GetTable<ProductReview>();

                List<Product> answer = (from review in db
                                        orderby review.ReviewDate descending
                                        group review.Product by review.ProductID into p
                                        select p.First()).Take(howManyProducts).ToList();

                return answer;
            }
        }


        public static List<Product> GetNProductsFromCategory(string categoryName, int number)
        {
            using (DataDataContext dataContext = new DataDataContext())
            { 
                Table<Product> db = dataContext.GetTable<Product>();

                List<Product> answer = (from product in db
                                        where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                        select product).Take(number).ToList();

                return answer;
            }
        }


        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<Product> db = dataContext.GetTable<Product>();

                decimal answer = (from product in db
                                  where product.ProductSubcategory.ProductCategory.Name.Equals(category.Name)
                                  select product.StandardCost).ToList().Sum();

                return (int)answer;
            }
        }
    }
}
