﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;

namespace taskTests.Part_1Tests
{
    [TestClass]
    public class RegisterTest
    {
        [TestMethod]
        public void personFirstNameGetterTest()
        {
            Register r = new Register("Jan", "Kowalski");
            Assert.AreEqual("Jan", r.FirstName);
        }

        [TestMethod]
        public void personLastNameGetterTest()
        {
            Register r = new Register("Jan", "Kowalski");
            Assert.AreEqual("Kowalski", r.LastName);
        }

        [TestMethod]
        public void personStringGetterTest()
        {
            Register r = new Register("Jan", "Kowalski");
            Assert.AreEqual("Jan Kowalski", r.FullName);
        }
    }
}