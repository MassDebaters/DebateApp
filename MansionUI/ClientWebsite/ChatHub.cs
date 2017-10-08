using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace CientWebsite
{ 

    public class ChatHub : Hub 
    {
        public void Send(string gName,string message, String name )
        {
            // Call the addMessage method on all clients            
          //  Clients.All.addMessage(message);
            Clients.Group(gName).addMessage(name,message);
        }

        //server
        public void Join(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

        public void Leave(string roomName)
        {
             Groups.Remove(Context.ConnectionId, roomName);
        }

    }
}
