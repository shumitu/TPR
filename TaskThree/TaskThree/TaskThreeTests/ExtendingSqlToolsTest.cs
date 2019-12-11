using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskThree.Classes;
using TaskThree.Files;


namespace TaskThreeTests
{
    [TestClass]
    public class ExtendingSqlToolsTest
    {
        [TestMethod]
        public void ListProductsWithoutCategory()
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                List<Product> productsList = dataContext.GetTable<Product>().ToList();
                List<Product> resultList = productsList.GetProductsWithoutAnyCategory();

                foreach (var singleResult in resultList)
                {
                    Assert.AreEqual(singleResult.ProductSubcategory, null);
                }

                Assert.AreEqual(resultList.Count, 209);
            }
        }


        [TestMethod]
        public void ListProductsWithoutCategoryOther()
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                List<Product> productsList = dataContext.GetTable<Product>().ToList();
                List<Product> resultList = productsList.GetProductsWithoutAnyCategoryOther();

                foreach (var singleResult in resultList)
                {
                    Assert.AreEqual(singleResult.ProductSubcategory, null);
                }

                Assert.AreEqual(resultList.Count, 209);
            }
        }


        [TestMethod]
        public void ListProductsAsPage()
        {
            using (DataDataContext dataContext = new DataDataContext())
            {
                List<Product> productsList = dataContext.GetTable<Product>().ToList();
                List<ProductVendor> vendorsList = dataContext.GetTable<ProductVendor>().ToList();

                string answer = productsList.GetProductsReturnWithSuppliers(vendorsList);
                string[] lines = answer.Split(new string[] { "\n" }, StringSplitOptions.None);

                Assert.AreEqual(lines.Length, 460);
                Assert.IsTrue(lines.Contains("HL Crankarm - Vision Cycles, Inc."));
                Assert.IsTrue(lines.Contains("Chainring - Training Systems"));
                Assert.IsTrue(lines.Contains("Front Derailleur Linkage - Compete, Inc."));
                Assert.IsTrue(lines.Contains("Thin-Jam Hex Nut 3 - WestAmerica Bicycle Co."));
                Assert.IsTrue(lines.Contains("Hex Nut 2 - Norstan Bike Hut"));
                Assert.IsTrue(lines.Contains("HL Nipple - Consumer Cycles"));
                Assert.IsTrue(lines.Contains("Half-Finger Gloves, M - Team Athletic Co."));
                Assert.IsTrue(lines.Contains("HL Road Pedal - Compete Enterprises, Inc"));
            }
        }
    }
}