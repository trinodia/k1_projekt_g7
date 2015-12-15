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
                    BusinessLogic.BusinessLogicLayer.AddToDoList("Hamid");
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message == "A list with this name already exists and the name of a list most be unique.");
                }
            }

        }
    }
}
