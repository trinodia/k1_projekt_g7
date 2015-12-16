using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace UnitTests
{
    [TestClass]
    public class BusinessLogicLayerTests
    {
        [TestMethod]
        public void AddToDoListTest()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    BusinessLogic.BusinessLogicLayer.AddToDoList("test");
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message == "The name of the list most be at least 6 chars.");
                }

                try
                {
                    // This test requires that this list is created
                    BusinessLogic.BusinessLogicLayer.AddToDoList("Daniels lista 2");
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message == "A list with this name already exists and the name of a list most be unique.");
                }

                try
                {
                    BusinessLogic.BusinessLogicLayer.AddToDoList(null);
                }
                catch (NullReferenceException ex)
                {
                    Assert.IsTrue(ex.Message == "The lists name may not be null.");
                }

                try
                {
                    BusinessLogic.BusinessLogicLayer.AddToDoList("Unique name");
                    // this test will not be reached if we do not succeed with creating the list
                    Assert.IsTrue(true);
                }
                catch (NullReferenceException ex)
                {
                    Assert.IsTrue(ex.Message == "The lists name may not be null.");
                }
            }

        }
    }
}
