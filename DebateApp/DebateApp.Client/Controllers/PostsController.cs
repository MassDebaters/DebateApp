using System;
using Microsoft.AspNetCore.Mvc;
using DebateApp.Domain;

namespace DebateApp.Client.Controllers
{
    public class PostsController : Controller
    {

        public IActionResult MyPosts(string username, string password)
        {
            return View(new User(username, password));
        }

        public IActionResult NewPost(string username, string password)
        {
            return View(new User(username, password));
        }
        
    }
}
