using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskTwoTests.TestClasses;

namespace TaskTwoTests.Tests
{
    [TestClass]
    public class RecursiveTest
    {
        public List<TestClassC> ObjectClasses { get; set; }
        public List<TestClassC> DeserializedClasses { get; set; }
        const string path = @"..\\..\\..\\TaskTwo\\Files\\RecursiveTests.txt";

        [TestMethod]
        public void RecursiveClassesTest()
        {
            TestClassC firstClass = new TestClassC() {Id = 1};
            TestClassC secondClass = new TestClassC() {Id = 2};
            TestClassC thirdClass = new TestClassC() {Id = 3};

            firstClass.AnotherTestClass = secondClass;
            secondClass.AnotherTestClass = thirdClass;
            thirdClass.AnotherTestClass = firstClass;

            TestSerializer serializer = new TestSerializer();

            ObjectClasses = new List<TestClassC>();
            ObjectClasses.Add(firstClass);
            ObjectClasses.Add(secondClass);
            ObjectClasses.Add(thirdClass);

            Assert.AreEqual(1, firstClass.Id);
            Assert.AreEqual(2, secondClass.Id);
            Assert.AreEqual(3, thirdClass.Id);

            Assert.AreSame(secondClass, firstClass.AnotherTestClass);
            Assert.AreSame(thirdClass, secondClass.AnotherTestClass);
            Assert.AreSame(firstClass, thirdClass.AnotherTestClass);

            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(ObjectClasses, stream);
            }

            DeserializedClasses = new List<TestClassC>();

            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                DeserializedClasses = serializer.Deserialize(stream);
            }

            Assert.AreEqual(1, DeserializedClasses[0].Id);
            Assert.AreEqual(2, DeserializedClasses[1].Id);
            Assert.AreEqual(3, DeserializedClasses[2].Id);

            Assert.AreSame(DeserializedClasses[1], DeserializedClasses[0].AnotherTestClass);
            Assert.AreSame(DeserializedClasses[0], DeserializedClasses[2].AnotherTestClass);
            Assert.AreSame(DeserializedClasses[2], DeserializedClasses[1].AnotherTestClass);

            foreach (TestClassC deserializedClass in DeserializedClasses)
            {
                Assert.AreNotEqual(null, deserializedClass.AnotherTestClass);
            }
        }
    }
}