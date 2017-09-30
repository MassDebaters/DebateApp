using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;


namespace DebateApp.Client.Hubs
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void SendM(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}
