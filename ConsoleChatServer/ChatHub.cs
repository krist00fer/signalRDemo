using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChatServer
{
    public class ChatHub : Hub
    {
        public override Task OnConnected()
        {
            Console.WriteLine($"{Context.ConnectionId}: (Connected)");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine($"{Context.ConnectionId}: (Disconnected)");
            return base.OnDisconnected(stopCalled);
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{Context.ConnectionId}: {message}");
            Clients.AllExcept(Context.ConnectionId).ReceiveMessage(message);
        }
    }
}
