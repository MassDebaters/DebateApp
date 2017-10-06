﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DebateAppDomainAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateAppDomainAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private DBHelper _dbh = new DBHelper();
        // GET: api/values

        [HttpGet("{int}")]
        public UserModel GetUser(int id)
        {
            return _dbh.DBGetUser(id);
        }

        [HttpGet("{string}")]
        public UserModel GetUser(string username)
        {
            return _dbh.DBGetUser(username);
        }

        [HttpGet]
        public IEnumerable<UserModel> GetAllUser()
        {
            return _dbh.DBGetAllUser();
        }
        [HttpPost]
        public string RegisterUser([FromForm]UserModel u)
        {
            try
            {
                u.Astros = 100;
            }
        }
    }
}
