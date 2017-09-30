using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateApp.Client.Hubs
{
    [HubName("chat")]
    public class ChatHub :Hub
    {
        public void Join()
        {
            Clients.All.join($"{Context.ConnectionId} has joined the room");
        }
    }
}
