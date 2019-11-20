using System;
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

            // serialize DataContext to string via Json.NET
            string json = JsonConvert.SerializeObject(context, Formatting.Indented,
                new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.None
                });

            // create DataContext object using serialized string which was made above
            DataContext deserialized = JsonConvert.DeserializeObject<DataContext>(json,
                new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.None

                });

            // serialize new object which we created from deserialized string
            string json2 = JsonConvert.SerializeObject(deserialized, Formatting.Indented,
                new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.None
                });

            // log both strings, from original dataContext and from new, created object
            Console.WriteLine(json);
            Console.WriteLine("===");
            Console.WriteLine(json2);

            // compare serialized forms of objects
            Assert.AreEqual(json, json2);

            // compare objects and their collections
            CollectionAssert.AreEqual(context.descriptions, deserialized.descriptions);
            CollectionAssert.AreEqual(context.lists, deserialized.lists);
            CollectionAssert.AreEqual(context.events, deserialized.events);
            CollectionAssert.AreEqual(context.catalogs, deserialized.catalogs);

            CollectionAssert.Equals(context, deserialized);            
        }
    }
}