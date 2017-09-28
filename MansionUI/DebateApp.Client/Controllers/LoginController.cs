using System;
using Microsoft.AspNetCore.Mvc;
//using DebateApp.Domain;
using DebateApp.Client.Models;

namespace DebateApp.Client.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewUser([Bind("Username","Password")] UserModel userModel)
        {
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckLogin([Bind("Username", "Password")] UserModel userModel)
        {
            string username = userModel.Username; //Request["Username"];
            string password = userModel.Password; //Request["Password"];

            return RedirectToAction("Login");
            
        }

    }
}
