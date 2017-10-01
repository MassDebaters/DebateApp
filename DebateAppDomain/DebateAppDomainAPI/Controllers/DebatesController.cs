using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DebateAppDomainAPI.Models;
using DebateApp.Domain;
using System.Net.Http;

namespace DebateAppDomainAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DebatesController : Controller
    {
        private DBHelper _dbh = new DBHelper();
        // GET api/values
        [HttpGet]
        public DebateModel CreateCasual([FromForm]CreateCasualModel cm)
        {
            var c = new Casual(cm.u.user, cm.Topic, cm.Category, cm.Opener);
            var d = new DebateModel(c);
            var res = _dbh.DBCreateDebate(d);
           
            return res;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //var DBModel = new DebateModel(id);
            return "";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
