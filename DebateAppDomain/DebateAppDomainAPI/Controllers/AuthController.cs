using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DebateAppDomainAPI.Models;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateAppDomainAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private DBHelper _dbh = new DBHelper();
        private Dictionary<string, ClaimsPrincipal> _users = new Dictionary<string, ClaimsPrincipal>();
        // GET: api/values
        [HttpGet]
        public HttpResponseMessage Register([FromBody]UserModel u)
        {
            var Claims = new List<Claim>()
            {
                new Claim("Username", u.Username),
                new Claim("Password", u.Password)            
            };

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
