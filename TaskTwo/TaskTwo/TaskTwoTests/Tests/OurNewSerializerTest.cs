﻿using System;
using System.IO;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskTwo.Data;
using TaskTwo.OurNewSerializer;

namespace TaskTwoTests.Tests
{

    [TestClass]
    public class OurNewSerializerTest
    {
        [TestMethod]
        public void TestClassASerializationATest()
        {
            TestClassA clsA = new TestClassA(null, 12.34f, new DateTime(2019, 05, 04, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 34.56f, new DateTime(2019, 04, 22,0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 56.78f, new DateTime(2019, 12, 28, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Create))
            {
                IFormatter f = new OurNewSerializer();
                f.Serialize(s, clsA);
            }

            string result = File.ReadAllText("..\\..\\..\\TaskTwo\\Files\\test.txt");

            Console.WriteLine(result);

            Assert.AreEqual(result, "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassA;1;TaskTwo.Data.TestClassB=AnotherTestClassB=2;System.Single=Id=12.34;System.DateTime=Date=2019-05-03 22:00:00;System.String=Text=\"This is TestClassA\"\n"
                                  + "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassB;2;TaskTwo.Data.TestClassC=AnotherTestClassC=3;System.Single=Id=34.56;System.DateTime=Date=2019-04-21 22:00:00;System.String=Text=\"This is TestClassB\"\n"
                                  + "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassC;3;TaskTwo.Data.TestClassA=AnotherTestClassA=1;System.Single=Id=56.78;System.DateTime=Date=2019-12-27 23:00:00;System.String=Text=\"This is TestClassC\"\n"
            );
            File.Delete("..\\..\\..\\TaskTwo\\Files\\test.txt");
        }


        [TestMethod]
        public void TestClassBSerializationTest()
        {
            TestClassA clsA = new TestClassA(null, 12.34f, new DateTime(2019, 05, 04, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 34.56f, new DateTime(2019, 04, 22,0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 56.78f, new DateTime(2019, 12, 28, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Create))
            {
                IFormatter f = new OurNewSerializer();
                f.Serialize(s, clsB);
            }

            string result = File.ReadAllText("..\\..\\..\\TaskTwo\\Files\\test.txt");
            Assert.AreEqual(result, "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassB;1;TaskTwo.Data.TestClassC=AnotherTestClassC=2;System.Single=Id=34.56;System.DateTime=Date=2019-04-21 22:00:00;System.String=Text=\"This is TestClassB\"\n"
                                  + "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassC;2;TaskTwo.Data.TestClassA=AnotherTestClassA=3;System.Single=Id=56.78;System.DateTime=Date=2019-12-27 23:00:00;System.String=Text=\"This is TestClassC\"\n"
                                  + "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassA;3;TaskTwo.Data.TestClassB=AnotherTestClassB=1;System.Single=Id=12.34;System.DateTime=Date=2019-05-03 22:00:00;System.String=Text=\"This is TestClassA\"\n"
            );
            File.Delete("..\\..\\..\\TaskTwo\\Files\\test.txt");
        }


        [TestMethod]
        public void TestClassCSerializationTest()
        {
            TestClassA clsA = new TestClassA(null, 12.34f, new DateTime(2019, 05, 04, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 34.56f, new DateTime(2019, 04, 22,0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 56.78f, new DateTime(2019, 12, 28, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Create))
            {
                IFormatter f = new OurNewSerializer();
                f.Serialize(s, clsC);
            }

            string result = File.ReadAllText("..\\..\\..\\TaskTwo\\Files\\test.txt");
            Assert.AreEqual(result, "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassC;1;TaskTwo.Data.TestClassA=AnotherTestClassA=2;System.Single=Id=56.78;System.DateTime=Date=2019-12-27 23:00:00;System.String=Text=\"This is TestClassC\"\n"
                                  + "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassA;2;TaskTwo.Data.TestClassB=AnotherTestClassB=3;System.Single=Id=12.34;System.DateTime=Date=2019-05-03 22:00:00;System.String=Text=\"This is TestClassA\"\n"
                                  + "TaskTwo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;TaskTwo.Data.TestClassB;3;TaskTwo.Data.TestClassC=AnotherTestClassC=1;System.Single=Id=34.56;System.DateTime=Date=2019-04-21 22:00:00;System.String=Text=\"This is TestClassB\"\n"
            );
            File.Delete("..\\..\\..\\TaskTwo\\Files\\test.txt");
        }




        [TestMethod]
        public void TestClassADeserializationATest()
        {
            TestClassA clsA = new TestClassA(null, 12.34f, new DateTime(2019, 05, 04, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 34.56f, new DateTime(2019, 04, 22,0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 56.78f, new DateTime(2019, 12, 28, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Create))
            {
                IFormatter f = new OurNewSerializer();
                f.Serialize(s, clsA);
            }

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Open))
            {
                IFormatter f = new OurNewSerializer();
                TestClassA testClassA = (TestClassA)f.Deserialize(s);
                Assert.IsTrue(testClassA.AnotherTestClassB.AnotherTestClassC.AnotherTestClassA == testClassA);
            }
            File.Delete("..\\..\\..\\TaskTwo\\Files\\test.txt");
        }


        [TestMethod]
        public void TestClassBDeserializationTest()
        {
            TestClassA clsA = new TestClassA(null, 12.34f, new DateTime(2019, 05, 04, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 34.56f, new DateTime(2019, 04, 22,0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 56.78f, new DateTime(2019, 12, 28, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Create))
            {
                IFormatter f = new OurNewSerializer();
                f.Serialize(s, clsB);
            }

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Open))
            {
                IFormatter f = new OurNewSerializer();
                TestClassB testClassB = (TestClassB)f.Deserialize(s);
                Assert.IsTrue(testClassB.AnotherTestClassC.AnotherTestClassA.AnotherTestClassB == testClassB);
            }
            File.Delete("..\\..\\..\\TaskTwo\\Files\\test.txt");
        }


        [TestMethod]
        public void TestClassCDeserializationTest()
        {
            TestClassA clsA = new TestClassA(null, 12.34f, new DateTime(2019, 05, 04, 0, 0, 0), "This is TestClassA");
            TestClassB clsB = new TestClassB(null, 34.56f, new DateTime(2019, 04, 22,0, 0, 0), "This is TestClassB");
            TestClassC clsC = new TestClassC(null, 56.78f, new DateTime(2019, 12, 28, 0, 0, 0), "This is TestClassC");
            clsA.AnotherTestClassB = clsB;
            clsB.AnotherTestClassC = clsC;
            clsC.AnotherTestClassA = clsA;

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Create))
            {
                IFormatter f = new OurNewSerializer();
                f.Serialize(s, clsC);
            }

            using (FileStream s = new FileStream("..\\..\\..\\TaskTwo\\Files\\test.txt", FileMode.Open))
            {
                IFormatter f = new OurNewSerializer();
                TestClassC testClassC = (TestClassC)f.Deserialize(s);
                Assert.IsTrue(testClassC.AnotherTestClassA.AnotherTestClassB.AnotherTestClassC == testClassC);
            }
            File.Delete("..\\..\\..\\TaskTwo\\Files\\test.txt");
        }
    }
}