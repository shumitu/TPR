using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1.Part_1;
using Task_1.Part_2;

namespace taskTests.Part__3_Tests
{
    [TestClass]
    public class DataRepositoryTest
    {
        [TestMethod]
        public void AddToRegisterTest()
        {
            DataContext context = new DataContext();
            ConstantsFill constants = new ConstantsFill();
            DataRepository data = new DataRepository(constants, context);
         
            Register person = new Register(50, "Adam", "Małysz");
            data.AddToRegister(person);

            if (!person.Equals(context.lists[context.lists.Count() - 1]))
            {
                Assert.Fail();
            }
        }
    }
}
