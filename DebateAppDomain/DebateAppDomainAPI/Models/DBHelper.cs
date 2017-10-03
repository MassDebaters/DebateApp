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
        private string _api = "http://localhost:54625/api/";
        private string GetDebate = "Debates/Get";
        private string GetUser = "Accounts/";
        private string PostUser = "Accounts/Post/";
        private string PostDebate = "Debates/";
        private string PutDebate = "Debates/Put/";
        private string PutUser = "Accounts/Put/";

        
        public DebateModel DBGetDebate(int? id)
        {
            var res = _client.GetAsync(_api + GetDebate + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<DebateModel>(ResObject);
        }

        public IEnumerable<DebateModel> DBGetAllDebate()
        {
            var res = _client.GetAsync(_api + GetDebate).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<IEnumerable<DebateModel>>(ResObject);
        }

        public UserModel DBGetUser(int? id)
        {
            var res = _client.GetAsync(_api + GetUser + id).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<UserModel>(ResObject);
        }

        public IEnumerable<UserModel> DBGetAllUser()
        {
            var res = _client.GetAsync(_api + GetUser).GetAwaiter().GetResult();
            var ResObject = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<IEnumerable<UserModel>>(ResObject);
        }

        public UserModel DBCreateUser(UserModel u)
        {
            var cd = _client.PostAsync(_api + PostUser, new StringContent(JsonConvert.SerializeObject(u)));
            string cds = cd.GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<UserModel>(cds);
        }

        public UserModel DBSaveUserChanges(UserModel u)
        {
            var cd = _client.PutAsync(_api + PutUser, new StringContent(JsonConvert.SerializeObject(u)));
            string cds = cd.GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<UserModel>(cds);
        }

        public DebateModel DBCreateDebate(DebateModel d)
        {
            var cd = _client.PostAsync(_api + PostDebate, new StringContent(JsonConvert.SerializeObject(d)));
            string cds = cd.GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
         
            return JsonConvert.DeserializeObject<DebateModel>(cds);
        }

        public DebateModel DBSaveDebateChanges(DebateModel d)
        {
            var cd = _client.PutAsync(_api + PutDebate, new StringContent(JsonConvert.SerializeObject(d)));
            string cds = cd.GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<DebateModel>(cds);
        }




    }
}
