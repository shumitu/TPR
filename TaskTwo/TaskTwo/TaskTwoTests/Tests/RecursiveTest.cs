using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskTwoTests.TestClasses;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class RecursiveTest
    {
        public List<TestClass> ObjectClasses { get; set; }
        public List<TestClass> DeserializedClasses { get; set; }
        const string path = @"..\\..\\..\\TaskTwo\\Files\\RecursiveTests.txt";

        [TestMethod]
        public void RecursiveClassesTest()
        {
            TestClass firstClass = new TestClass() {Id = 1};
            TestClass secondClass = new TestClass() {Id = 2};
            TestClass thirdClass = new TestClass() {Id = 3};

            firstClass.AnotherTestClass = secondClass;
            secondClass.AnotherTestClass = thirdClass;
            thirdClass.AnotherTestClass = firstClass;

            TestSerializer serializer = new TestSerializer();

            ObjectClasses = new List<TestClass>();
            ObjectClasses.Add(firstClass);
            ObjectClasses.Add(secondClass);
            ObjectClasses.Add(thirdClass);

            Assert.AreEqual(1, firstClass.Id);
            Assert.AreEqual(2, secondClass.Id);
            Assert.AreEqual(3, thirdClass.Id);

            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(ObjectClasses, stream);
            }

            DeserializedClasses = new List<TestClass>();

            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                DeserializedClasses = serializer.Deserialize(stream);
            }

            Assert.AreEqual(1, DeserializedClasses[0].Id);
            Assert.AreEqual(2, DeserializedClasses[1].Id);
            Assert.AreEqual(3, DeserializedClasses[2].Id);

            foreach (TestClass deserializedClass in DeserializedClasses)
            {
                Assert.AreNotEqual(null, deserializedClass.AnotherTestClass);
            }
        }
    }
}