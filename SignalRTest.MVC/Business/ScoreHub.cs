using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest.MVC.Business
{
    public class ScoreHub : Hub
    {
        public async Task SendScore(string message)
        {
            await Clients.All.SendAsync("broadcastScore", message);
        }
    }
}
