using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using Service;
using DataModel;

namespace Client
{
    internal class Client
    {
        private const string Url = "http://localhost/todo";

        private static void Main(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var host = new WebServiceHost(typeof(ToDoService), new Uri(Url));

            try
            {
                var binding = new WebHttpBinding { TransferMode = TransferMode.Streamed };
                var ep = host.AddServiceEndpoint(typeof(IToDoService), binding, "");
                ep.Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });

                host.Open();

                using (var cf = new ChannelFactory<IToDoService>(new WebHttpBinding(), Url))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                    var channel = cf.CreateChannel();

                    Console.WriteLine("Webservice started on: " + Url);
                    Console.WriteLine("Go to " + Url + "/help for information about functionality");

                    MakeAllPossibleCalls(channel);
                }

                Console.WriteLine("Press <ENTER> to terminate");
                Console.ReadLine();

                host.Close();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                host.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: {0}", ex.Message);
                host.Abort();
            }
        }

        private static void MakeAllPossibleCalls(IToDoService channel)
        {
            GetToDoList(channel);

            AddToDoList(channel);

            DeleteToDoItem(channel);

            FinishToDoItem(channel);

            UnFinishToDoItem(channel);

            GetNumberOfToDoItemsInList(channel);

            AddToDoEntry(channel);

            GetToDoListByDone(channel);

            UpdateToDoItem(channel);

            GetToDoListByVip(channel);

            SetDeadLineToDoItem(channel);

            GetToDoListOrderedAscendingByDeadLine(channel);

            GetTotalEstimation(channel);

            UpdateToDoItemWithEstimate(channel);

            AddToDoEntries(channel);
        }


        private static void DeleteToDoItem(IToDoService channel)
        {
            const int id = 5;
            Console.WriteLine("Calling DeleteToDoItem via HTTP DELETE: ");
            channel.DeleteToDoItem(id);
        }

        private static void FinishToDoItem(IToDoService channel)
        {
            const int id = 3;
            Console.WriteLine("Calling FinishToDoItem via HTTP POST: ");
            channel.FinishToDoItem(id);
        }

        private static void UnFinishToDoItem(IToDoService channel)
        {
            const int id = 9;
            Console.WriteLine("Calling UnFinishToDoItem via HTTP POST: ");
            channel.UnFinishToDoItem(id);
        }

        private static void AddToDoList(IToDoService channel)
        {
            Console.WriteLine("Calling AddToDo via HTTP POST: ");

            var output = channel.AddToDoList(new ToDo() { Name = "Daniels list", Description = "Daniels list description", DeadLine = DateTime.Now, EstimationTime = 10 });

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("Error: " + output.ErrorMessage);
                Console.WriteLine("ErrorType: " + output.ErrorType);
            }
            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by posting a JSON Object to");
            Console.WriteLine("http://localhost:8000/AddToDoList");
            Console.WriteLine("while this sample is running.");

            Console.WriteLine("");
        }

        private static void GetToDoList(IToDoService channel)
        {
            Console.WriteLine("Calling GetToDoListByName via HTTP GET: ");
            var toDoList = channel.GetToDoListByName("Hamid");
            foreach (var toDo in toDoList.Items)
            {
                Console.WriteLine("   Output: {0}", toDo.Description);
            }

            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by navigating to");
            Console.WriteLine("http://localhost:8000/GetToDoListByName?name=Hamid");
            Console.WriteLine("in a web browser while this sample is running.");

            Console.WriteLine("");
        }

        private static void GetNumberOfToDoItemsInList(IToDoService channel)
        {
            Console.WriteLine("Calling GetNumberOfToDoItemsInList via HTTP GET: ");
            var numTodoItemsInList = channel.GetNumberOfToDoItemsInList("Hamid", false);
            Console.WriteLine("Items in list that are not done: {0}", numTodoItemsInList);
            numTodoItemsInList = channel.GetNumberOfToDoItemsInList("Hamid", true);
            Console.WriteLine("Items in list that are done: {0}", numTodoItemsInList);

            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by navigating to");
            Console.WriteLine("http://localhost:8000/GetNumberOfToDoItemsInList?name=Hamid&finnished=true");
            Console.WriteLine("in a web browser while this sample is running.");

            Console.WriteLine("");
        }

        private static void AddToDoEntry(IToDoService channel)
        {
            Console.WriteLine("Calling AddToDoEntry via HTTP POST: ");

            //string AddToDoEntry(string name, string description, DateTime deadline, int estimationtime)
            var output = channel.AddToDoItem(new ToDo() { Name = "Daniels list", Description = "Daniels todo Thingie", DeadLine = DateTime.Now, EstimationTime = 10 });

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("Error: " + output.ErrorMessage);
                Console.WriteLine("ErrorType: " + output.ErrorType);
            }
            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by posting a JSON Object to");
            Console.WriteLine("http://localhost:8000/AddToDoEntry");
            Console.WriteLine("while this sample is running.");

            Console.WriteLine("");
        }

        private static void GetToDoListByDone(IToDoService channel)
        {
            //List<ToDo> GetToDoListByDone(string name)
            Console.WriteLine("Calling GetToDoListByDone via HTTP GET: ");
            var toDoList = channel.GetToDoListByDone("Hamid");
            foreach (var toDo in toDoList.Items)
            {
                Console.WriteLine("   Output: {0}, {1}", toDo.Description, toDo.Finnished);
            }

            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by navigating to");
            Console.WriteLine("http://localhost:8000/GetToDoListByDone?name=Hamid");
            Console.WriteLine("in a web browser while this sample is running.");

            Console.WriteLine("");
        }

        private static void UpdateToDoItem(IToDoService channel)
        {
            int id = 3;
            Console.WriteLine("Calling UpdateToDoItem via HTTP POST: ");
            var toDoList = channel.GetToDoListByName("");
            var todoitem = toDoList.Items[id];
            todoitem.DeadLine = DateTime.UtcNow;
            string temp = ((DateTime)todoitem.DeadLine).ToString("hh:mm:ss");
            todoitem.Description = "Updated @ " + temp;
            channel.UpdateToDoItem(todoitem);
            /*
            if (!string.IsNullOrEmpty(error))
            {
            Console.WriteLine("");
                Console.WriteLine("Error: " + error);
        }
            */
            Console.WriteLine("Updated ID # {0} with {1}", id, temp);
            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by posting a JSON Object to");
            Console.WriteLine("http://localhost:8000/UpdateToDoItem");
            Console.WriteLine("while this sample is running.");

            Console.WriteLine("");
        }

        private static void GetToDoListByVip(IToDoService channel)
        {
            Console.WriteLine("Calling GetToDoListByVip via HTTP GET: ");
            var toDoList = channel.GetToDoListByVip("Hamid");
            foreach (var toDo in toDoList.Items)
            {
                Console.WriteLine("   Output: {0}", toDo.Description);
            }

            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by navigating to");
            Console.WriteLine("http://localhost:8000/GetToDoListByVip?name=Hamid");
            Console.WriteLine("in a web browser while this sample is running.");

            Console.WriteLine("");
        }

        private static void GetTotalEstimation(IToDoService channel)
        {
            Console.WriteLine("Calling GetTotalEstimation via HTTP GET: ");
            var totalEstimation = channel.GetTotalEstimation("Hamid", false);
            Console.WriteLine("   TotalMinutes: {0}", totalEstimation.TotalMinutes);
            Console.WriteLine("   TimeCompleted: {0}", totalEstimation.TimeCompleted);

            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by navigating to");
            Console.WriteLine("http://localhost:8000/GetTotalEstimation?name=Hamid&includeFinnished=false");
            Console.WriteLine("in a web browser while this sample is running.");

            Console.WriteLine("");
        }

        private static void UpdateToDoItemWithEstimate(IToDoService channel)
        {
            Console.WriteLine("Calling UpdateToDoItemWithEstimate via HTTP GET: ");
            var output = channel.UpdateToDoItemWithEstimate(1, 10);

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("Error: " + output.ErrorMessage);
                Console.WriteLine("ErrorType: " + output.ErrorType);
            }

            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by posting a JSON Object to");
            Console.WriteLine("http://localhost:8000/UpdateToDoItemWithEstimate");
            Console.WriteLine("while this sample is running.");
        }

        private static void AddToDoEntries(IToDoService channel)
        {
            Console.WriteLine("Calling AddToDoEntries via HTTP POST: ");

            var output = channel.AddToDoItems(new AddMultipleToDo() { Name = "Daniels list", Descriptions = "Item 1 todo, Item 2 todo, Item 3 todo", DeadLine = DateTime.Now, EstimationTime = 10 });

            if (!string.IsNullOrEmpty(output.ErrorMessage))
            {
                Console.WriteLine("");
                Console.WriteLine("Error: " + output.ErrorMessage);
                Console.WriteLine("ErrorType: " + output.ErrorType);
            }
            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by posting a JSON Object to");
            Console.WriteLine("http://localhost:8000/AddToDoEntries");
            Console.WriteLine("while this sample is running.");

            Console.WriteLine("");
        }

        private static void SetDeadLineToDoItem(IToDoService channel)
        {
            const int id = 9;
            var newDeadLine = DateTime.Now;
            Console.WriteLine("Calling SetDeadLineToDoItem via HTTP POST: ");
            channel.SetDeadLineToDoItem(id, newDeadLine);
        }

        private static void GetToDoListOrderedAscendingByDeadLine(IToDoService channel)
        {
            const string listName = "Hamid";
            Console.WriteLine("Calling GetToDoListOrderedAscendingByDeadLine via HTTP GET: ");

            var toDoListOrderedAscendingByDeadline = channel.GetToDoListOrderedAscendingByDeadLine(listName);

            foreach (var toDoItem in toDoListOrderedAscendingByDeadline.Items)
            {
                Console.WriteLine("ID: {0} \t Description: {1} \t Deadline: {2} \t ", toDoItem.Id, toDoItem.Description, toDoItem.DeadLine);
            }
        }


    }
}
