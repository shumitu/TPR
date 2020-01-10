using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskThree.Files;
using ViewModel;
using ViewModel.Interfaces;


namespace Tests
{
    [TestClass]
    public class ViewModelTest
    {
        public class Result : IWindow
        {
            public string message { get; set; }
            public bool closeFlag { get; set; }
            public bool showFlag { get; set; }


            public Result()
            {
                message = "";
                closeFlag = false;
                showFlag = false;
            }


            public void Close()
            {
                closeFlag = true;
            }


            public void Show()
            {
                showFlag = true;
            }


            public void ShowPopup(string newMessage)
            {
                message = newMessage;
            }
        }


        MainViewModel viewModel = new MainViewModel();


        [TestMethod]
        public void ViewModelCreateTest()
        {
            MainViewModel model = new MainViewModel();


            Assert.IsNotNull(model.RemoveProductCommand);
            Assert.IsNotNull(model.UpdateProductCommand);
            Assert.IsNotNull(model.AddProductCommand);
            Assert.IsNotNull(model.DataRepository);
        }


        [TestMethod]
        public void AddFailTest()
        {
            Result result = new Result();
            MainViewModel model = new MainViewModel();

            model.MainWindow = result;
            model.AddProductCommand.Execute(null);

            Assert.IsNotNull(result.message);
        }


        [TestMethod]
        public void AddSuccessTest()
        {
            int counter = 0;

            Result result = new Result();
            MainViewModel model = new MainViewModel();

            model.DataRepository.ChangeInCollection += () => counter++;

            model.MainWindow = result;

            model.ColorCheck = false;
            model.SizeCheck = false;
            model.WeightCheck = false;
            model.ProductLineCheck = false;
            model.ClassCheck = false;
            model.StyleCheck = false;
            model.ProductSubcategoryCheck = false;
            model.ProductModelCheck = false;

            model.Name = "test";
            model.ProductNumber = "ABC-132465";
            model.MakeFlag = false;
            model.FinishedGoodsFlag = false;
            model.SafetyStockLevel = 1;
            model.ReorderPoint = 2;
            model.StandardCost = 12;
            model.ListPrice = 40;
            model.DaysToManufacture = 2;
            model.SellEndDate = DateTime.Now;
            model.SellEndDateCheck = false;
            model.DiscontinuedDateCheck = false;
            model.AddProductCommand.Execute(null);

            Product lastAddProduct = model.Products.Last();

            Assert.AreEqual("Add success", result.message);
            Assert.AreEqual(40, lastAddProduct.ListPrice);
            Assert.AreEqual(1, counter);
        }


        [TestMethod]
        public void RemoveNotSelectedFailTest()
        {
            Result result = new Result();
            MainViewModel model = new MainViewModel();

            model.MainWindow = result;
            model.Product = new Product();
            model.RemoveProductCommand.Execute(null);

            Assert.AreEqual("Select a product", result.message);
        }


        [TestMethod]
        public void RemoveFailTest()
        {
            Result result = new Result();
            MainViewModel model = new MainViewModel();

            model.MainWindow = result;
            model.Product = new Product();
            model.Product.ProductID = 9999999;
            model.RemoveProductCommand.Execute(null);

            Assert.AreEqual("Delete failed", result.message);
        }


        [TestMethod]
        public void RemoveSuccessTest()
        {
            Result result = new Result();
            MainViewModel model = new MainViewModel();

            model.MainWindow = result;
            model.Product = model.Products.Last();
            model.RemoveProductCommand.Execute(null);

            Assert.AreEqual("Delete success", result.message);
        }


        [TestMethod]
        public void UpdateFailTest()
        {
            Result result = new Result();
            MainViewModel model = new MainViewModel();

            model.MainWindow = result;
            model.Product = new Product();
            model.UpdateProductCommand.Execute(null);

            Assert.AreEqual("Name is empty\nProduct number is empty\n", result.message);
        }


        [TestMethod]
        public void UpdateSuccessTest()
        {
            Result result = new Result();
            MainViewModel model = new MainViewModel();

            model.MainWindow = result;
            model.Product = model.Products.Last();
            model.ProductNumber = "testowy";
            model.UpdateProductCommand.Execute(null);

            Assert.AreEqual("testowy", model.Products.Last().ProductNumber);
            Assert.AreEqual("Product modified succefully", result.message);
        }
    }
}