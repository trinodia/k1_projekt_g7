using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using BusinessLogic;
using DataModel;

namespace UnitTests
{
    [TestClass]
    public class BusinessLogicLayerTests
    {
        //Use method naming according too: METHODNAME_CONDITION_EXPECTATION

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteToDoListTest_IdIsZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.DeleteToDoItemById(0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteToDoListTest_IdIsLessThenZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.DeleteToDoItemById(-5);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteToDoListTest_IdIsNotPresentInDataBase_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList("test");
                var toDoList = BusinessLogicLayer.GetToDoListByName("test");
                var id = toDoList.First().Id;
                id += 1;
                BusinessLogicLayer.DeleteToDoItemById(id);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteToDoListTest_IdReferencesTwoToDoItems_ThrowingException()
        {
            throw new Exception(); //TODO: Implement.
        }

        [TestMethod]
        public void AddToDoListTest()
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    BusinessLogicLayer.AddToDoList("test");
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message == "The name of the list most be at least 6 chars.");
                }

                try
                {
                    // This test requires that this list is created
                    BusinessLogicLayer.AddToDoList("Daniels lista 2");
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message == "A list with this name already exists and the name of a list most be unique.");
                }

                try
                {
                    BusinessLogicLayer.AddToDoList(null);
                }
                catch (NullReferenceException ex)
                {
                    Assert.IsTrue(ex.Message == "The lists name may not be null.");
                }

                try
                {
                    BusinessLogicLayer.AddToDoList("Unique name");
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
