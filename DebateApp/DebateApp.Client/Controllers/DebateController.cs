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

        public IActionResult DebateIndex()
        {
          string username = (string) TempData["username"];
          string password = (string) TempData["passwprd"];
          if(!UserHelper.CheckPassword(username, password)) 
            return RedirectToAction("Login","Login");

          return View(UserModel.CreateUserModel(username, password)); // needs to be a list of debates
        }

        public IActionResult MyProfile(string u, string p)
        {
          string username = (string) TempData["username"];
          string password = (string) TempData["password"];
          Console.WriteLine("MyProfile: Incoming info - "+username + " "+password);
          if(!UserHelper.CheckPassword(username, password))
          {
            Console.WriteLine("MyProfile: user or password incorrect");
            return RedirectToAction("Login","Login");
          }

          Console.WriteLine("MyProfile: Returning view");
          User user = UserHelper.ReturnUser(username, password);
          return View(UserModel.CreateUserModel(username, password, user.Astros));
        }

        // public IActionResult MyProfile()
        // {
        //    string username = (string) TempData["username"];
        //   string password = (string) TempData["passwprd"];
        //   if(!UserHelper.CheckPassword(username, password))
        //   {
        //     Console.WriteLine("MyProfile: user or password incorrect");
        //     return RedirectToAction("Login","Login");
        //   } 
        //   Console.WriteLine("MyProfile: Returning view");
        //   User user = UserHelper.ReturnUser(username, password);
        //   return View(UserModel.CreateUserModel(username, password, user.Astros));
        // }

        public IActionResult DebateFromLogin() //probably made obsolete by DebateIndex empty overload
        {
          string username = (string) TempData["username"];
          string password = (string) TempData["passwprd"];
          if(!UserHelper.CheckPassword(username, password)) 
            {
              Console.WriteLine("DebateFromLogic: Does not exist or password mismatch");
              return RedirectToAction("Login","Login");
            }

          Console.WriteLine("DebateFromLogic: Creating model... redirecting to profile");
          UserModel um = UserModel.CreateUserModel(username, password);
          return RedirectToAction("DebateIndex");
            //return View(UserModel.CreateUserModel(TempData["username"], TempData["password"]));
        }

    }
}
