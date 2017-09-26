using System;
using Microsoft.AspNetCore.Mvc;
using DebateApp.Domain;

namespace DebateApp.Client.Controllers
{
    public class DebateController : Controller
    {
        public IActionResult DebateIndex(string username, string password)
        {
            return View(new User(username, password));
        }

        public IActionResult MyProfile(string username, string password)
        {
            return View(new User(username, password));
        }

        public IActionResult DebateFromLogin()
        {

            return View(TempData["user"]);
        }

    }
}
