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

                    Console.WriteLine("Calling AddToDo via HTTP POST: ");
                    var error = channel.AddToDo("Daniels lista", "", false, DateTime.Now, DateTime.Now, 0);
                    
                    if(!string.IsNullOrEmpty(error))
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Error: " + error);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("This can also be accomplished by posting item to");
                    Console.WriteLine("http://localhost:8000/AddToDo");
                    Console.WriteLine("in a web browser while this sample is running.");

                    Console.WriteLine("");



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
    }
}
