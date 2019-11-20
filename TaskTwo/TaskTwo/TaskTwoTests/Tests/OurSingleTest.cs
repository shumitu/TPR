using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;
using TaskTwo.Data;
using TaskTwo.OurSerializer;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class OurSingleTest
    {
        [TestMethod]
        public void RegisterSerializationTest()
        {
            DataContext context = new DataContext();

            Register reg1 = new Register(1, "Jan", "Kowalski");
            Register reg2 = new Register(2, "Tomasz", "Nowak");
            Register reg3 = new Register(3, "Adrian", "Wiśniewski");
            Register reg4 = new Register(4, "Anna", "Stasiak");

            context.lists.Add(reg1);
            context.lists.Add(reg2);
            context.lists.Add(reg3);
            context.lists.Add(reg4);

            IOurSerializer serializer = new OurSerializer();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(context, ms);
            MemoryStream ms2 = new MemoryStream(ms.ToArray());
            ms2.Position = 0;
            DataContext deserialized = serializer.Deserialize(ms2);

            Assert.AreEqual(deserialized.lists[0], reg1);
            Assert.AreEqual(deserialized.lists[1], reg2);
            Assert.AreEqual(deserialized.lists[2], reg3);
            Assert.AreEqual(deserialized.lists[3], reg4);
        }


        [TestMethod]
        public void CatalogSerializationTest()
        {
            DataRepository data = new DataRepository(new ConsoleDataFill());

            Catalog cat1 = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Catalog cat2 = new Catalog(1, "Jo Nesbo", "Pragnienie", 2018);
            Catalog cat3 = new Catalog(2, "Jo Nesbo", "Policja", 2017);
            Catalog cat4 = new Catalog(3, "Jo Nesbo", "Upiory", 2016);

            DataContext context = new DataContext();

            context.catalogs.Add(0, cat1);
            context.catalogs.Add(1, cat2);
            context.catalogs.Add(2, cat3);
            context.catalogs.Add(3, cat4);

            IOurSerializer serializer = new OurSerializer();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(context, ms);
            MemoryStream ms2 = new MemoryStream(ms.ToArray());
            ms2.Position = 0;
            DataContext deserialized = serializer.Deserialize(ms2);

            Assert.AreEqual(deserialized.catalogs[0], cat1);
            Assert.AreEqual(deserialized.catalogs[1], cat2);
            Assert.AreEqual(deserialized.catalogs[2], cat3);
            Assert.AreEqual(deserialized.catalogs[3], cat4);
        }


        [TestMethod]
        public void DescSerializationTest()
        {
            Catalog cat1 = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Catalog cat2 = new Catalog(1, "Jo Nesbo", "Pragnienie", 2018);

            DataContext context = new DataContext();

            context.catalogs.Add(1, cat1);
            context.catalogs.Add(2, cat2);
            StatusDescription desc1 = new StatusDescription(context.catalogs[1], 19.99, "Krótki opis", DateTime.Today);
            StatusDescription desc2 = new StatusDescription(context.catalogs[2], 19.99, "Krótki opis", DateTime.Today);

            context.descriptions.Add(desc1);
            context.descriptions.Add(desc2);

            IOurSerializer serializer = new OurSerializer();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(context, ms);
            MemoryStream ms2 = new MemoryStream(ms.ToArray());
            ms2.Position = 0;
            DataContext deserialized = serializer.Deserialize(ms2);

            Assert.AreEqual(deserialized.descriptions[0], desc1);
            Assert.AreEqual(deserialized.descriptions[1], desc2);
        }


        [TestMethod]
        public void EventsSerializationTest()
        {
            DataRepository data = new DataRepository(new ConsoleDataFill());
            DataContext context = new DataContext();

            Register reg1 = new Register(1, "Jan", "Kowalski");
            Register reg2 = new Register(2, "Tomasz", "Nowak");
            Catalog cat1 = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Catalog cat2 = new Catalog(1, "Jo Nesbo", "Pragnienie", 2018);

            context.lists.Add(reg1);
            context.lists.Add(reg2);
            context.catalogs.Add(1, cat1);
            context.catalogs.Add(2, cat2);

            StatusDescription desc1 = new StatusDescription(context.catalogs[1], 19.99, "Krótki opis", DateTime.Today);
            StatusDescription desc2 = new StatusDescription(context.catalogs[2], 19.99, "Krótki opis", DateTime.Today);

            context.descriptions.Add(desc1);
            context.descriptions.Add(desc2);

            Event ev1 = new BookBought(context.lists[0], context.descriptions[0], new DateTime(2019, 07, 23), 19.99);
            Event ev2 = new BookReturn(context.lists[1], context.descriptions[1], new DateTime(2018, 04, 14));

            context.events.Add(ev1);
            context.events.Add(ev2);

            IOurSerializer serializer = new OurSerializer();

            MemoryStream ms = new MemoryStream();
            serializer.Serialize(context, ms);
            MemoryStream ms2 = new MemoryStream(ms.ToArray());
            ms2.Position = 0;
            DataContext deserialized = serializer.Deserialize(ms2);

            Assert.AreEqual(deserialized.events[0], ev1);
            Assert.AreEqual(deserialized.events[1], ev2);
        }
    }
}