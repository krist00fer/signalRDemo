using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";
            var connection = new HubConnection(url);
            var hub = connection.CreateHubProxy("ChatHub");
            hub.On("ReceiveMessage", m => Console.WriteLine($": {m}"));

            connection.Start().Wait();

            string message;

            while (!string.IsNullOrEmpty(message = Console.ReadLine()))
            {
                hub.Invoke("SendMessage", message);
            }

            connection.Stop();
        }
    }
}
