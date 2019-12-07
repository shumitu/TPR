using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskThree;
using TaskThree.Files;


namespace TaskThreeTests
{
    [TestClass]
    public class ToolsTest
    {
        [TestMethod]
        public void ProductsByName()
        {
            List<Product> list = Tools.GetProductsByName("Reflector");

            Assert.AreEqual(list.Count, 1);

            foreach (Product product in list)
            {
                Assert.IsTrue(product.Name.Contains("Reflector"));
            }
        }


        [TestMethod]
        public void ProductsByVendorName()
        {
            List<Product> list = Tools.GetProductsByVendorName("Australia Bike Retailer");

            Assert.AreEqual(list.Count, 16);
        }


        [TestMethod]
        public void ProductNamesByVendorName()
        {
            List<string> list = Tools.GetProductNamesByVendorName("Allenson Cycles");

            Assert.AreEqual(list[0], "Seat Post");
        }


        [TestMethod]
        public void ProductVendorByProductName()
        {
            string name = Tools.GetProductVendorByProductName("Bearing Ball");

            Assert.AreEqual(name, "Wood Fitness");
        }


        [TestMethod]
        public void ProductsWithNRecentReviews()
        {
            List<Product> list = Tools.GetProductsWithNRecentReviews(2);

            Assert.AreEqual(list.Count, 1);
            Assert.IsNotNull(list.Find(product => product.ProductID == 937));
        }


        [TestMethod]
        public void NRecentlyReviewedProducts()
        {
            List<Product> list = Tools.GetNRecentlyReviewedProducts(2);

            Assert.AreEqual(list.Count, 2);
            Assert.AreEqual(list[0].Name, "HL Mountain Pedal");
            Assert.AreEqual(list[1].Name, "Road-550-W Yellow, 40");
        }


        [TestMethod]
        public void NProductsFromCategory()
        {
            List<Product> list = Tools.GetNProductsFromCategory("Components", 5);

            Assert.AreEqual(list.Count, 5);
        }


        [TestMethod]
        public void TotalStandardCostByCategory()
        {
            ProductCategory category = new ProductCategory();
            category.Name = "Bikes";
            double totalCost = Tools.GetTotalStandardCostByCategory(category);

            Assert.AreEqual(totalCost, 92092,823);
        }
    }
}