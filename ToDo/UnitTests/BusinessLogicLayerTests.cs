using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace UnitTests
{
    [TestClass]
    public class BusinessLogicLayerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameLessThanSixChars_ThrowsArgumentException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.AddToDoList("test", "test description", DateTime.Now);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameNotUnique_ThrowsArgumentException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.AddToDoList("Daniels list", "Daniels list description", DateTime.Now, 10);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddToDoList_NameIsNull_ThrowsArgumentException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.AddToDoList(null, "Daniels list description", DateTime.Now, 10);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddToDoList_DescriptionIsNull_ThrowsArgumentException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.AddToDoList("Daniels list", null, DateTime.Now, 10);
            }
        }

        [TestMethod]
        public void AddToDoList_DeadlineIsNull_IsAcceptedAndWorks()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.AddToDoList("Daniels unique list", "Daniels list description", null, 10);
                Assert.IsTrue(true);
            }
        }


        [TestMethod]
        public void AddToDoList_AllOk_IsTrue()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                    BusinessLogic.BusinessLogicLayer.AddToDoList("Daniels unique list", "Daniels list description", DateTime.Now, 10);
                    // this test will not be reached if we do not succeed with creating the list
                    Assert.IsTrue(true);
            }
        }


    }
}
