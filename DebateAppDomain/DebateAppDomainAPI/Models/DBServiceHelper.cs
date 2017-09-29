using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{
    public class DBServiceHelper
    {
        private HttpClient _client = new HttpClient();
        private string _api = "http://localhost:54277/api/";
        public DebateModel GetDebate(int id)
        {
            var res = _client.GetAsync(_api + "Debate/Get/" + id).GetAwaiter().GetResult();
            var ResObject = JsonConvert.DeserializeObject<DebateModel>(res.ToString());
            return ResObject;
        }

    }
}
