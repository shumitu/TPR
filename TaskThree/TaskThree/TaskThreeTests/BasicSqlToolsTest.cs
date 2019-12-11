using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskThree.Classes;
using TaskThree.Files;


namespace TaskThreeTests
{
    [TestClass]
    public class BasicSqlToolsTest
    {
        [TestMethod]
        public void ProductsByName()
        {
            List<Product> list = BasicSqlTools.GetProductsByName("Paint");

            Assert.AreEqual(list.Count, 5);

            foreach (Product product in list)
            {
                Assert.IsTrue(product.Name.Contains("Paint"));
            }
        }


        [TestMethod]
        public void ProductsByVendorName()
        {
            List<Product> list = BasicSqlTools.GetProductsByVendorName("Australia Bike Retailer");

            Assert.AreEqual(list.Count, 16);

        }


        [TestMethod]
        public void ProductNamesByVendorName()
        {
            List<string> list = BasicSqlTools.GetProductNamesByVendorName("Allenson Cycles");

            Assert.AreEqual(list[0], "Seat Post");
            Assert.AreEqual(list.Count, 1);
        }


        [TestMethod]
        public void ProductVendorByProductName()
        {
            string name = BasicSqlTools.GetProductVendorByProductName("Bearing Ball");

            Assert.AreEqual(name, "Wood Fitness");
        }


        [TestMethod]
        public void ProductsWithNRecentReviews()
        {
            List<Product> list = BasicSqlTools.GetProductsWithNRecentReviews(2);

            Assert.AreEqual(list.Count, 1);
            Assert.IsNotNull(list.Find(product => product.ProductID == 937));
        }


        [TestMethod]
        public void NRecentlyReviewedProducts()
        {
            List<Product> list = BasicSqlTools.GetNRecentlyReviewedProducts(2);

            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list[0].Name, "HL Mountain Pedal");
            Assert.AreEqual(list[1].Name, "Road-550-W Yellow, 40");
        }


        [TestMethod]
        public void NProductsFromCategory()
        {
            List<Product> list = BasicSqlTools.GetNProductsFromCategory("Components", 5);

            Assert.AreEqual(list.Count, 5);
        }


        [TestMethod]
        public void TotalStandardCostByCategory()
        {
            ProductCategory category = new ProductCategory {Name = "Bikes"};
            double totalCost = BasicSqlTools.GetTotalStandardCostByCategory(category);

            Assert.AreEqual(totalCost, 92092,823);
        }
    }
}