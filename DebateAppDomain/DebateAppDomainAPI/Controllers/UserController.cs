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
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        
        private DBHelper _dbh = new DBHelper();
        // GET: api/values

        public string Error(Exception e)
        {
            return e.Message;
        }

        [HttpGet("{int}")]
        public UserModel GetUser(int id)
        {
            return _dbh.DBGetUser(id);
        }

        [HttpGet("{string}")]
        public UserModel GetUser(string username)
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
        public UserModel RegisterUser([FromForm]UserModel u)
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
    }
}
