using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;
using Task_1.Part_2;

namespace taskTests.Part_2_Tests
{
    [TestClass]
    public class RandomDataFillTest
    {
        [TestMethod]
        public void RandomFillTest()
        {
            DataRepository rep = new DataRepository(new RandomDataFill(20));
            Assert.AreEqual(20, rep.context.catalogs.Count);
        }
    }
}
