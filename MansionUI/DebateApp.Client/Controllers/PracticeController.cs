using System;
using Microsoft.AspNetCore.Mvc;
using DebateApp.Client.Models;

namespace DebateApp.Client.Controllers
{
    public class PracticeController : Controller
    {
        public IActionResult Practice()
        {
            return View();
        }

        
    }
}
