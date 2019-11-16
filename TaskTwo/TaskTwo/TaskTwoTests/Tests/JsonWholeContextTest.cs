﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Task_1.Part_1;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class JsonWholeContextTest
    {
        [TestMethod]
        public void WholeContextSerializationTest()
        {
            DataContext context = new DataContext();
            context.lists.Add(new Register(1, "Jan", "Kowalski"));
            context.catalogs.Add(0, new Catalog(0, "Bolesław Prus", "Lalka", 1960));
            context.descriptions.Add(new StatusDescription(context.catalogs[0], 19.99, "Krótki opis", DateTime.Today));
            context.events.Add(new BookBought(context.lists[0], context.descriptions[0], DateTime.Today, 19.99));

            string json = JsonConvert.SerializeObject(context, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Console.WriteLine(json);

            DataContext testContext = JsonConvert.DeserializeObject<DataContext>(json, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            string json2 = JsonConvert.SerializeObject(context, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Console.WriteLine(json2);
            Console.WriteLine(json.Equals(json2));

            Assert.AreEqual(json, json2);
            Assert.AreEqual(context, testContext);

        }
    }
}
