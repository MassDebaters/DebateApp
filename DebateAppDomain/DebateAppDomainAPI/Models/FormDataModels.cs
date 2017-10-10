using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{
    public class FormDataModels
    {
        public class CreateCasualModel
        {
            public int UserID { get; set; }
            public string Topic { get; set; }
            public string Category { get; set; }
            public string Opener { get; set; }
        }

        public class JoinDebateModel
        {
            public string username { get; set; }
            public int DebateID { get; set; }
            public string Opener { get; set; }
        }

        public class VoteModel
        {
            public int UserId { get; set; }
            public int DebateId { get; set; }
            public bool Team { get; set; }
            public VoteModel(int userid, int debateid, bool team)
            {
                UserId = userid;
                DebateId = debateid;
                Team = team;
            }
        }
        public class PostModel
        {
            public int UserId { get; set; }
            public int DebateId { get; set; }
            public string Comment { get; set; }
        }

        public class UserDebateModel
        {
            public int DebateID { get; set; }
            public string Username { get; set; }
            public UserDebateModel(int did, string username)
            {
                DebateID = did;
                Username = username;
            }
        }
    }
}
