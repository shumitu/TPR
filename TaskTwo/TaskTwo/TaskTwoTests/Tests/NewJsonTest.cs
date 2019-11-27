using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TaskTwo.Data;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class NewJsonTest
    {
        [TestMethod]
        public void TestClassADeserializationTest()
        {
            TestClassA clsA = new TestClassA(null, 1.5f, new DateTime(2019, 11, 10, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 2.5f, new DateTime(2019, 11, 11, 0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 3.5f, new DateTime(2019, 11, 12, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            string json = JsonConvert.SerializeObject(clsA, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });

            Console.WriteLine(json);

            TestClassA obj = JsonConvert.DeserializeObject<TestClassA>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });


            Assert.AreEqual(obj.Text, clsA.Text);
            Assert.AreEqual(obj.Date, clsA.Date);
            Assert.AreEqual(obj.Id, clsA.Id);
            Assert.AreEqual(obj.AnotherTestClassB.Text, clsA.AnotherTestClassB.Text);
            Assert.AreEqual(obj.AnotherTestClassB.Date, clsA.AnotherTestClassB.Date);
            Assert.AreEqual(obj.AnotherTestClassB.Id, clsA.AnotherTestClassB.Id);
            Assert.AreEqual(obj.AnotherTestClassB.AnotherTestClassC.Text, clsA.AnotherTestClassB.AnotherTestClassC.Text);
            Assert.AreEqual(obj.AnotherTestClassB.AnotherTestClassC.Date, clsA.AnotherTestClassB.AnotherTestClassC.Date);
            Assert.AreEqual(obj.AnotherTestClassB.AnotherTestClassC.Id, clsA.AnotherTestClassB.AnotherTestClassC.Id);
        }


        [TestMethod]
        public void TestClassBDeserializationTest()
        {
            TestClassA clsA = new TestClassA(null, 1.5f, new DateTime(2019, 11, 10, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 2.5f, new DateTime(2019, 11, 11, 0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 3.5f, new DateTime(2019, 11, 12, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            string json = JsonConvert.SerializeObject(clsB, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });

            Console.WriteLine(json);

            TestClassB obj = JsonConvert.DeserializeObject<TestClassB>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });


            Assert.AreEqual(obj.Text, clsB.Text);
            Assert.AreEqual(obj.Date, clsB.Date);
            Assert.AreEqual(obj.Id, clsB.Id);
            Assert.AreEqual(obj.AnotherTestClassC.Text, clsB.AnotherTestClassC.Text);
            Assert.AreEqual(obj.AnotherTestClassC.Date, clsB.AnotherTestClassC.Date);
            Assert.AreEqual(obj.AnotherTestClassC.Id, clsB.AnotherTestClassC.Id);
            Assert.AreEqual(obj.AnotherTestClassC.AnotherTestClassA.Text, clsB.AnotherTestClassC.AnotherTestClassA.Text);
            Assert.AreEqual(obj.AnotherTestClassC.AnotherTestClassA.Date, clsB.AnotherTestClassC.AnotherTestClassA.Date);
            Assert.AreEqual(obj.AnotherTestClassC.AnotherTestClassA.Id, clsB.AnotherTestClassC.AnotherTestClassA.Id);
        }


        [TestMethod]
        public void TestClassCDeserializationTest()
        {
            TestClassA clsA = new TestClassA(null, 1.5f, new DateTime(2019, 11, 10, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 2.5f, new DateTime(2019, 11, 11, 0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 3.5f, new DateTime(2019, 11, 12, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            string json = JsonConvert.SerializeObject(clsC, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });

            Console.WriteLine(json);

            TestClassC obj = JsonConvert.DeserializeObject<TestClassC>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });


            Assert.AreEqual(obj.Text, clsC.Text);
            Assert.AreEqual(obj.Date, clsC.Date);
            Assert.AreEqual(obj.Id, clsC.Id);
            Assert.AreEqual(obj.AnotherTestClassA.Text, clsC.AnotherTestClassA.Text);
            Assert.AreEqual(obj.AnotherTestClassA.Date, clsC.AnotherTestClassA.Date);
            Assert.AreEqual(obj.AnotherTestClassA.Id, clsC.AnotherTestClassA.Id);
            Assert.AreEqual(obj.AnotherTestClassA.AnotherTestClassB.Text, clsC.AnotherTestClassA.AnotherTestClassB.Text);
            Assert.AreEqual(obj.AnotherTestClassA.AnotherTestClassB.Date, clsC.AnotherTestClassA.AnotherTestClassB.Date);
            Assert.AreEqual(obj.AnotherTestClassA.AnotherTestClassB.Id, clsC.AnotherTestClassA.AnotherTestClassB.Id);
        }
    }
}
