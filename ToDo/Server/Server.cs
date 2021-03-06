﻿using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using Service;

namespace Server
{
    internal class Server
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
                ep.Behaviors.Add(new WebHttpBehavior { HelpEnabled = true, DefaultOutgoingRequestFormat = WebMessageFormat.Json, DefaultOutgoingResponseFormat = WebMessageFormat.Json });

                host.Open();

                using (var cf = new ChannelFactory<IToDoService>(new WebHttpBinding(), Url))
                {
                    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

                    Console.WriteLine("Webservice started on: " + Url);
                    Console.WriteLine("Go to " + Url + "/help for information about functionality.");

                    Console.Write("Do you want to run the self-tests? Y/N: ");
                    var input = Console.ReadLine();
                    if (input.ToLower() == "y")
                    {
                        var channel = cf.CreateChannel();
                        var tests = new SelfTests()
                        {
                            Channel = channel
                        };

                        tests.RunTests();
                    }

                }

                Console.WriteLine("Press <ENTER> to terminate.");
                Console.ReadLine();

                host.Close();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                host.Abort();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: {0}", ex.Message);
                host.Abort();
                Console.ReadLine();
            }
        }
    }
}
