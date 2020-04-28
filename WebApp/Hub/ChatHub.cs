using HotBag.AspNetCore.SignalR.Attributes;
using HotBag.AspNetCore.SignalR.HubBase;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Hub
{
    [UseHubRoute("/chatHub", typeof(ChatHub))]
    public class ChatHub : HotBagHubBase
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }

    [UseHubRoute("/test", typeof(TestHub))]
    public class TestHub : HotBagHubBase
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
