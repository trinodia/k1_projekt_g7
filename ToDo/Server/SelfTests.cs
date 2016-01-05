using DataModel;
using DataModel.RequestObjects;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Server
{
    public class SelfTests
    {

        public IToDoService Channel { get; set; }

        public void RunTests()
        {
            using (var transaction = new TransactionScope())
            {
                try
                {


                    AddToDoList("SelfTest");

                    // add 5 more items to SelfTest list
                    for (int i = 2; i < 7; i++)
                    {
                        AddToDoItem(i, i % 2 == 0);
                    }

                    GetToDoList();

                    FinishToDoItem();

                    UnFinishToDoItem();

                    GetNumberOfToDoItemsInList();

                    DeleteToDoItem();

                    GetNumberOfToDoItemsInList();

                    GetToDoListByDone();

                    UpdateToDoItem();

                    GetToDoListByVip();

                    SetDeadLineToDoItem();

                    AddToDoItems();

                    UpdateToDoItemWithEstimate();

                    GetTotalEstimation();

                    GetToDoListOrderedAscendingByDeadLine();

                    // Remove tests from DB
                    var toDoList = Channel.GetToDoListByName("SelfTest");
                    foreach (var item in toDoList.Items)
                    {
                        Channel.DeleteToDoItem(item.Id);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unhandled exception: " + ex.Message);
                }
                finally
                {
                    transaction.Dispose();
                }
            }


        }

        private void AddToDoList(string name)
        {
            Console.WriteLine("Calling AddToDoList: ");

            var output = Channel.AddToDoList(new ToDo() { Name = name, Description = "SelfTest item 1", DeadLine = DateTime.Now });

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: " + output.ErrorMessage);
                Console.WriteLine("  ErrorType: " + output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  List added with name SelfTest");

                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void AddToDoItem(int itemCounter, bool finnished)
        {
            Console.WriteLine("Calling AddToDoItem: ");

            //string AddToDoEntry(string name, string description, DateTime deadline, int estimationtime)
            var output = Channel.AddToDoItem(new ToDo() { Name = "SelfTest", Description = "SelfTest item " + itemCounter.ToString(), DeadLine = DateTime.Now, EstimationTime = (itemCounter * 10), Finnished = finnished });

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", output.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {
                Console.WriteLine("  Item added to list with name SelfTest.");
                Console.WriteLine("  Item details: ");
                Console.WriteLine("  Description: SelfTest item {0}", itemCounter);
                Console.WriteLine("  DeadLine: {0}", DateTime.Now.ToString());
                Console.WriteLine("  EstimationTime: 10");

                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }

        }

        private void GetToDoList()
        {
            Console.WriteLine("Calling GetToDoListByName: ");
            var toDoList = Channel.GetToDoListByName("SelfTest");

            if (!string.IsNullOrEmpty(toDoList.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", toDoList.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", toDoList.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {
                Console.WriteLine("  Items in list: ");
                foreach (var toDo in toDoList.Items)
                {
                    Console.WriteLine("    Item ID: {0}", toDo.Id.ToString());
                    Console.WriteLine("    Item description: {0}", toDo.Description);
                    Console.WriteLine("    Item deadline: {0}", toDo.DeadLine.ToString());
                    Console.WriteLine("    Item estimationtime: {0}", toDo.EstimationTime.ToString());
                    Console.WriteLine("    Item created: {0}", toDo.CreatedDate.ToString());
                    Console.WriteLine("");
                }

                Console.WriteLine("  List name: {0}", toDoList.Name);
                Console.WriteLine("  List count: {0}", toDoList.Count.ToString());

                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void FinishToDoItem()
        {
            var toDoList = Channel.GetToDoListByName("SelfTest");

            int id = toDoList.Items.First().Id;

            Console.WriteLine("Calling FinishToDoItem: ");
            var output = Channel.FinishToDoItem(id);

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", output.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Item marked as finnished.");
                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }

        }

        private void UnFinishToDoItem()
        {
            var toDoList = Channel.GetToDoListByName("SelfTest");

            int id = toDoList.Items.First().Id;

            Console.WriteLine("Calling UnFinishToDoItem: ");
            var output = Channel.FinishToDoItem(id);

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", output.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Item marked as unfinnished.");
                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void GetNumberOfToDoItemsInList()
        {
            Console.WriteLine("Calling GetNumberOfToDoItemsInList: ");
            var numTodoItemsInList = Channel.GetNumberOfToDoItemsInList("SelfTest", bool.FalseString);
            if (!string.IsNullOrEmpty(numTodoItemsInList.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", numTodoItemsInList.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", numTodoItemsInList.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {
                Console.WriteLine("  Items in list that are not finnished: {0}", numTodoItemsInList.Count);
            }

            numTodoItemsInList = Channel.GetNumberOfToDoItemsInList("SelfTest", bool.TrueString);
            if (!string.IsNullOrEmpty(numTodoItemsInList.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", numTodoItemsInList.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", numTodoItemsInList.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {
                Console.WriteLine("  Items in list that are finnished: {0}", numTodoItemsInList.Count);
                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void DeleteToDoItem()
        {
            var toDoList = Channel.GetToDoListByName("SelfTest");

            int id = toDoList.Items.Last().Id;

            Console.WriteLine("Calling DeleteToDoItem: ");
            var output = Channel.DeleteToDoItem(id);

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", output.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Item deleted.");
                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }

        }

        private void GetToDoListByDone()
        {
            Console.WriteLine("Calling GetToDoListByDone: ");
            var toDoList = Channel.GetToDoListByDone("SelfTest");

            if (!string.IsNullOrEmpty(toDoList.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", toDoList.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", toDoList.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Items in list: ");
                foreach (var toDo in toDoList.Items)
                {
                    Console.WriteLine("    Item ID: {0}", toDo.Id.ToString());
                    Console.WriteLine("    Item description: {0}", toDo.Description);
                    Console.WriteLine("    Item deadline: {0}", toDo.DeadLine.ToString());
                    Console.WriteLine("    Item estimationtime: {0}", toDo.EstimationTime.ToString());
                    Console.WriteLine("    Item created: {0}", toDo.CreatedDate.ToString());
                    Console.WriteLine("    Item finnished: {0}", toDo.Finnished);
                    Console.WriteLine("");
                }

                Console.WriteLine("  List name: {0}", toDoList.Name);
                Console.WriteLine("  List count: {0}", toDoList.Count.ToString());

                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void UpdateToDoItem()
        {
            Console.WriteLine("Calling UpdateToDoItem: ");
            var toDoList = Channel.GetToDoListByName("SelfTest");

            var toDoItemToUpdate = toDoList.Items.First();

            toDoItemToUpdate.DeadLine = DateTime.Now.AddDays(7);
            toDoItemToUpdate.Description = "Updated item!"; // we made this important now
            var output = Channel.UpdateToDoItem(toDoItemToUpdate);

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", output.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Item updated.");
                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void GetToDoListByVip()
        {
            Console.WriteLine("Calling GetToDoListByVip: ");
            var toDoList = Channel.GetToDoListByVip("SelfTest");

            if (!string.IsNullOrEmpty(toDoList.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", toDoList.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", toDoList.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  VIP Items in list: ");
                foreach (var toDo in toDoList.Items)
                {
                    Console.WriteLine("    Item ID: {0}", toDo.Id.ToString());
                    Console.WriteLine("    Item description: {0}", toDo.Description);
                    Console.WriteLine("    Item deadline: {0}", toDo.DeadLine.ToString());
                    Console.WriteLine("    Item estimationtime: {0}", toDo.EstimationTime.ToString());
                    Console.WriteLine("    Item created: {0}", toDo.CreatedDate.ToString());
                    Console.WriteLine("    Item finnished: {0}", toDo.Finnished);
                    Console.WriteLine("");
                }

                Console.WriteLine("  List name: {0}", toDoList.Name);
                Console.WriteLine("  List count: {0}", toDoList.Count.ToString());

                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void GetTotalEstimation()
        {
            Console.WriteLine("Calling GetTotalEstimation: ");
            var totalEstimation = Channel.GetTotalEstimation("SelfTest", bool.FalseString);
            Console.WriteLine("   TotalMinutes: {0}", totalEstimation.TotalMinutes);
            Console.WriteLine("   TimeCompleted: {0}", totalEstimation.TimeCompleted);

            if (!string.IsNullOrEmpty(totalEstimation.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", totalEstimation.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", totalEstimation.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void UpdateToDoItemWithEstimate()
        {
            var toDoList = Channel.GetToDoListByName("SelfTest");

            var toDoItemToUpdate = toDoList.Items.First();

            Console.WriteLine("Calling UpdateToDoItemWithEstimate: ");
            var output = Channel.UpdateToDoItemWithEstimate(new UpdateToDoWithEstimate() { id = toDoItemToUpdate.Id, estimationtime = 100 });

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: " + output.ErrorMessage);
                Console.WriteLine("  ErrorType: " + output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Item with id {0} updated with new estimationtime of 100.", toDoItemToUpdate.Id);
                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void AddToDoItems()
        {
            Console.WriteLine("Calling AddToDoItems: ");

            var output = Channel.AddToDoItems(new AddMultipleToDo() { Name = "SelfTest", Descriptions = "SelfTest item 100, SelfTest item 101, SelfTest item 102, SelfTest item 103", DeadLine = DateTime.Now, EstimationTime = 0, Finnished = false });

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", output.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Items added to list with name SelfTest.");
                Console.WriteLine("  Description: SelfTest second item");
                Console.WriteLine("  DeadLine: {0}", DateTime.Now.ToString());
                Console.WriteLine("  EstimationTime: 10");

                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }

        }

        private void SetDeadLineToDoItem()
        {
            var toDoList = Channel.GetToDoListByName("SelfTest");

            var toDoItemToUpdate = toDoList.Items.First();

            Console.WriteLine("Calling SetDeadLineToDoItem: ");
            var output = Channel.SetDeadLineToDoItem(new SetDeadLineToDoItem() { id = toDoItemToUpdate.Id, newDeadLine = DateTime.Now.AddDays(100) });

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: " + output.ErrorMessage);
                Console.WriteLine("  ErrorType: " + output.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Item with id {0} updated with new deadline of {0}.", toDoItemToUpdate.Id, DateTime.Now.AddDays(100).ToString());
                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

        private void GetToDoListOrderedAscendingByDeadLine()
        {
            Console.WriteLine("Calling GetToDoListOrderedAscendingByDeadLine: ");
            var toDoList = Channel.GetToDoListOrderedAscendingByDeadLine("SelfTest");

            if (!string.IsNullOrEmpty(toDoList.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("  Error: {0}", toDoList.ErrorMessage);
                Console.WriteLine("  ErrorType: {0}", toDoList.ErrorType);
                Console.WriteLine("  Test failed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
            else
            {

                Console.WriteLine("  Ordered items in list: ");
                foreach (var toDo in toDoList.Items)
                {
                    Console.WriteLine("    Item ID: {0}", toDo.Id.ToString());
                    Console.WriteLine("    Item description: {0}", toDo.Description);
                    Console.WriteLine("    Item deadline: {0}", toDo.DeadLine.ToString());
                    Console.WriteLine("    Item estimationtime: {0}", toDo.EstimationTime.ToString());
                    Console.WriteLine("    Item created: {0}", toDo.CreatedDate.ToString());
                    Console.WriteLine("    Item finnished: {0}", toDo.Finnished);
                    Console.WriteLine("");
                }

                Console.WriteLine("  List name: {0}", toDoList.Name);
                Console.WriteLine("  List count: {0}", toDoList.Count.ToString());

                Console.WriteLine("  Test completed.");
                Console.WriteLine("  Press any key to continue tests");
                Console.ReadKey();
                Console.WriteLine("-------------------------------\n");
            }
        }

    }
}
