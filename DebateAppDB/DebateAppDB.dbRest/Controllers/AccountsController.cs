using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DebateApp.db;

namespace DebateAppDB.dbRest.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private DBHelper helper = new DBHelper();
        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<Accounts> Get()
        {
            return helper.GetAllAccounts();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Accounts
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Accounts/5
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
