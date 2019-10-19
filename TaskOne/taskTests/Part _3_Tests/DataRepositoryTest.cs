using System;
using System.Collections.Generic;
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
            DataRepository data = new DataRepository(constants, context);
         
            Register person = new Register(50, "Adam", "Małysz");
            data.AddRegister(person);

            if (!person.Equals(context.lists[context.lists.Count() - 1]))
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void GetRegisterTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants, context);

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
            DataRepository data = new DataRepository(constants, context);

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
            DataRepository data = new DataRepository(constants, context);
            try
            {
                data.DeleteRegister(1);
            }
            catch
            {
                return;
            }
            Assert.Fail();
        }



        //[TestMethod()]
        //public void AddToCatalogTest()
        //{
        //    DataContext context = new DataContext();
        //    ConstantsFill constants = new ConstantsFill();
        //    DataRepository data = new DataRepository(constants, context);

        //    Catalog book = new Catalog(10, "AuthorTest", "TitleTest", 2018);
        //    data.AddToCatalog(book);       

        //    if (!book.Equals(data.GetFromCatalog(0)))
        //    {
        //        Assert.Fail();
        //    }
        //}


        [TestMethod()]
        public void GetFromCatalogTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants, context);


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
            DataRepository data = new DataRepository(constants, context);

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

        //[TestMethod()]
        //public void DeleteFromCatalogTest()
        //{

        //    DataContext context = new DataContext();
        //    ConstantsFill constants = new ConstantsFill();
        //    DataRepository data = new DataRepository(constants, context);

        //    data.AddToCatalog(new Catalog(10, "AuthorTest", "TitleTest", 2010));
        //    data.DeleteFromCatalog(10);
        //    if (context.catalogs.Count == 7)
        //    {
        //        return;
        //    }
        //    else Assert.Fail();
        //}
    }
}
