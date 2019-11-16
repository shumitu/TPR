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

            string jsonForClassA = JsonConvert.SerializeObject(clsA, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                });
            Console.WriteLine(jsonForClassA);

            ClassA clsA_test= JsonConvert.DeserializeObject<ClassA>(jsonForClassA,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All,
                            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        });

            Assert.AreEqual(clsA, clsA_test);

        }
    }
}
