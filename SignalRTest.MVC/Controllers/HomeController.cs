using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRTest.MVC.Business;
using SignalRTest.MVC.Models;

//https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-2.2&tabs=visual-studio

namespace SignalRTest.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IHubContext<ScoreHub> hubContext;

        public HomeController(IHubContext<ScoreHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<bool> sendScore(int userId)  //Web api method.
        {
            await hubContext.Clients.All.SendAsync("broadcastScore", "Message from server");

            return true;

        }
    }
}
