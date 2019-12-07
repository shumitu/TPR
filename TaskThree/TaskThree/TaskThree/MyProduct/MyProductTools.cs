using System.Collections.Generic;
using System.Linq;


namespace TaskThree.MyProduct
{
    public class MyProductTools
    {
        public static List<MyProduct> GetMyProductsByName(string nameContains)
        {
            return (from product in MyProductDataContext.myProducts
                    where product.Name.ToLower().Contains(nameContains.ToLower())
                    select product).ToList();
        }


        public static List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            return (from product in MyProductDataContext.myProducts
                    where product.ProductReview.Count == howManyReviews
                    select product).ToList();
        }


        public static List<MyProduct> GetNMyProductsFromCategory(string categoryName, int number)
        {
            return (from product in MyProductDataContext.myProducts
                    where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                    select product).Take(number).ToList();
        }
    }
}