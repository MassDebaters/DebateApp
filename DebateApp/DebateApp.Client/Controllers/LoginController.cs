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
            {
              Console.WriteLine("New User: UserHelper.CreateUser returned null");
              return RedirectToAction("Login");
            }

            Console.WriteLine("New User: UserHelper.CreateUser returned a User object");
            Console.WriteLine("name: "+newUser.Username);
            Console.WriteLine("Redirecting to Debate View");
            TempData["username"] = newUser.Username; // It made it here
            TempData["password"] = newUser.Password;
            return RedirectToAction("MyProfile","Debate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckLogin([Bind("Username", "Password")] UserModel userModel)
        {
            string username = userModel.Username; //Request["Username"];
            string password = userModel.Password; //Request["Password"];

            if(!UserHelper.CheckPassword(username, password))
            {
              Console.WriteLine("CheckLogin: Wrong Password or Username "+username+" "+password);
              return RedirectToAction("Login");
            }
            
            TempData["username"] = username;
            TempData["password"] = password;
            Console.WriteLine("CheckLogin: Sending to MyProfile...");
            return RedirectToAction("MyProfile","Debate");
        }

    }
}
