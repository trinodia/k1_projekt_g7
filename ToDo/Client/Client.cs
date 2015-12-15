using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using Service;

namespace Client
{
    internal class Client
    {
        private static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(ToDoService), new Uri("http://localhost:8000/"));
            try
            {
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IToDoService), new WebHttpBinding(), "");
                host.Open();

                using (ChannelFactory<IToDoService> cf = new ChannelFactory<IToDoService>(new WebHttpBinding(),"http://localhost:8000"))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                    IToDoService channel = cf.CreateChannel();

                    GetToDoList(channel);

                    AddToDo(channel);
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

        private static void AddToDo(IToDoService channel)
        {
            Console.WriteLine("Calling AddToDo via HTTP POST: ");
            var error = channel.AddToDoList("Daniels lista 2");

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("");
                Console.WriteLine("Error: " + error);
            }
            Console.WriteLine("");
            Console.WriteLine("This can also be accomplished by posting a JSON Object to");
            Console.WriteLine("http://localhost:8000/AddToDo");
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
    }
}
