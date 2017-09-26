using System;
using Microsoft.AspNetCore.Mvc;
using DebateApp.Domain;
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
            User newUser = UserHelper.CreateUser(userModel.Username, userModel.Password);
            if(newUser == null)
              return RedirectToAction("Login");

            TempData["user"] = newUser;
            return RedirectToAction("DebateFromLogin","Debate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckLogin([Bind("Username", "Password")] UserModel userModel)
        {
            string username = userModel.Username; //Request["Username"];
            string password = userModel.Password; //Request["Password"];

            if(!UserHelper.CheckPassword(username, password))
              return RedirectToAction("Login");
            
            TempData["user"] = UserHelper.ReturnUser(username,password);
            return RedirectToAction("DebateFromLogin","Debate");
        }

    }
}
