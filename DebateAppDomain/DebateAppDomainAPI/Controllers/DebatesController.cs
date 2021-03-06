﻿using System;
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
            if (get.d._gamestage)
            {
                get.d.CheckNextRound();
                _dbh.DBSaveDebateChanges(get);
            }
            if (get.d.Completed && get.d.AwardsDisbursed == false)
            {
                var teaml = get.d.Teams[0].Members[0].UserID;
                var teamr = get.d.Teams[1].Members[0].UserID;
                _dbh.DBAddAstros(teaml, (int)get.d.CurrentPotShareL);
                _dbh.DBAddAstros(teamr, (int)get.d.CurrentPotShareR);
                get.d.AwardsDisbursed = true;
                _dbh.DBSaveDebateChanges(get);
                return get;
            }
            else
            {
                return get;
            }
            
        }

        [HttpGet]
        public List<DebateModel> GetAllDebate()
        {
            return _dbh.DBGetAllDebate();
        }

        [HttpGet("{id}")]
        public DebateModel StartDebate(int id)
        {
            var result = _dbh.StartDebate(id);
            _dbh.DBSaveDebateChanges(result);
            return result;
        }

       

        

        //[HttpPut("{id}")]
        //public DebateModel NextRound(int id, [FromBody]bool value)
        //{
        //    return _dbh.NextRound(id, value);
        //}

    }
}
