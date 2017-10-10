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
    [Route("api/[controller]/[action]")]
    public class DebatesController : Controller
    {
        private DBHelper _dbh = new DBHelper();


        [HttpPost]
        //Create Casual expects an httppost with form data in the following format:
        //int UserID =
        //string Topic = 
        //string Category = 
        //string Opener = 
        public DebateModel CreateCasual([FromBody]FormDataModels.CreateCasualModel cm)
        {
            var u = _dbh.DBGetUser(cm.UserID);
            u.Transfer();
            var c = new Casual(u.UserLogic, cm.Topic, cm.Category, cm.Opener);
            c.GetStage();
            var d = new DebateModel(c);
            var res = _dbh.DBCreateDebate(d);
            return res;
        }

        [HttpGet("{id}")]
        public DebateModel GetDebate(int id)
        {
            var get = _dbh.DBGetDebate(id);
            get.d.CheckNextRound();
            return get;
        }

        [HttpGet]
        public List<DebateModel> GetAllDebate()
        {
            return _dbh.DBGetAllDebate();
        }

        [HttpGet("{id}")]
        public DebateModel StartDebate(int id)
        {
            return _dbh.StartDebate(id);
        }

        [HttpPut("{id}")]
        public DebateModel NextRound(int id, [FromBody]bool value)
        {
            return _dbh.NextRound(id, value);
        }

    }
}
