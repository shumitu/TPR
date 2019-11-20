using System;
using System.Collections.Generic;
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

            OurSerializer.Serialize(@"..\\..\\..\\TaskTwo\\Files\\TestRegister.dat", context.lists);
            List<Register> savedregister = OurSerializer.Deserialize<List<Register>>(@"..\\..\\..\\TaskTwo\\Files\\TestRegister.dat");

            Register reg1Test = savedregister[0];
            Register reg2Test = savedregister[1];
            Register reg3Test = savedregister[2];
            Register reg4Test = savedregister[3];

            Assert.AreEqual(reg1, reg1Test);
            Assert.AreEqual(reg2, reg2Test);
            Assert.AreEqual(reg3, reg3Test);
            Assert.AreEqual(reg4, reg4Test);
        }


        [TestMethod]
        public void CatalogSerializationTest()
        {
            DataRepository data = new DataRepository(new ConsoleDataFill());

            Catalog cat1 = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Catalog cat2 = new Catalog(1, "Jo Nesbo", "Pragnienie", 2018);
            Catalog cat3 = new Catalog(3, "Jo Nesbo", "Policja", 2017);
            Catalog cat4 = new Catalog(4, "Jo Nesbo", "Upiory", 2016);

            DataContext context = new DataContext();           

            context.catalogs.Add(0, cat1);
            context.catalogs.Add(1, cat2);
            context.catalogs.Add(2, cat3);
            context.catalogs.Add(3, cat4);

            IEnumerable<Catalog> constant = data.GetAllFromCatalog();

            OurSerializer.Serialize(@"..\\..\\..\\TaskTwo\\Files\\TestCatalog.dat", constant);
            IEnumerable<Catalog> savedcatalog = OurSerializer.Deserialize<IEnumerable<Catalog>>(@"..\\..\\..\\TaskTwo\\Files\\TestCatalog.dat");

            Catalog cat1Test = context.catalogs[0];
            Catalog cat2Test = context.catalogs[1];
            Catalog cat3Test = context.catalogs[2];
            Catalog cat4Test = context.catalogs[3];

            Assert.AreEqual(cat1, cat1Test);
            Assert.AreEqual(cat2, cat2Test);
            Assert.AreEqual(cat3, cat3Test);
            Assert.AreEqual(cat4, cat4Test);
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

            OurSerializer.Serialize(@"..\\..\\..\\TaskTwo\\Files\\TestStatus.dat", context.descriptions);
            List<StatusDescription> saveddescription = OurSerializer.Deserialize<List<StatusDescription>>(@"..\\..\\..\\TaskTwo\\Files\\TestStatus.dat");

            StatusDescription desc1Test = saveddescription[0];
            StatusDescription desc2Test = saveddescription[1];

            Assert.AreEqual(desc1, desc1Test);
            Assert.AreEqual(desc2, desc2Test);
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

            IEnumerable<Event> constant = data.GetAllEvents();

            OurSerializer.Serialize(@"..\\..\\..\\TaskTwo\\Files\\TestEvent.dat", constant);
            IEnumerable<Event> savedevent = OurSerializer.Deserialize<IEnumerable<Event>>(@"..\\..\\..\\TaskTwo\\Files\\TestEvent.dat");

            Event ev1Test = context.events[0];
            Event ev2Test = context.events[1];

            Assert.AreEqual(ev1, ev1Test);
            Assert.AreEqual(ev2, ev2Test);
        }
    }
}
