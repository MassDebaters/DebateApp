using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DebateAppDomainAPI.Models;
using DebateApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateAppDomainAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/User/[action]")]
    public class UserController : Controller
    {

        private DBHelper _dbh = new DBHelper();
        
        // GET: api/values

        public string Error(Exception e)
        {
            return e.Message;
        }

        [HttpGet("{id}")]
        public UserModel GetUser(int id)
        {
            return _dbh.DBGetUser(id);
        }

        [HttpGet("{username}")]
        public UserModel GetUserName(string username)
        {
            return _dbh.DBGetUser(username);
        }

        [HttpGet]
        public List<UserModel> GetAllUser()
        {
            return _dbh.DBGetAllUser();
        }

        [HttpPost]
        //expects form data with 
        //Username
        //Password
        public UserModel RegisterUser([FromBody]UserModel u)
        {
            try
            {
                var res = _dbh.DBCreateUser(u);
                return res;
            }
            catch (Exception e)
            {
                Error(e);
                return null;
            }
        }

        [HttpPost]
        public DebateModel JoinTeam([FromBody]FormDataModels.JoinDebateModel jdm)
        {
            var u = _dbh.DBGetUser(jdm.username);
            u.Transfer();
            var ul = u.UserLogic;
            var d = _dbh.DBGetDebate(jdm.DebateID).d;
            try
            {
                var update = ul.JoinDebate(d, new DebatePost(jdm.Opener, ul.UserID), true);
                var result = new DebateModel(update);
                _dbh.DBSaveDebateChanges(result);
                return result;
            }
            catch (Exception e)
            {
                Error(e);
                return new DebateModel(d);
            }

        }

        [HttpPut]
        public DebateModel Vote([FromBody]FormDataModels.VoteModel voteModel)
        {
            var d = _dbh.DBGetDebate(voteModel.DebateId);
            var res = _dbh.Vote(voteModel.UserId, d, voteModel.Team);
            _dbh.DBSaveDebateChanges(res);

            return res;
        }

        [HttpPut]
        public DebateModel Post([FromBody]FormDataModels.PostModel postModel)
        {
            var result = _dbh.Post(postModel.UserId, postModel.Comment, postModel.DebateId);
            _dbh.DBSaveDebateChanges(result);

            return result;
        }
        [HttpPost]
        public DebateModel JoinAudience([FromBody]FormDataModels.UserDebateModel udm)
        {
            var d = _dbh.DBGetDebate(udm.DebateID);
            var u = _dbh.DBGetUser(udm.Username);
            u.Transfer();
            var update = u.UserLogic.ViewDebate(d.d);
            var result = new DebateModel(update);
            _dbh.DBSaveDebateChanges(result);
            return result;
        }

        


    }
}
