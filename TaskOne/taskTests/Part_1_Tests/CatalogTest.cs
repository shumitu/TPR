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

            Catalog cat2 = new Catalog(1, "Jo Nesbo", "Pragnienie", 2018);

            Assert.AreNotEqual(cat1, cat2);
        }
    }
}