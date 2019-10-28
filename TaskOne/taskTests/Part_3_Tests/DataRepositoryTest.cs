using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;
using Task_1.Part_2;

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
            List<Register> new1 = constant.ToList<Register>();

            List<Register> test = new List<Register>();
            test.Add(new Register(1, "Jan", "Kowalski"));
            test.Add(new Register(2, "Tomasz", "Nowak"));
            test.Add(new Register(3, "Adrian", "Wiśniewski"));
            test.Add(new Register(4, "Anna", "Stasiak"));
            test.Add(new Register(5, "Martyna", "Lotus"));
            test.Add(new Register(6, "Kamil", "Szybki"));
            test.Add(new Register(7, "Ewa", "Kuś"));

            for (int i = 0; i < 7; i++)
            {
                if (!test[i].Equals(new1[i])) Assert.Fail();
            }
        }


        [TestMethod()]
        public void DeleteRegister()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            int value1 = context.lists.Count;
            data.DeleteRegister(1);
            int value2 = context.lists.Count;

            Assert.AreEqual(6, data.context.lists.Count());
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
        public void GetAllFromCatalog()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            IEnumerable<Catalog> constant = data.GetAllFromCatalog();
            Dictionary<int, Catalog> new1 = constant.ToDictionary(x => x.BookId, x => x);

            Dictionary<int, Catalog> test = new Dictionary<int, Catalog>();
            test.Add(0, new Catalog(0, "Bolesław Prus", "Lalka", 1960));
            test.Add(1, new Catalog(1, "Adam Mickiewicz", "Pan Tadeusz", 1978));
            test.Add(2, new Catalog(2, "Fiodor Dostojewski", "Zbrodnia i kara", 1989));
            test.Add(3, new Catalog(3, "J.R.R. Tolkien", "Władca Pierścieni", 2006));
            test.Add(4, new Catalog(4, "J.K. Rowling", "Harry Potter i Zakon Feniksa", 2001));
            test.Add(5, new Catalog(5, "Stanisław Lem", "Solaris", 1961));
            test.Add(6, new Catalog(6, "Stephen King", "Zielona Mila", 1996));

            for (int i = 0; i < 7; i++)
            {
                if (!test[i].Equals(new1[i]))
                {
                    Assert.Fail();
                }
            }
        }


        [TestMethod()]
        public void DeleteFromCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            data.AddToCatalog(new Catalog(7, "AuthorTest", "TitleTest", 2010));
            data.DeleteFromCatalog(7);

            var values = context.catalogs.Values.ToList();
            int check = values.Count;

            if (check != 6)
            {
                return;
            }
            else Assert.Fail();
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
            ObservableCollection<Event> new1 = new ObservableCollection<Event>(constant);

            ObservableCollection<Event> test = new ObservableCollection<Event>();

            Register R1 = new Register(1, "Jan", "Kowalski");
            Register R2 = new Register(2, "Tomasz", "Nowak");
            Register R3 = new Register(3, "Adrian", "Wiśniewski");
            Register R4 = new Register(4, "Anna", "Stasiak");
            Register R5 = new Register(5, "Martyna", "Lotus");
            Register R6 = new Register(6, "Kamil", "Szybki");
            Register R7 = new Register(7, "Ewa", "Kuś");

            Catalog C1 = new Catalog(0, "Bolesław Prus", "Lalka", 1960);
            Catalog C2 = new Catalog(1, "Adam Mickiewicz", "Pan Tadeusz", 1978);
            Catalog C3 = new Catalog(2, "Fiodor Dostojewski", "Zbrodnia i kara", 1989);
            Catalog C4 = new Catalog(3, "J.R.R. Tolkien", "Władca Pierścieni", 2006);
            Catalog C5 = new Catalog(4, "J.K. Rowling", "Harry Potter i Zakon Feniksa", 2001);
            Catalog C6 = new Catalog(5, "Stanisław Lem", "Solaris", 1961);
            Catalog C7 = new Catalog(6, "Stephen King", "Zielona Mila", 1996);

            DateTime date = DateTime.Today;

            StatusDescription D1 = new StatusDescription(C1, 19.99, "Krótki opis", DateTime.Today);
            StatusDescription D2 = new StatusDescription(C2, 29.99, "Krótki opis", DateTime.Today);
            StatusDescription D3 = new StatusDescription(C3, 9.99, "Krótki opis", DateTime.Today);
            StatusDescription D4 = new StatusDescription(C4, 49.99, "Krótki opis", DateTime.Today);
            StatusDescription D5 = new StatusDescription(C5, 44.99, "Krótki opis", DateTime.Today);
            StatusDescription D6 = new StatusDescription(C6, 39.99, "Krótki opis", DateTime.Today);
            StatusDescription D7 = new StatusDescription(C7, 59.99, "Krótki opis", DateTime.Today);   

            test.Add(new BookBorrow(R1, D1, new DateTime(2019, 07, 23)));
            test.Add(new BookDestroy(R2, D2, new DateTime(2018, 04, 14)));
            test.Add(new BookReturn(R3, D3, new DateTime(2019, 10, 07)));
            test.Add(new BookBought(R4, D4, new DateTime(2019, 02, 21), 9.99));
            test.Add(new BookReturn(R5, D5, new DateTime(2017, 10, 15)));
            test.Add(new BookBorrow(R6, D6, new DateTime(2019, 05, 02)));
            test.Add(new BookDestroy(R7, D7, new DateTime(2019, 06, 29)));

            for (int i = 0; i < 7; i++)
            {
                if (!test[i].Equals(new1[i]))
                {
                    Assert.Fail();
                }
            }
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
            List<StatusDescription> new1 = constant.ToList<StatusDescription>();

            List<StatusDescription> test = new List<StatusDescription>();

            Catalog C1 = new Catalog(0, "Bolesław Prus", "Lalka", 1960);
            Catalog C2 = new Catalog(1, "Adam Mickiewicz", "Pan Tadeusz", 1978);
            Catalog C3 = new Catalog(2, "Fiodor Dostojewski", "Zbrodnia i kara", 1989);
            Catalog C4 = new Catalog(3, "J.R.R. Tolkien", "Władca Pierścieni", 2006);
            Catalog C5 = new Catalog(4, "J.K. Rowling", "Harry Potter i Zakon Feniksa", 2001);
            Catalog C6 = new Catalog(5, "Stanisław Lem", "Solaris", 1961);
            Catalog C7 = new Catalog(6, "Stephen King", "Zielona Mila", 1996);

            DateTime date1 = DateTime.Today;

            test.Add(new StatusDescription(C1, 19.99, "Krótki opis", DateTime.Today));
            test.Add(new StatusDescription(C2, 29.99, "Krótki opis", DateTime.Today));
            test.Add(new StatusDescription(C3, 9.99, "Krótki opis", DateTime.Today));
            test.Add(new StatusDescription(C4, 49.99, "Krótki opis", DateTime.Today));
            test.Add(new StatusDescription(C5, 44.99, "Krótki opis", DateTime.Today));
            test.Add(new StatusDescription(C6, 39.99, "Krótki opis", DateTime.Today));
            test.Add(new StatusDescription(C7, 59.99, "Krótki opis", DateTime.Today));

            for (int i = 0; i < 7; i++)
            {
                if (!test[i].Equals(new1[i]))
                {
                    Assert.Fail();
                }
            }
        }


        [TestMethod()]
        public void DeleteStatusDescriptionTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants);

            Register register = new Register(20, "Johny", "Test");
            StatusDescription description = new StatusDescription(new Catalog(40, "AuthorTest", "TitleTest", 2010), 29.99, "opis", DateTime.Today);
            data.AddEvent(new BookReturn(register, description, new DateTime(2019, 06, 29)));
            data.AddStatusDescription(description);

            try
            {
                data.DeleteStatusDescription(0);
            }
            catch
            {
                return;
            }

            Assert.Fail();
        }
    }
}