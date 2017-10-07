using System;
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
        public List<DebateModel> GetAll()
        {
            return debate.GetAllDebates();
        }

        // GET: api/Debates/5
        [HttpGet("{id}")]
        public DebateModel Get(int id)
        {
            return debate.GetDebate(id);
        }
        
        // POST: api/Debates/
        [HttpPost]
        public DebateModel Post([FromBody]DebateModel deb)
        {
            debate.AddDebate(deb);
            var id = debate.GetLastId();

            return debate.GetDebate(id);

        }

        // PUT: api/Debates/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]DebateModel value)
        {
            debate.UpdateDebate(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            debate.DeleteDebate(id);
        }

        // DELETE: api/ApiWithActions/
        [HttpDelete]
        public void DeleteAll()
        {
            debate.DeleteAllDebates();
        }
    }
}
