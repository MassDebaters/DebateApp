using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{

    public class DBHelper
    {
        private HttpClient _client = new HttpClient();
        private string _api = "http://localhost:54277/api/";
        private string GetDebate = "Debate/Get/";
        private string GetUser = "Account/Get/";
        private string PostUser = "Account/Post/";
        private string PostDebate = "Debate/Post/";
        private string PutDebate = "Debate/Put/";
        private string PutUser = "Account/Put/";

        
        public string DBGetDebate(int? id)
        {
            var res = _client.GetAsync(_api + GetDebate + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return ResObject;
        }

        public string DBGetAllDebate()
        {
            return DBGetDebate(null);
        }

        public string DBGetUser(int? id)
        {
            var res = _client.GetAsync(_api + GetUser + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return ResObject;
        }

        public string DBGetAllUser()
        {
            return DBGetUser(null);
        }

        public void DBCreateUser(UserModel u)
        {
            _client.PostAsync(_api + PostUser, new StringContent(JsonConvert.SerializeObject(u)));
        }

        public void DBSaveUserChanges(UserModel u)
        {
            _client.PutAsync(_api + PutUser, new StringContent(JsonConvert.SerializeObject(u)));
        }

        public void DBCreateDebate(DebateModel d)
        {
            _client.PostAsync(_api + PostDebate, new StringContent(JsonConvert.SerializeObject(d)));
        }

        public void DBSaveDebateChanges(DebateModel d)
        {
            _client.PutAsync(_api + PutDebate, new StringContent(JsonConvert.SerializeObject(d)));
        }




    }
}
