using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using TaskThree.Files;


namespace TaskThree.MyProduct
{
    class MyProductTools
    {
        public List<MyProduct> GetMyProductsByName(string namePart)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<MyProduct> db = dataContext.GetTable<MyProduct>();

                List<MyProduct> answer = (from product in db
                                          where product.Name.Contains(namePart)
                                          select product).ToList();

                return answer;
            }
        }


        public static List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<ProductReview> reviews = dataContext.GetTable<ProductReview>();

                Table<MyProduct> products = dataContext.GetTable<MyProduct>();

                List<MyProduct> answer = (from product in products
                                          where product.ProductReview.Count == howManyReviews
                                          select product).ToList();

                return answer;
            }
        }


        public static List<MyProduct> GetNMyProductsFromCategory(string categoryName, int number)
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                Table<MyProduct> db = dataContext.GetTable<MyProduct>();

                List<MyProduct> answer = (from product in db
                                          where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                          select product).Take(number).ToList();

                return answer;
            }
        }
    }
}