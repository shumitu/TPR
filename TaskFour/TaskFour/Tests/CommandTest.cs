using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;


namespace Tests
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void Test1()
        {
            int count = 0;
            Command command = new Command(() => count++);
            command.Execute(null);
            Assert.AreEqual(1, count);
            Assert.IsTrue(command.CanExecute(null));


            command = new Command(() => count++, () => false);
            Assert.IsFalse(command.CanExecute(null));
            command.Execute(null);
            Assert.AreEqual(2, count);
        }
    }
}