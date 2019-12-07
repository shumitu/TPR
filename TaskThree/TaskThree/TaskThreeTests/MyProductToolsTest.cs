using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskThree.Files;
using TaskThree.MyProduct;


namespace TaskThreeTests
{
    [TestClass]
    public class MyProductToolsTest
    {
        [TestMethod]
        public void MyProductsByName()
        {
            using (DataDataContext context = new DataDataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(context);
                List<MyProduct> list = MyProductTools.GetMyProductsByName("Paint");

                Assert.AreEqual(list.Count, 5);

                foreach (MyProduct product in list)
                {
                    Assert.IsTrue(product.Name.Contains("Paint"));
                }
            }
        }


        [TestMethod]
        public void MyProductsWithNRecentReviews()
        {
            using (DataDataContext context = new DataDataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(context);
                List<MyProduct> list = MyProductTools.GetMyProductsWithNRecentReviews(2);

                Assert.AreEqual(list.Count, 1);
                Assert.IsNotNull(list.Find(product => product.ProductID == 937));
            }
        }


        [TestMethod]
        public void NMyProductsFromCategory()
        {
            using (DataDataContext context = new DataDataContext())
            {
                MyProductDataContext dataContext = new MyProductDataContext(context);
                List<MyProduct> list = MyProductTools.GetNMyProductsFromCategory("Components", 5);

                Assert.AreEqual(list.Count, 5);
            }
        }
    }
}