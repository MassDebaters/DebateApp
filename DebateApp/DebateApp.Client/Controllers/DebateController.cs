using System;
using Microsoft.AspNetCore.Mvc;
using DebateApp.Domain;
using DebateApp.Client.Models;

namespace DebateApp.Client.Controllers
{
    public class DebateController : Controller
    {
        public IActionResult DebateIndex(string username, string password)
        {
          if(!UserHelper.CheckPassword(username, password)) 
            return RedirectToAction("Login","Login");

          return View(UserModel.CreateUserModel(username, password)); // needs to be a list of debates
        }

        public IActionResult MyProfile(string username, string password)
        {
          if(!UserHelper.CheckPassword(username, password)) 
            return RedirectToAction("Login","Login");

          return View(UserModel.CreateUserModel(username, password));
        }

        public IActionResult DebateFromLogin()
        {
            return View(TempData["user"]);
        }

    }
}
