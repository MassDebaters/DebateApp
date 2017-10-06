using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DebateApp.db;
using DebateAppDB.dbRest.Models;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace DebateAppDB.dbRest.Controllers
{
    [Produces("application/json", "text/plain")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private AccountModel account;
        private readonly IConfiguration _Configuration;

        public AccountsController(IConfiguration configuration)
        {
            _Configuration = configuration;
            account = new AccountModel(_Configuration);
        }

        [HttpGet]
        public IEnumerable<AccountModel> GetAllAccounts()
        {
            return account.GetAllAccounts();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public AccountModel GetAccount(int id)
        {
            try
            {
                return account.GetAccount(id);
            }
            catch(Exception)
            {
                return new AccountModel(this._Configuration)
                {

                };
            }
        }

        //GET: api/Accounts/username/somestring
        [HttpGet("username/{username}")]
        public bool UniqueUsername(string username)
        {
            
            return account.UniqueUsername(username);
        }
        /*public string error()
        {
            return "did not work boy";
        }*/

        //GET: api/Accounts/astros/id
        [HttpGet("astros/{id}")]
        public int GetAstros(int id)
        {

            return account.GetAstros(id);
        }
        /*public string error()
        {
            return "did not work boy";
        }*/

        // POST: api/Accounts
        [HttpPost]
        public void Post([FromBody]Accounts user)
        {
            account.AddAccount(user);
        }
        
        // PUT: api/Accounts/addAstros/id
        [HttpPut("addAstros/{id}")]
        public void AddAstros(int id, [FromBody]int value)
        {
            account.AddAstros(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            account.DeleteAccount(id);
        }
    }
}
