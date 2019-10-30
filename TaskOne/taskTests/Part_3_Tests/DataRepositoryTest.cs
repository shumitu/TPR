using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;
using taskTests.Part_2_classes;

namespace taskTests.Part__3_Tests
{
    [TestClass]
    public class DataRepositoryTest
    {
        [TestMethod]
        public void AddRegisterTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register person = new Register(50, "Adam", "Małysz");
            data.AddRegister(person);

            Assert.AreEqual(8, data.context.lists.Count());
        }


        [TestMethod()]
        public void GetRegisterTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register person = new Register(1, "Jan", "Kowalski");
            if (!person.Equals(data.GetRegister(person.PersonId)))
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void GetAllRegistersTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            IEnumerable<Register> constant = data.GetAllRegisters();

            Assert.AreEqual(7, constant.Count());
        }


        [TestMethod()]
        public void DeleteRegisterTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register person = new Register(10, "Johny", "Test");
            data.AddRegister(person);

            data.DeleteRegister(10);

            Assert.AreEqual(7, data.context.lists.Count());
        }



        [TestMethod()]
        public void AddToCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Catalog book = new Catalog(7, "AuthorTest", "TitleTest", 2018);
            data.AddToCatalog(book);

            Assert.AreEqual(8, data.context.catalogs.Count());
        }


        [TestMethod()]
        public void GetFromCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);


            Catalog book = new Catalog(0, "Bolesław Prus", "Lalka", 1960);
            if (!book.Equals(data.GetFromCatalog(0)))
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void GetAllFromCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            IEnumerable<Catalog> constant = data.GetAllFromCatalog();

            Assert.AreEqual(7, constant.Count());
        }


        [TestMethod()]
        public void DeleteFromCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            data.AddToCatalog(new Catalog(7, "AuthorTest", "TitleTest", 2010));
            data.DeleteFromCatalog(7);

            IEnumerable<Catalog> constant = data.GetAllFromCatalog();

            Assert.AreEqual(7, constant.Count());
        }


        [TestMethod()]
        public void AddEventTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register register = new Register(20, "Johny", "Test");
            Catalog catalog = new Catalog(40, "AuthorTest", "TitleTest", 2010);
            DateTime date = new DateTime(2019, 06, 29);
            StatusDescription description = new StatusDescription(catalog, 9.99, "opis", date);
            Event event1 = new BookBorrow(register, description, date);
            data.AddEvent(event1);

            Assert.AreEqual(8, data.context.events.Count());
        }


        [TestMethod()]
        public void GetEventTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register register = new Register(1, "Jan", "Kowalski");
            Catalog catalog = new Catalog(0, "Bolesław Prus", "Lalka", 1960);
            double price = 19.99;
            DateTime date = new DateTime(2019, 07, 23);
            StatusDescription description = new StatusDescription(catalog, 19.99, "Krótki opis", DateTime.Today);
            Event event1 = new BookBought(register, description, date, price);

            if (!event1.Equals(data.GetEvent(0)))
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void GetAllEventsTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            IEnumerable<Event> constant = data.GetAllEvents();

            Assert.AreEqual(7, constant.Count());
        }


        [TestMethod()]
        public void DeleteEventTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register register = new Register(20, "Johny", "Test");
            Catalog catalog = new Catalog(40, "AuthorTest", "TitleTest", 2010);
            DateTime date = new DateTime(2019, 06, 29);
            StatusDescription description = new StatusDescription(catalog, 9.99, "opis", date);
            Event event1 = new BookBorrow(register, description, date);
            data.AddEvent(event1);

            data.DeleteEvent(7);

            Assert.AreEqual(7, data.context.events.Count());
        }



        [TestMethod()]
        public void AddStatusDescriptionTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Catalog catalog = new Catalog(40, "AuthorTest", "TitleTest", 2010);
            DateTime date = DateTime.Now;
            StatusDescription description = new StatusDescription(catalog, 19.99, "opis", date);
            data.AddStatusDescription(description);

            Assert.AreEqual(8, data.context.descriptions.Count());
        }


        [TestMethod()]
        public void GetStatusDescriptionTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register register = new Register(1, "Jan", "Kowalski");
            Catalog catalog = new Catalog(0, "Bolesław Prus", "Lalka", 1960);
            StatusDescription description = new StatusDescription(catalog, 19.99, "Krótki opis", DateTime.Today);

            if (!description.Equals(data.GetStatusDescription(0)))
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void GetAllStatusDescriptionsTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            IEnumerable<StatusDescription> constant = data.GetAllStatusDescriptions();

            Assert.AreEqual(7, constant.Count());
        }


        [TestMethod()]
        public void DeleteStatusDescriptionTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register register = new Register(20, "Johny", "Test");
            StatusDescription description = new StatusDescription(new Catalog(40, "AuthorTest", "TitleTest", 2010), 29.99, "opis", DateTime.Today);

            data.AddStatusDescription(description);
            data.DeleteStatusDescription(7);

            Assert.AreEqual(7, data.context.descriptions.Count());
        }
    }
}