using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace JutsyChat
{
    public class ChatHub : Hub
    {
        static List<Chatmate> Chatmates = new List<Chatmate>();

        public void Join(string handle)
        {
            var connectionID = Context.ConnectionId;

            if(Chatmates.Count(d=> d.ConnectionID.Equals(connectionID)) <= 0)
            {
                Chatmates.Add(new Chatmate
                {
                    ConnectionID = connectionID,
                    Handle = handle
                });
            }
        }

        public void Send(string name, string message, string backgroundColor)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.DisplayMessage(name, message, backgroundColor);

            //NotifyUsers(name);
        }

        public void NotifyUsers(string lastMessage)
        {
            Clients.All.NotifyUsers(lastMessage);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var disconnectUser = Chatmates.FirstOrDefault(d => d.Equals(Context.ConnectionId));

            if (disconnectUser != null)
            {
                Chatmates.Remove(disconnectUser);
            }
            return base.OnDisconnected(stopCalled);
        }

        public List<Chatmate> GetActiveChatmates()
        {
            return Chatmates.ToList();
        }



    }
}