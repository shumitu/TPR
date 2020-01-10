using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskThree.Classes;
using TaskThree.Files;


namespace Tests
{
    [TestClass]
    public class ContextTest
    {      
        private DataContext dataContext = new DataContext();


        [TestMethod]
        public void AddTest()
        {
            Product productToAdd = new Product();
            int sizeBeforeAdd = dataContext.GetItems().Count();

            Assert.IsFalse(dataContext.AddProduct(productToAdd));

            productToAdd.rowguid = new Guid();
            productToAdd.Name = "Testowy";
            productToAdd.ProductNumber = "TX-1111";
            productToAdd.MakeFlag = true;
            productToAdd.FinishedGoodsFlag = true;
            productToAdd.Color = null;
            productToAdd.SafetyStockLevel = 100;
            productToAdd.ReorderPoint = 100;
            productToAdd.StandardCost = 100;
            productToAdd.ListPrice = 100;
            productToAdd.Size = "S";
            productToAdd.SizeUnitMeasureCode = "CM";
            productToAdd.WeightUnitMeasureCode = "LB";
            productToAdd.Weight = 100;
            productToAdd.DaysToManufacture = 100;
            productToAdd.ProductLine = "M";
            productToAdd.Class = "H";
            productToAdd.Style = "M";
            productToAdd.ProductSubcategoryID = 1;
            productToAdd.ProductModelID = 1;
            productToAdd.SellStartDate = DateTime.Today;
            productToAdd.SellEndDate = DateTime.Today.AddDays(1);
            productToAdd.ModifiedDate = DateTime.Today;
            dataContext.AddProduct(productToAdd);


            Assert.AreEqual(sizeBeforeAdd + 1, dataContext.GetItems().Count());
        }


        [TestMethod]
        public void DeleteTest()
        {
            List<Product> products = dataContext.GetItems().ToList();
            int sizeBeforeDelete = dataContext.GetItems().Count();

            dataContext.RemoveProduct(products[products.Count - 1]);

            Assert.AreEqual(sizeBeforeDelete - 1, dataContext.GetItems().Count());
        }


        [TestMethod]
        public void UpdateTest()
        {
            List<Product> products = dataContext.GetItems().ToList();
            Product productToUpdate = products.Last();
            productToUpdate.Weight = 101;

            Assert.IsTrue(dataContext.UpdateProduct(productToUpdate));


            products = dataContext.GetItems().ToList();
            productToUpdate = products.Last();

            Assert.AreEqual(101, productToUpdate.Weight);
        }


        [TestMethod]
        public void GetTest()
        {
            Product productToAdd = dataContext.GetProduct(1);

            Assert.AreEqual(1, productToAdd.ProductID);
        } 
    }
}