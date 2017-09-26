using System;
using Microsoft.AspNetCore.Mvc;
using DebateApp.Domain;

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
        public IActionResult CheckLogin([Bind("Username", "Password")] User user)
        {
            string username = user.Username; //Request["Username"];
            string password = user.Password; //Request["Password"];

            if(!UserHelper.CheckPassword(username, password))
              return RedirectToAction("Login");
            
            TempData["user"] = UserHelper.ReturnUser(username,password);
            return RedirectToAction("DebateFromLogin","Debate");
        }

    }
}
