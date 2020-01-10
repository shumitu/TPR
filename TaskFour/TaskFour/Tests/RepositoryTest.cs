using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskThree.Classes;
using TaskThree.Files;


namespace Tests
{
    [TestClass]
    public class RepositoryTest
    {
        DataRepository dataRepository = new DataRepository();


        [TestMethod]
        public void GetTest()
        {
            Product productToGet = dataRepository.Get(1);

            Assert.AreEqual(1, productToGet.ProductID);
        }


        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = dataRepository.GetProductsByName("Decal");
            List<Product> products2 = dataRepository.GetProductsByName("Minipump");
            List<Product> products3 = dataRepository.GetProductsByName("testowy");


            Assert.AreEqual(2, products.Count);
            Assert.AreEqual(1, products2.Count);
            Assert.AreEqual(0, products3.Count);
        }


        [TestMethod]
        public void GetProductByVendorNameTest()
        {
            List<Product> products = dataRepository.GetProductsByVendorName("testowy");
            List<Product> products2 = dataRepository.GetProductsByVendorName("Comfort Road Bicycles");
            

            Assert.AreEqual(0, products.Count);
            Assert.AreEqual(2, products2.Count);
        }


        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> products = dataRepository.GetProductNamesByVendorName("testowy");
            List<string> products2 = dataRepository.GetProductNamesByVendorName("Comfort Road Bicycles");
            

            Assert.AreEqual(0, products.Count);
            Assert.AreEqual(2, products2.Count);
        }


        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = dataRepository.GetProductsWithNRecentReviews(3);
            List<Product> products2 = dataRepository.GetProductsWithNRecentReviews(0);


            Assert.AreEqual(0, products.Count);
            Assert.AreEqual(501, products2.Count);
        }


        [TestMethod]
        public void GetNProductFromCategoryTest()
        {
            List<Product> products = dataRepository.GetNProductsFromCategory("Bikes", 2);

            Assert.AreEqual(2, products.Count);

            Assert.AreEqual("Bikes", products[0].ProductSubcategory.ProductCategory.Name);
        }


        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendorName = dataRepository.GetProductVendorByProductName("Bearing Ball");

            Assert.AreEqual("Wood Fitness", vendorName);
        }


        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> products = dataRepository.GetNRecentlyReviewedProducts(4);

            Assert.AreEqual(3, products.Count);
        }


        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            int cost = (int)dataRepository.GetTotalStandardCostByCategory("Bikes");

            Assert.AreEqual(92092, cost);
        }
    }
}