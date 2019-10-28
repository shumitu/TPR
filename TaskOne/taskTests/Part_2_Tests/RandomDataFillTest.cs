using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;
using Task_1.Part_2;
using Task_1.Part_4;

namespace taskTests.Part_2_Tests
{
    [TestClass]
    public class RandomDataFillTest
    {
        [TestMethod]
        public void RandomFillTest()
        {
            DataRepository rep = new DataRepository(new RandomDataFill(20));
            DataService s = new DataService(rep);
            s.View(rep.GetAllRegisters());
            s.View(rep.GetAllFromCatalog());
            s.View(rep.GetAllStatusDescriptions());
            Assert.AreEqual(20, rep.context.catalogs.Count);
        }
    }
}
