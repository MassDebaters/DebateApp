using DebateApp.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DebateAppDomainAPI.Models
{
    public class DebateModel
    {
        private int _D_id;
        private HttpClient client = new HttpClient();
        private string DBRest = "http://localhost:54277/api/";
        public DebateModel(int D_id)
        {
            _D_id = D_id;
        }
        public DebateModel()
        {

        }

        private Debate _d
        {
            get
            {
                try
                {
                    var res = client.GetAsync(DBRest + "Debate/Get/" + _D_id).GetAwaiter().GetResult();
                    var ResObject = JsonConvert.DeserializeObject<Debate>(res.ToString());
                    return ResObject;
                }
                catch (Exception)
                {
                    return new Casual(new TestUser(), "Are we any good at this?", "Anxiety","Not yet...");
                }
            }
        }

        public Debate Expose()
        {
            return _d;
        }

        }
    }

