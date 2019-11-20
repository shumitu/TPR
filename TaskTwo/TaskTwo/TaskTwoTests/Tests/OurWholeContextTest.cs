using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;
using TaskTwo.Data;
using TaskTwo.OurSerializer;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class OurWholeContextTest
    {
        [TestMethod]
        public void ContextSerializationTest()
        {
            DataRepository data = new DataRepository(new DefinedData());
            DataContext context = new DataContext();

            Register reg1 = new Register(1, "Jan", "Kowalski");
            Register reg2 = new Register(2, "Tomasz", "Nowak");
            Catalog cat1 = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Catalog cat2 = new Catalog(1, "Jo Nesbo", "Pragnienie", 2018);

            context.lists.Add(reg1);
            context.lists.Add(reg2);
            context.catalogs.Add(0, cat1);
            context.catalogs.Add(1, cat2);

            StatusDescription desc1 = new StatusDescription(context.catalogs[0], 19.99, "Krótki opis", DateTime.Today);
            StatusDescription desc2 = new StatusDescription(context.catalogs[1], 19.99, "Krótki opis", DateTime.Today);

            context.descriptions.Add(desc1);
            context.descriptions.Add(desc2);

            Event ev1 = new BookBought(context.lists[0], context.descriptions[0], new DateTime(2019, 07, 23), 19.99);
            Event ev2 = new BookReturn(context.lists[1], context.descriptions[1], new DateTime(2018, 04, 14));

            context.events.Add(ev1);
            context.events.Add(ev2);

            IOurSerializer serializer = new OurSerializer();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(context, ms);
            ms.Position = 0;
            DataContext deserialized = serializer.Deserialize(ms);


            CollectionAssert.AreEquivalent(context.catalogs, deserialized.catalogs);
            CollectionAssert.AreEqual(context.catalogs, deserialized.catalogs);
            CollectionAssert.AreEqual(context.descriptions, deserialized.descriptions);
            CollectionAssert.AreEqual(context.lists, deserialized.lists);
            CollectionAssert.AreEqual(context.events, deserialized.events);

            CollectionAssert.Equals(context, deserialized);
        }
    }
}
