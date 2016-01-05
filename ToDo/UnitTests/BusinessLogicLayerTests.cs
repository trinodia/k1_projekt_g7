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
        //Group tests in a #region named after the method that the tests runs for

        #region GetToDoItemById
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToDoItemById_IdIsZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.GetToDoItemById(0);

                transaction.Dispose();
            } 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToDoItemById__IdIsLessThenZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.GetToDoItemById(-5);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetToDoItemById_IdIsNotPresentInDataBase_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "testing", Description = "test desc", EstimationTime = 10 });

                var toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                var id = toDoList.Items.First().Id;
                id += 1;

                BusinessLogicLayer.GetToDoItemById(id);

                transaction.Dispose();
            }
        }

        [TestMethod]
        public void GetToDoItemById_IdIsPresentInDataBase_ToDoItemIsGotten()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "testing", Description = "test desc", EstimationTime = 10 });

                var toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                var id = toDoList.Items.First().Id;
                
                BusinessLogicLayer.GetToDoItemById(id);

                transaction.Dispose();
            }
        }

        #endregion

        #region DeleteToDoItem
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteToDoItem_IdIsZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.DeleteToDoItemById(0);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteToDoItem_IdIsLessThenZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.DeleteToDoItemById(-5);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteToDoItem_IdIsNotPresentInDataBase_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "testing", Description = "test desc", EstimationTime = 10 });

                var toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                var id = toDoList.Items.First().Id;
                id += 1;

                BusinessLogicLayer.DeleteToDoItemById(id);

                transaction.Dispose();
            }
        }

        [TestMethod]
        public void DeleteToDoItem_IdIsPresentInDataBase_ToDoItemIsDeleted()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "testing", Description = "test desc" , EstimationTime = 10});

                var toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                var id = toDoList.Items.First().Id;

                BusinessLogicLayer.DeleteToDoItemById(id);

                transaction.Dispose();
            }
        }

        #endregion

        #region FinishToDoItem
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FinishToDoItem_IdIsZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.FinishToDoItem(0);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FinishToDoItem_IdIsLessThenZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.FinishToDoItem(-5);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FinishToDoItem_IdIsNotPresentInDataBase_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "testing", Description = "test desc", EstimationTime = 10 });

                var toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                var id = toDoList.Items.First().Id;
                id += 1;

                BusinessLogicLayer.FinishToDoItem(id);

                transaction.Dispose();
            }
        }

        [TestMethod]
        public void FinishToDoItem_IdIsPresentInDataBase_ToDoItemIsFinished()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "testing", Description = "test desc", EstimationTime = 10, Finnished = false});

                var toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                var id = toDoList.Items.First().Id;

                BusinessLogicLayer.FinishToDoItem(id);

                toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                Assert.IsTrue(toDoList.Items.First().Finnished);

                transaction.Dispose();
            }
        }
        #endregion

        #region UnFinishToDoItem
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnFinishToDoItem_IdIsZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.UnFinishToDoItem(0);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnFinishToDoItem_IdIsLessThenZero_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.UnFinishToDoItem(-5);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UnFinishToDoItem_IdIsNotPresentInDataBase_ThrowingArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "testing", Description = "test desc", EstimationTime = 10 });

                var toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                var id = toDoList.Items.First().Id;
                id += 1;

                BusinessLogicLayer.UnFinishToDoItem(id);

                transaction.Dispose();
            }
        }

        [TestMethod]
        public void UnFinishToDoItem_IdIsPresentInDataBase_ToDoItemIsFinished()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "testing", Description = "test desc", EstimationTime = 10, Finnished = true });

                var toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                var id = toDoList.Items.First().Id;

                BusinessLogicLayer.UnFinishToDoItem(id);

                toDoList = BusinessLogicLayer.GetToDoListByName("testing");

                Assert.IsFalse(toDoList.Items.First().Finnished);

                transaction.Dispose();
            }
        }
        #endregion

        #region AddToDoList

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameLessThanSixChars_ThrowsArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "test", Description = "test description", DeadLine = DateTime.Now, EstimationTime = 10 });

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameNotUnique_ThrowsArgumentException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameIsNull_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = null, Description = "Daniels list description" });

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameIsEmpty_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "", Description = "Daniels list description" });

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_NameIsWhitespace_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = " ", Description = "Daniels list description" });

                transaction.Dispose();
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_DescriptionIsNull_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels list", Description = null });

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_DescriptionIsEmpty_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels list", Description = "" });

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToDoList_DescriptionIsWhitespace_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels list", Description = " " });

                transaction.Dispose();
            }
        }

        [TestMethod]
        public void AddToDoList_DeadLineIsNull_IsAcceptedAndWorks()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = null, EstimationTime = 10 });

                Assert.IsTrue(true);

                transaction.Dispose();
            }
        }


        [TestMethod]
        public void AddToDoList_AllOk_IsTrue()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

                Assert.IsTrue(true); // This test will not be reached if we do not succeed with creating the list.

                transaction.Dispose();
            }
        }

        #endregion

        #region GetNumberOfToDoItemsInList

        [TestMethod]
        public void GetNumberOfToDoItemsInList_CorrectNumberOfItemsReturned_IsTrue()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

                BusinessLogicLayer.AddToDoItem(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description 2", DeadLine = DateTime.Now, EstimationTime = 10 });

                var numNotDoneItems = BusinessLogicLayer.GetNumberOfToDoItemsInList("Daniels unique list", false);
                Assert.IsTrue(numNotDoneItems.Count == 2);

                var numDoneItems = BusinessLogicLayer.GetNumberOfToDoItemsInList("Daniels unique list", true);
                Assert.IsTrue(numDoneItems.Count == 0);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetNumberOfToDoItemsInList_NameIsNull_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.GetNumberOfToDoItemsInList(null, false);

                transaction.Dispose();
            }
        }

        #endregion

        #region GetTotalEstimation

        [TestMethod]
        public void GetTotalEstimation_CorrectValuesInReturn_IsTrue()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.AddToDoList(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

                BusinessLogicLayer.AddToDoItem(new ToDo() { Name = "Daniels unique list", Description = "Daniels list description 2", DeadLine = DateTime.Now, EstimationTime = 10 });

                var totalEstimation = BusinessLogicLayer.GetTotalEstimation("Daniels unique list", true);

                Assert.IsTrue(totalEstimation.TotalMinutes == 20);

                /* If we are within one minute of correct time, this is correct. 
                Test written like this to ensure it does not fail if test is 
                run at end of one minute causing the test to fail because of 
                switch of minute while test is running*/

                Assert.IsTrue(totalEstimation.TimeCompleted.Minute - DateTime.Now.AddMinutes(20).Minute <= 1);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTotalEstimation_NameIsNull_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.GetTotalEstimation(null, false);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTotalEstimation_NameIsEmpty_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.GetTotalEstimation("", false);

                transaction.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetTotalEstimation_NameIsWhitespace_ThrowsArgumentNullException()
        {
            using (var transaction = new TransactionScope())
            {
                BusinessLogicLayer.GetTotalEstimation(" ", false);

                transaction.Dispose();
            }
        }

        #endregion
    }
}
