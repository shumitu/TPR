using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;
using TaskTwo.OurSerializer;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class OurWholeContextTest
    {
        [TestMethod]
        public void WholeContextSerializationTest()
        {
            DataContext context = new DataContext();
            context.lists.Add(new Register(1, "Jan", "Kowalski"));
            context.catalogs.Add(0, new Catalog(0, "Bolesław Prus", "Lalka", 1960));
            context.descriptions.Add(new StatusDescription(context.catalogs[0], 19.99, "Krótki opis", DateTime.Today));
            context.events.Add(new BookBought(context.lists[0], context.descriptions[0], DateTime.Today, 19.99));

            OurSerializer.Serialize(@"..\\..\\..\\TaskTwo\\Files\\TestContext.dat", context);

            DataContext deserialized = new DataContext();
            deserialized = OurSerializer.Deserialize<DataContext>(@"..\\..\\..\\TaskTwo\\Files\\TestContext.dat");

            string string1 = context.ToString();
            string string2 = deserialized.ToString();

            Assert.AreEqual(string1, string2);
        }
    }
}