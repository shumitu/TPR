using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TaskTwoTests.TestClasses;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class RecursiveTest
    {
        [TestMethod]
        public void RecursiveClassesTest()
        {
            ClassA clsA = new ClassA();
            ClassB clsB = new ClassB();
            ClassC clsC = new ClassC();

            clsA.ClassB = clsB;
            clsB.ClassC = clsC;
            clsC.ClassA = clsA;

            // serialize ClassA to string via Json.NET
            string jsonForClassA = JsonConvert.SerializeObject(clsA, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });

            // create clsA_test object from deserialized string
            ClassA clsA_test = JsonConvert.DeserializeObject<ClassA>(jsonForClassA,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Auto,
                            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                        });

            // serialize object created above to get it serialized form
            string jsonForDeserializedObject = JsonConvert.SerializeObject(clsA_test, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });

            // log both serialized versions of object to console
            Console.WriteLine(jsonForClassA);
            Console.WriteLine("===");
            Console.WriteLine(jsonForDeserializedObject);

            // compare objects before and after serialization, using their serialized forms
            Assert.AreEqual(jsonForClassA, jsonForDeserializedObject);
        }
    }
}