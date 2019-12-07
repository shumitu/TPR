using System;
using System.Collections.Generic;
using System.Data.Linq;
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

            // to be added...
        }
    }
}
