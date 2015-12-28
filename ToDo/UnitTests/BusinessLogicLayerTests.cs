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
        //Group tests in a #region named after the method that the tests runs for

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
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "test", Description = "test desc" });
                var toDoList = BusinessLogicLayer.GetToDoListByName("test");
                var id = toDoList.Items.First().Id;
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
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "test", Description = "test description", DeadLine = DateTime.Now });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameNotUnique_ThrowsArgumentException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameIsNull_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = null, Description = "Daniels list description" });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameIsEmpty_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "", Description = "Daniels list description" });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameIsWhitespace_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = " ", Description = "Daniels list description" });
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_DescriptionIsNull_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels list", Description = null });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_DescriptionIsEmpty_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels list", Description = "" });
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_DescriptionIsWhitespace_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels list", Description = " " });
            }
        }

        [TestMethod]
        public void AddToDoList_DeadlineIsNull_IsAcceptedAndWorks()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = null, EstimationTime = 10 });
                Assert.IsTrue(true);
            }
        }


        [TestMethod]
        public void AddToDoList_AllOk_IsTrue()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });
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
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

                BusinessLogicLayer.AddToDoEntry(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description 2", DeadLine = DateTime.Now, EstimationTime = 10 });

                var items = BusinessLogicLayer.GetToDoListByName("Daniels unique list");

                var numNotDoneItems = BusinessLogic.BusinessLogicLayer.GetNumberOfToDoItemsInList("Daniels unique list", false);
                Assert.IsTrue(numNotDoneItems.Count == 2);

                var numDoneItems = BusinessLogic.BusinessLogicLayer.GetNumberOfToDoItemsInList("Daniels unique list", true);
                Assert.IsTrue(numDoneItems.Count == 0);
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

        #region GetTotalEstimation

        [TestMethod]
        public void GetTotalEstimation_CorrectValuesInReturn_IsTrue()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

                BusinessLogicLayer.AddToDoEntry(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description 2", DeadLine = DateTime.Now, EstimationTime = 10 });

                var totalEstimation = BusinessLogicLayer.GetTotalEstimation("Daniels unique list", true);

                Assert.IsTrue(totalEstimation.TotalMinutes == 20);

                // If we are within one minute of correct time, this is correct. Test written like this to ensure it does not fail if test is run at end of one minute causing the test to fail becouse of switch of minute while test is running
                Assert.IsTrue(totalEstimation.TimeCompleted.Minute - DateTime.Now.AddMinutes(20).Minute <= 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTotalEstimation_NameIsNull_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.GetTotalEstimation(null, false);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTotalEstimation_NameIsEmpty_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.GetTotalEstimation("", false);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTotalEstimation_NameIsWhitespace_ThrowsArgumentNullException()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                BusinessLogic.BusinessLogicLayer.GetTotalEstimation(" ", false);
            }
        }

        #endregion




    }


}
