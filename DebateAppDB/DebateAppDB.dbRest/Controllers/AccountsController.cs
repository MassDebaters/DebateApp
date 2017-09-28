using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DebateApp.db;
using DebateAppDB.dbRest.Models;

namespace DebateAppDB.dbRest.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private AccountModel account = new AccountModel();
        // GET: api/Accounts
        /*[HttpGet]
        public IEnumerable<Accounts> Get()
        {
            return account.GetAllAccounts();
        }*/

        // GET: api/Accounts/5
        /*[HttpGet("{id}", Name = "Get")]
        public Accounts Get(int id)
        {
            return account.GetAccount(id);
        }*/

        [HttpGet]
        public IEnumerable<AccountModel> Get()
        {
            return account.GetAllAccounts();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}", Name = "Get")]
        public AccountModel Get(int id)
        {
            return account.GetAccount(id);
        }

        [HttpGet("{username}", Name = "UniqueUsername")]
        public bool UniqueUsername(string username)
        {
            return account.UniqueUsername(username);
        }

        // POST: api/Accounts
        [HttpPost]
        public void Post(string username, string password) //[FromBody]string password)
        {
            account.AddAccount(username, password);
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
            account.DeleteAccount(id);
        }
    }
}
