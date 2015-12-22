using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using Service;
using System.IO;
using System.Collections.Specialized;

namespace Client
{
    internal class Client
    {
        public static object HttpUtility { get; private set; }

        private static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(ToDoService), new Uri("http://localhost:8000/"));
            try
            {

                var binding = new WebHttpBinding();
                binding.TransferMode = TransferMode.Streamed;

                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IToDoService), binding, "");
                host.Open();

                using (ChannelFactory<IToDoService> cf = new ChannelFactory<IToDoService>(new WebHttpBinding(),"http://localhost:8000"))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
                    IToDoService channel = cf.CreateChannel();
                    
                    GetToDoList(channel);

                    AddToDoList(channel);

                    DeleteToDoItem(channel);

                    GetNumberOfToDoItemsInList(channel);

                    AddToDoEntry(channel);

                    GetToDoListByDone(channel);
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
            Console.WriteLine("Calling DeleteToDoItem via HTTP DELETE: ");
            channel.DeleteToDoItem(5);
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

    }
}
