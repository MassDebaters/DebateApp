using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace WebApplication1
{ 

    public class ChatHub : Hub 
    {
        public void Send(string gName,string message )
        {
            // Call the addMessage method on all clients            
          //  Clients.All.addMessage(message);
            Clients.Group(gName).addMessage(message);
        }

        //server
        public void Join(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

    }
}