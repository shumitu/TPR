using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;

namespace taskTests.Part_1_Tests
{
    [TestClass]
    public class CatalogTest
    {
        [TestMethod]
        public void BookConstructorTest()
        {
            Catalog cat1 = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Assert.AreEqual(0, cat1.BookId);
            Assert.AreEqual("Jo Nesbo", cat1.Author);
            Assert.AreEqual("Nóż", cat1.Title);
            Assert.AreEqual(2019, cat1.Year);
        }

        [TestMethod]
        public void ObjectEqualityTest()
        {
            Catalog cat1 = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Assert.AreEqual(0, cat1.BookId);
            Assert.AreEqual("Jo Nesbo", cat1.Author);
            Assert.AreEqual("Nóż", cat1.Title);
            Assert.AreEqual(2019, cat1.Year);

            Catalog cat2 = new Catalog(1, "Jo Nesbo", "Pragnienie", 2018);
            Assert.AreEqual(1, cat2.BookId);
            Assert.AreEqual("Jo Nesbo", cat2.Author);
            Assert.AreEqual("Pragnienie", cat2.Title);
            Assert.AreEqual(2018, cat2.Year);

            Assert.AreNotEqual(cat1, cat2);
        }

    }
}