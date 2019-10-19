using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;

namespace taskTests.Part_1_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void bookConstructorTest()
        {
            Catalog c = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Assert.AreEqual(0, c.BookId);
            Assert.AreEqual("Jo Nesbo", c.Author);
            Assert.AreEqual("Nóż", c.Title);
            Assert.AreEqual(2019, c.Year);
        }
    }
}
