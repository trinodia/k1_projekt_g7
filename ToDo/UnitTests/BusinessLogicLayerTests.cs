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
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameLessThanSixChars_ThrowsArgumentException()
        {
            using (var transaction = new TransactionScope())
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
