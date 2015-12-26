using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using Service;

namespace Client
{
    internal class Client
    {
        public static object HttpUtility { get; private set; }

        private static void Main(string[] args)
        {
            var host = new WebServiceHost(typeof(ToDoService), new Uri("http://localhost:8000/"));

            try
            {

                var binding = new WebHttpBinding {TransferMode = TransferMode.Streamed};

                var ep = host.AddServiceEndpoint(typeof(IToDoService), binding, "");

                host.Open();

                using (var cf = new ChannelFactory<IToDoService>(new WebHttpBinding(),"http://localhost:8000"))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                    var channel = cf.CreateChannel();
                    
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

            var error = channel.AddToDoList("Daniels list", "Daniels list description", DateTime.Now, 10);

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("");
                Console.WriteLine("Error: " + error);
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
            foreach (var toDo in toDoList)
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
            var error = channel.AddToDoEntry("Daniels list", "Daniels todo Thingie", DateTime.Now, 10);

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("");
                Console.WriteLine("Error: " + error);
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
            foreach (var toDo in toDoList)
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
            var todoitem = toDoList[id];
            todoitem.DeadLine = DateTime.UtcNow;
            string temp = todoitem.DeadLine.ToString("hh:mm:ss");
            todoitem.Description = "Updated @ " + temp;
            channel.UpdateToDoItem(todoitem);
            /*
            if (!string.IsNullOrEmpty(error))
            {
            Console.WriteLine("");
                Console.WriteLine("Error: " + error);
        }
            */
            Console.WriteLine("Updated ID # {0} with {1}",id,  temp);
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
            foreach (var toDo in toDoList)
            {
                Console.WriteLine("   Output: {0}", toDo.Description);
            }

            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by navigating to");
            Console.WriteLine("http://localhost:8000/GetToDoListByVip?name=Hamid");
            Console.WriteLine("in a web browser while this sample is running.");

            Console.WriteLine("");
        }

    }
}
