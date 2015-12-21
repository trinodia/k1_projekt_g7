﻿using System;
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

        #region DeteleToDo
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
                BusinessLogicLayer.AddToDoList("test", "test desc", null);
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

        #endregion

        #region AddToDoList

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
        public void AddToDoList_NameIsNull_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.AddToDoList(null, "Daniels list description", DateTime.Now, 10);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddToDoList_DescriptionIsNull_ThrowsArgumentNullException()
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

        #endregion

        #region GetNumberOfToDoItemsInList

        [TestMethod]
        public void GetNumberOfToDoItemsInList_CorrectNumberOfItemsReturned_IsTrue()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.AddToDoList("Daniels unique list", "Daniels list description", DateTime.Now, 10);
                BusinessLogic.BusinessLogicLayer.AddToDoEntry("Daniels unique list", "Daniels list description 2", DateTime.Now, 10);

                var items = BusinessLogicLayer.GetToDoListByName("Daniels unique list");

                var numNotDoneItems = BusinessLogic.BusinessLogicLayer.GetNumberOfToDoItemsInList("Daniels unique list", false);
                Assert.IsTrue(numNotDoneItems == 2);

                var numDoneItems = BusinessLogic.BusinessLogicLayer.GetNumberOfToDoItemsInList("Daniels unique list", true);
                Assert.IsTrue(numDoneItems == 0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNumberOfToDoItemsInList_NameIsNull_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.GetNumberOfToDoItemsInList(null, false);
            }
        }

        #endregion
    }


}
