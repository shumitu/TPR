using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Task_1.Part_1;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class JsonTest
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

            string json = JsonConvert.SerializeObject(context.lists, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Console.WriteLine(json);
            List<Register> deserializedRegisters = JsonConvert.DeserializeObject<List<Register>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            
            Register reg1Test = deserializedRegisters[0];
            Register reg2Test = deserializedRegisters[1];
            Register reg3Test = deserializedRegisters[2];
            Register reg4Test = deserializedRegisters[3];

            Assert.AreEqual(reg1, reg1Test);
            Assert.AreEqual(reg2, reg2Test);
            Assert.AreEqual(reg3, reg3Test);
            Assert.AreEqual(reg4, reg4Test);

        }

        [TestMethod]
        public void CatalogSerializationTest()
        {
            Catalog cat1 = new Catalog(0, "Jo Nesbo", "Nóż", 2019);
            Catalog cat2 = new Catalog(1, "Jo Nesbo", "Pragnienie", 2018);
            Catalog cat3 = new Catalog(3, "Jo Nesbo", "Policja", 2017);
            Catalog cat4 = new Catalog(4, "Jo Nesbo", "Upiory", 2016);

            DataContext context = new DataContext();

            context.catalogs.Add(1, cat1);
            context.catalogs.Add(2, cat2);
            context.catalogs.Add(3, cat3);
            context.catalogs.Add(4, cat4);

            string json = JsonConvert.SerializeObject(context.catalogs.Values, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Console.WriteLine(json);
            List<Catalog> deserializedCatalogs = JsonConvert.DeserializeObject<List<Catalog>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            Catalog cat1Test = deserializedCatalogs[0];
            Catalog cat2Test = deserializedCatalogs[1];
            Catalog cat3Test = deserializedCatalogs[2];
            Catalog cat4Test = deserializedCatalogs[3];

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

            string json = JsonConvert.SerializeObject(context.descriptions, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Console.WriteLine(json);
            List<StatusDescription> deserializedDescs = JsonConvert.DeserializeObject<List<StatusDescription>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            StatusDescription desc1Test = deserializedDescs[0];
            StatusDescription desc2Test = deserializedDescs[1];

            Assert.AreEqual(desc1, desc1Test);
            Assert.AreEqual(desc2, desc2Test);

        }

        [TestMethod]
        public void EventsSerializationTest()
        {
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

            string json = JsonConvert.SerializeObject(context.events, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Console.WriteLine(json);
            List<Event> deserializedEvents = JsonConvert.DeserializeObject<List<Event>>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            Event ev1Test = deserializedEvents[0];
            Event ev2Test = deserializedEvents[1]; 

            Assert.AreEqual(ev1, ev1Test);
            Assert.AreEqual(ev2, ev2Test);

        }
    }
}
