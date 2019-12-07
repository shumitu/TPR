using System.Collections.Generic;
using System.Linq;
using TaskThree.Files;

namespace TaskThree.Classes
{
    public static class ExtendingSqlTools
    {
        public static List<Product> GetProductsWithoutAnyCategory(this List<Product> productsList)
        {
            List<Product> result = (from product in productsList
                                    where product.ProductSubcategory == null
                                    select product).ToList();
            return result;
        }

        public static List<Product> GetProductsWithoutAnyCategoryOther(this List<Product> productsList)
        {
            return productsList.Where(prod => prod.ProductSubcategory == null).ToList();
        }

        public static List<Product> GetProductsReturnThemAsPage(this List<Product> productsList, int numberOfPage,
            int numberOfProduct)
        {
            var result = productsList.Skip(numberOfProduct * (numberOfPage - 1));
            result = result.Take(numberOfProduct).ToList();

            return (List<Product>) result;
        }

        public static string GetProductsReturnWithSuppliers(this List<Product> productsList,
            List<ProductVendor> vendorsList)
        {
            string resultOfQuery = "";
            var result = productsList.Join(vendorsList, singleProduct => singleProduct.ProductID,
                singleVendor => singleVendor.ProductID,
                (singleProduct, singleVendor) => singleProduct.Name + " - " + singleVendor.Vendor.Name).ToList();

            foreach (var singleLine in result)
            {
                resultOfQuery += singleLine + "\n";
            }

            resultOfQuery = resultOfQuery.Remove(resultOfQuery.Length - 2);

            return resultOfQuery;
        }
    }
}
