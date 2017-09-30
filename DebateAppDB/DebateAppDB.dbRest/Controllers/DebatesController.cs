﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DebateAppDB.dbRest.Models;
using System.IO;
using Newtonsoft.Json;

namespace DebateAppDB.dbRest.Controllers
{
    [Produces("application/json")]
    [Route("api/Debates")]
    public class DebatesController : Controller
    {
        private DebateModel debate = new DebateModel();
        // GET: api/Debates
        [HttpGet]
        public string Get()
        {
            return debate.GetAllDebates();//new string[] { "value1", "value2" };
        }

        // GET: api/Debates/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Debates
        [HttpPost]
        public void Post([FromBody]object deb)
        {
            debate.AddDebate(deb);
        }
        
        // PUT: api/Debates/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}